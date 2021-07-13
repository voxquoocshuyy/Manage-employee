using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SE141048_VoQuocHuy_PE.Identity
{
    public class Department
    {
        [Key]
        [Display(Name = "Deppartment ID")]
        public int depID { get; set; }

        [Required]
        [Display(Name = "Deppartment Name")]
        public String depName { get; set; }

        [Required]
        [Display(Name = "Deppartment Age")]
        [Range(0, 120)]
        public int age { get; set; }

        [Required]
        [Display(Name="Salary")]
        [Range(0, 999999999999)]
        public double salary { get; set; }

        [Required]
        [Display(Name = "Email")]
        public String email { get; set; }

        [Required]
        [Display(Name="Birthday")]
        public DateTime? birthday { get; set; }

        [Required]
        [Display(Name = "Photo")]
        public String photo { get; set; }

        [Required]
        [Display(Name = "Married")]
        public Boolean married { get; set; }

        [Required]
        [Display(Name = "Address")]
        public String address { get; set; }

        [ForeignKey("Professor")]
        [Display(Name= "Professor ID")]
        [Required]
        public int professorID { get; set; }
        public Professor Professor { get; set; }
    }
}
