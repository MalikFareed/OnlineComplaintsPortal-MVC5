using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Complain
    {
        [Required]
        [Display(Name = "Complainant's CNIC* : ")]
        public double ComplainantsCNIC { get; set; }

        [Display(Name = "Name* : ")]
        public string cName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Incident* : ")]
        public DateTime DateOfIncident { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Time of Incident* : ")]
        public DateTime TimeOfIncident { get; set; }

        [Required]
        [Display(Name = "Place of Incident* : ")]
        public string PlaceOfIncident { get; set; }

        [Required]
        [Display(Name = "District Name* : ")]
        public string DistrictName { get; set; }

        [Required]
        [Display(Name = "Station Name* : ")]
        public string StationName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Detail of Incident* : ")]
        public string DetailOfIncident { get; set; }

        [Required]
        [Display(Name = "Already Visited Police Station* : ")]
        public bool AlreadyVisitPoliceStation { get; set; }

        [Display(Name = "Visit Details* : " +
            "(eg Officer Name/Rank)")]
        [DataType(DataType.MultilineText)]
        public string VisitDetail { get; set; }

        [Display(Name = "Visit Date* : ")]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }

        [Display(Name = "Visit Time* : ")]
        [DataType(DataType.Time)]
        public DateTime VisitTime { get; set; }
    }
}
