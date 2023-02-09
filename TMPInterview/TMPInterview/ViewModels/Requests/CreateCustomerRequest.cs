
using System.ComponentModel.DataAnnotations;

namespace TMPInterview.ViewModels.Requests
{
    public class CreateCustomerRequest
    {
           

        [Required(ErrorMessage = "First Name is Required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required!")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }

        [Required(ErrorMessage = "Phone Number is Required!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Address is Required!")]
        [EmailAddress(ErrorMessage = "Email is invalid!")]
        public string EmailAddress { get; set; }
        public DateTime? BirthDay { get; set; }

        [Required(ErrorMessage = "Gender is Required!")]
        public string Gender { get; set; }
        
    }

}
