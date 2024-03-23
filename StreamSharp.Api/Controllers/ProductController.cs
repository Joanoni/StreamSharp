using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreamSharp.Api.Context;
using StreamSharp.Api.Dtos.Product;
using StreamSharp.Api.Mappers;
using StreamSharp.Api.Models;

namespace StreamSharp.Api.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController(AppDbContext context = null!) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _context.Products.ToListAsync();

        var productsDto = products.Select(s => s.ToProductDto());

        return Ok(productsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product.ToProductDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto)
    {
        var product = createProductDto.ToStockFromCreateDto();
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product.ToProductDto());
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDto updateProductDto)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        product.Name = updateProductDto.Name;
        product.Price = updateProductDto.Price;
        product.Quantity = updateProductDto.Quantity;

        await _context.SaveChangesAsync();

        return Ok(product.ToProductDto());
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
