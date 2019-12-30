using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class ComplainantsDetail
    {
        [Required]
        [Display(Name = "Name*")]
        public string cName { get; set; }

        [Required]
        [Display(Name = "Father Name*")]
        public string FatherName { get; set; }

        [Required]
        [Display(Name = "CNIC*\n(e.g 1111122223333)")]
        public Int64 CNIC { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile*\n(e.g 03xx1234567)")]
        public Int64 Mobile { get; set; }

        [Display(Name = "Landline*\n(e.g 0213xxxxxxx)")]
        [DataType(DataType.PhoneNumber)]
        public Int64 Landline { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Present Address*")]
        public string PresentAddress { get; set; }

        [Required]
        [Display(Name = "Home District*")]
        public string HomeDistrict { get; set; }

        [Required]
        [Display(Name = "Home Station*")]
        public string HomeStation { get; set; }


        [Display(Name = "Account Type")]
        public string AccountType { get; set; }
    }
}
