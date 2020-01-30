using System.ComponentModel.DataAnnotations;

namespace LevoApiExample.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Brand { get; set; }

        [Required, StringLength(50)]
        public string Model { get; set; }

        [Required, Range(1990,2020)]
        public int YearOfProduction { get; set; }
    }
}