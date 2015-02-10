using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Pharmacy.DAL
{
    
    public class MainClientDataValidation
    {
        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "First name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Last name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w][^_]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Please enter correct email.")]
        public string Email { get; set; }        
    }

    public class OtherClientDataValidation
    {
        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "BirthDate")]  
        [DataType(DataType.DateTime, ErrorMessage = "Please enter correct date")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Address")]
        [RegularExpression(@"^[0-9a-zA-Z''_''.'',''-'\s]{1,40}$", ErrorMessage = "Use only english letters, numbers and ,._-")]   
        public string Address { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get; set; }
    }

    public class EyeClientDataValidation
    {
        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Left eye")]
        [Range(-10, 10, ErrorMessage = "Enter the number not less than -10 and not more than 10")]
        public int? LeftEye { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Right eye")]
        [Range(-10, 10, ErrorMessage = "Enter the number not less than -10 and not more than 10")]        
        public int? RightEye { get; set; }
    }

    public class VisitClientDataValidation
    {
        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Visit date")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter correct date")]
        public DateTime? VisitDate { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Order amount")]
        [Range(0, 10000, ErrorMessage = "Amount should be more than 0 and less than 10000")]
        public decimal? OrderAmount { get; set; }

        [Required(ErrorMessage = "Cannot be empty")]
        [Display(Name = "Order status")]
        public string OrderStatus { get; set; }
    }
}