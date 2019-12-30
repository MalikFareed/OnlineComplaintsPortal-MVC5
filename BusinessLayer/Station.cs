using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Station
    {
        [Required]
        [Display(Name = "Station ID")]
        public int StationID { get; set; }

        [Required]
        [Display(Name = "Station Name")]
        public string StationName { get; set; }

        [Required]
        [Display(Name = "District ID")]
        public int DistrictID { get; set; }
    }
}
