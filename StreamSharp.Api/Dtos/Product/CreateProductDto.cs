using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamSharp.Api.Dtos.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}