using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer
{
    public class Employee
    {
        [Required]
        [Display(Name = "CNIC")]
        public double CNIC { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Father Name")]
        public string FatherName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Employee Password")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile")]
        public double Mobile { get; set; }

        [Display(Name = "Landline")]
        [DataType(DataType.PhoneNumber)]
        public double Landline { get; set; }

        [Required]
        [Display(Name = "Salary")]
        public double Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }

        [Required]
        [Display(Name = "Post")]
        public string PostTitle { get; set; }

        [Required]
        [Display(Name = "Station")]
        public string StationName { get; set; }


        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

    }
}
