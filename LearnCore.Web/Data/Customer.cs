using System.ComponentModel.DataAnnotations;

namespace LearnCore.Web.Data
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter mobile")]
        public string MobileNo { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }  //change gender datatype to string
        public bool TermAndCondition { get; set; }
    }
}
