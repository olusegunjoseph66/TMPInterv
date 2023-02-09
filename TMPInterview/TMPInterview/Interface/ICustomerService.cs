
using TMPInterview.Helpers;
using TMPInterview.ViewModels.Requests;
using TMPInterview.ViewModels.Responses;

namespace TMPInterview.Interface
{
    public interface ICustomerService
    {
        Task<APIResponse<List<CustomerResponse>>> ViewAllCustomers(CancellationToken cancellationToken);
        Task<APIResponse<string>> CreateCustomer(CreateCustomerRequest user, CancellationToken cancellationToken);
        Task<APIResponse<CustomerResponse>> ViewCustomerDetails(int customerId, CancellationToken cancellationToken);
        Task<APIResponse<string>> UpdateCustomer(int customerId, UpdateCustomerRequest updateCustomer, CancellationToken cancellationToken);


    }
}
