
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using TMPInterview.Constants;
using TMPInterview.Controllers;
using TMPInterview.DbModels;
using TMPInterview.Enums;
using TMPInterview.Helpers;
using TMPInterview.Interface;
using TMPInterview.ViewModels.Requests;
using TMPInterview.ViewModels.Responses;

namespace TMPInterview.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly tmpdbContext _context;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(tmpdbContext context, ILogger<CustomerService> logger)
        {
            _context = context;
            _logger = logger;
        }


        public async Task<APIResponse<string>> CreateCustomer(CreateCustomerRequest user, CancellationToken cancellationToken)
        {
            APIResponse<string> apiResponse = new();
            APIResponse<string> response = new();
            try
            {

                var checkCustomer = await _context.Customers.Where(cu => cu.EmailAddress == user.EmailAddress || cu.PhoneNumber == user.PhoneNumber).FirstOrDefaultAsync(cancellationToken);

                if (checkCustomer == null)
                {

                    var registeredCustomer = new Customer()
                    {
                        DateCreated = DateTime.UtcNow,
                        DateModified = DateTime.UtcNow,
                        Title = user.Title,
                        Firstname = user.FirstName,
                        Lastname = user.LastName,
                        Middlename = user.MiddleName,
                        EmailAddress = user.EmailAddress,
                        Gender = user.Gender,
                        PhoneNumber = user.PhoneNumber,
                        CustomerTypeId = (Int16)CustomerTypeStatus.NonActive,
                        Birthday = user.BirthDay,

                    };

                    await _context.Customers.AddAsync(registeredCustomer,cancellationToken);
                    await _context.SaveChangesAsync();


                    response = apiResponse.FormatResponse(SuccessMessages.CUSTOMERS_CREATED, ResponseStatus.Successful, System.Net.HttpStatusCode.OK, SuccessMessages.CUSTOMERS_CREATED);
                }
                else
                {
                    _logger.LogError($"customer with the {user.EmailAddress} and/or {user.PhoneNumber} already exist ");

                    response = apiResponse.FormatResponse(ErrorMessages.DEFAULT_EXIST_CUSTOMER, ResponseStatus.Failed, System.Net.HttpStatusCode.NotFound, null);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = apiResponse.FormatResponse(ErrorMessages.SERVER_ERROR, ResponseStatus.Failed, System.Net.HttpStatusCode.InternalServerError, null);

            }
            return response;
        }

        public async Task<APIResponse<string>> UpdateCustomer(int customerId, UpdateCustomerRequest updateCustomer, CancellationToken cancellationToken)
        {
            APIResponse<string> apiResponse = new();
            APIResponse<string> response = new();
            try
            {

                var checkCustomer = await _context.Customers.Where(cu => cu.Id == customerId).FirstOrDefaultAsync(cancellationToken);

                if (checkCustomer != null)
                {

                    checkCustomer.DateModified = DateTime.UtcNow;
                    checkCustomer.Firstname = updateCustomer.FirstName;
                    checkCustomer.Lastname = updateCustomer.LastName;
                    checkCustomer.Middlename = updateCustomer.MiddleName;
                    checkCustomer.EmailAddress = updateCustomer.EmailAddress;
                    checkCustomer.Gender = updateCustomer.Gender;
                    checkCustomer.PhoneNumber = updateCustomer.PhoneNumber;
                    checkCustomer.CustomerTypeId = (Int16)updateCustomer.CustomerTypeId;
                    checkCustomer.Birthday = updateCustomer.BirthDay;

                     _context.Customers.Update(checkCustomer);
                     _context.SaveChanges();

                    response = apiResponse.FormatResponse(SuccessMessages.CUSTOMERS_UPDATED, ResponseStatus.Successful, System.Net.HttpStatusCode.OK, SuccessMessages.CUSTOMERS_UPDATED);
                }
                else
                {
                    
                    response = apiResponse.FormatResponse(ErrorMessages.CUSTOMER_RECORDS_NOT_FOUND, ResponseStatus.Failed, System.Net.HttpStatusCode.NotFound, null);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = apiResponse.FormatResponse(ErrorMessages.SERVER_ERROR, ResponseStatus.Failed, System.Net.HttpStatusCode.InternalServerError, null);

            }
            return response;
        }

        public async Task<APIResponse<List<CustomerResponse>>> ViewAllCustomers(CancellationToken cancellationToken)
        {
            APIResponse<List<CustomerResponse>> apiResponse = new();
            APIResponse<List<CustomerResponse>> response = new();
            try
            {
                var customers = await _context.Customers.Include(ct => ct.CustomerType).ToListAsync(cancellationToken);

                List<CustomerResponse> allcustomers = new();
                foreach (var customer in customers)
                {
                    CustomerResponse customersoutput = new()
                    {
                        Id = customer.Id,
                        Title = customer.Title,
                        Firstname = customer.Firstname,
                        Lastname = customer.Lastname,
                        Middlename = customer.Middlename,
                        EmailAddress = customer.EmailAddress,                       
                        PhoneNumber = customer.PhoneNumber ,
                        RegistrationDate = customer.DateCreated,        
                        CustomerTypeStatus = customer.CustomerType.Name
                        
                    };
                    allcustomers.Add(customersoutput);
                }

                response = apiResponse.FormatResponse(SuccessMessages.CUSTOMERS_FETCHED, Enums.ResponseStatus.Successful, System.Net.HttpStatusCode.OK, allcustomers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = apiResponse.FormatResponse(ErrorMessages.SERVER_ERROR, Enums.ResponseStatus.Failed, System.Net.HttpStatusCode.InternalServerError, null);
            }
            return response;
        }
        
        public async Task<APIResponse<CustomerResponse>> ViewCustomerDetails(int customerId, CancellationToken cancellationToken)
        {
            APIResponse<CustomerResponse> apiResponse = new();
            APIResponse<CustomerResponse> response = new();
            try
            {
                var customerDetails = await _context.Customers.Where(o => o.Id == customerId ).Include(ct =>ct.CustomerType).FirstOrDefaultAsync(cancellationToken);

                if (customerDetails != null)
                {

                    CustomerResponse customerDetailOutput = new()
                    {
                        Id = customerDetails.Id,
                        Firstname = customerDetails.Firstname,
                        Lastname = customerDetails.Lastname,
                        Middlename = customerDetails.Middlename,
                        EmailAddress = customerDetails.EmailAddress,
                        PhoneNumber = customerDetails.PhoneNumber,
                        RegistrationDate = customerDetails.DateCreated,
                        Title = customerDetails.Title,
                        CustomerTypeStatus = customerDetails.CustomerType.Name
                        
                    };                   

                    response = apiResponse.FormatResponse(SuccessMessages.CUSTOMERS_FETCHED, Enums.ResponseStatus.Successful, System.Net.HttpStatusCode.OK, customerDetailOutput);
                }
                else
                {
                    response = apiResponse.FormatResponse(ErrorMessages.CUSTOMER_RECORD_NOT_FOUND, Enums.ResponseStatus.Successful, System.Net.HttpStatusCode.OK, null);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response = apiResponse.FormatResponse(ErrorMessages.SERVER_ERROR, Enums.ResponseStatus.Failed, System.Net.HttpStatusCode.InternalServerError, null);
            }
            return response;
        }

    }
}
