using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class District
    {
        [Required]       
        [Display(Name = "District ID")]
        public int DistrictID { get; set; }

        [Required]
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }
    }
}
