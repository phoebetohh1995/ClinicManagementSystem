using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Doctor
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Highest Qualification is required.")]
        public string HighestQualification { get; set; }
        [Required(ErrorMessage = "Years of experience is required.")]
        public int YearsOfExp { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Invalid Phone number format.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }




    }
}
