using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreamSharp.Api.Dtos.Product;
using StreamSharp.Api.Models;

namespace StreamSharp.Api.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        public static Product ToStockFromCreateDto(this CreateProductDto createProductDto)
        {
            return new Product
            {
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Quantity = createProductDto.Quantity
            };
        }
    }
}