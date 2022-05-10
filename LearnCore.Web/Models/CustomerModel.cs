using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearnCore.Web.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            AvailableAges = new List<SelectListItem>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email id")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Please enter valid email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage ="Please enter mobile no")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
           ErrorMessage = "Please enter valid mobile number")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please select age")]
        public int Age { get; set; }
        public string Gender { get; set; }  //Change gender datatype to string
        public bool TermAndCondition { get; set; }

        public IList<SelectListItem> AvailableAges { get; set; }
    }
}
