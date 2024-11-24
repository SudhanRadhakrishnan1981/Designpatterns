using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace EFModellayer.Models
{
    // Domain Object - Product
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName ="decimal(6,2)" )]
        public decimal Price { get; set; }
        // Other domain-specific properties and methods

        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }


    }
}
