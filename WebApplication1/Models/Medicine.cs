using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public double Price { get; set; }
    }
}
