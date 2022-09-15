using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Appointment
    {
      
        public int Id { get; set; }

        [Display(Name = "Date and Time")]
        public DateTime ApptDateTime { get; set; }

        [Display(Name ="Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey(name: "DoctorId")]
        public Doctor Doctor { get; set; }

        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        [ForeignKey(name: "PatientId")]
        public Patient Patient { get; set; }    

        


    }
}
