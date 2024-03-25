using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


namespace StreamSharp.Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public bool Caio { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);

        }

    }
}