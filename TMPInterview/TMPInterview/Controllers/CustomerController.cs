using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TMPInterview.Helpers;
using TMPInterview.Interface;
using TMPInterview.ViewModels.Requests;
using TMPInterview.ViewModels.Responses;

namespace TMPInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
           
        }


        
        [HttpPost("createcustomer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        public async Task<IActionResult> Register([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = await _customerService.CreateCustomer(request, cancellationToken);
            return StatusCode(response.StatusCode, response.ResponseBody);
        }

        [HttpPut("updatecustomer{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        public async Task<IActionResult> Update( int customerId, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = await _customerService.UpdateCustomer(customerId, request, cancellationToken);
            return StatusCode(response.StatusCode, response.ResponseBody);
        }

        [HttpGet("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        public async Task<IActionResult> GetCustomerById(int customerId, CancellationToken cancellationToken)
        {
            var response = await _customerService.ViewCustomerDetails(customerId, cancellationToken);
            return StatusCode(response.StatusCode, response.ResponseBody);
        }
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SwaggerResponse<EmptyResponse>))]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var response = await _customerService.ViewAllCustomers(cancellationToken);
            return StatusCode(response.StatusCode, response.ResponseBody);
        }

    }
}
