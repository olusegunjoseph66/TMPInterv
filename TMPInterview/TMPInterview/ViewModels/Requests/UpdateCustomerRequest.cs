using System.ComponentModel.DataAnnotations;
using TMPInterview.Constants;

namespace TMPInterview.ViewModels.Requests
{
    public class UpdateCustomerRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "CustomerTypeId is Required!")]
        public int CustomerTypeId { get; set; }
    }
}
