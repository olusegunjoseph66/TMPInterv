namespace TMPInterview.ViewModels.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string CustomerTypeStatus { get; set; }
    }
}
