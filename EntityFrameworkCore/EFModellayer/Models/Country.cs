using System.ComponentModel.DataAnnotations;

namespace EFModellayer.Models
{
    public class Country
    {
        // Properties
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public double Area { get; set; } // in square kilometers
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Continent { get; set; }

       
       
    }

}
