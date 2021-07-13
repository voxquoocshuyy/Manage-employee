using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SE141048_VoQuocHuy_PE.Identity
{
    public class Professor
    {
        [Key]
        [Display(Name = "Professor ID")]
        public int proID { get; set; }

        [Required]
        [Display(Name = "Professor Name")]
        public String proName { get; set; }

        [Required]
        [Display(Name = "Employee")]
        [Range(0, 9999999999)]
        public int employee { get; set; }

        [Required]
        [Display(Name = "Location")]
        public String location { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
