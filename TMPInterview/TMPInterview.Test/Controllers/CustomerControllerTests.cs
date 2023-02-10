using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPInterview.Controllers;
using TMPInterview.Interface;
using TMPInterview.ViewModels.Requests;
using TMPInterview.ViewModels.Responses;
using Xunit;

namespace TMPInterview.Test.Controllers
{
    public class CustomerControllerTests
    {
        private readonly ICustomerService _customerService;
        public CustomerControllerTests()
        {
             _customerService = A.Fake<ICustomerService>();
        }

        [Fact]
        public async void CustomerController_GetCustomers_ObjectResults()
        {
            CancellationToken cancellationToken = new();
            //Arrange

            var customerlist = A.Fake<IList<CustomerResponse>>();
            var controler = new CustomerController(_customerService);
            //Act

            var result = await controler.GetCustomers(cancellationToken);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));

        }

        [Fact]
        public async void CustomerController_GetCustomerById_ObjectResults()
        {
            int customerId = 1;

            CancellationToken cancellationToken = new();
            //Arrange

            var customerbyid = A.Fake<IList<CustomerResponse>>();
            var controler = new CustomerController(_customerService);
            //Act

            var result = await controler.GetCustomerById(customerId, cancellationToken);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));

        }

        [Fact]
        public async void CustomerController_Update_ObjectResults()
        {
            int customerId = 1;
            UpdateCustomerRequest updateCustomer = new();
            updateCustomer.FirstName = "TestJ";
            updateCustomer.LastName = "estJ";
            updateCustomer.PhoneNumber = "097777";
            updateCustomer.EmailAddress = "estJ@yahoo.com";
            updateCustomer.Gender = "Male";
            updateCustomer.CustomerTypeId = 2;


            CancellationToken cancellationToken = new();
            //Arrange

            var customerbyid = A.Fake<IList<CustomerResponse>>();
            var controler = new CustomerController(_customerService);
            //Act

            var result = await controler.Update(customerId, updateCustomer ,cancellationToken);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));

        }

        [Fact]
        public async void CustomerController_Register_ObjectResults()
        {
           
            CreateCustomerRequest createCustomer = new();
            createCustomer.FirstName = "WeTest";
            createCustomer.LastName = "WestJ";
            createCustomer.PhoneNumber = "097777";
            createCustomer.EmailAddress = "WestJ@pwc.com";
            createCustomer.Gender = "Male";


            CancellationToken cancellationToken = new();
            //Arrange

            var customerbyid = A.Fake<IList<CustomerResponse>>();
            var controler = new CustomerController(_customerService);
            //Act

            var result = await controler.Register( createCustomer, cancellationToken);
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(ObjectResult));

        }
    }
}
