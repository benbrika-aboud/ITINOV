using BanqueITINOV.Controllers;
using BanqueITINOV.Entities;
using BanqueITINOV.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BanqueITINOVTest
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerService> _customerServiceMock;
        private readonly CustomerController _customerController;

        public CustomerControllerTests()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _customerController = new CustomerController(_customerServiceMock.Object);
        }

        [Fact]
        public  void GetHistorical_ShouldReturnTheRightType()
        {
            var result =  _customerController.GetHistorical(2);
            Assert.IsType<Task<ActionResult<IEnumerable<Transaction>>>>(result);
        }
        
        //[Fact]
        //public void GetHistorical_Returns_the_Right_list()
        //{
        //    //Arrange
        //    var customerService = A.Fake<ICustomerService>();
        //    var customerId = 3;
        //    A.CallTo( () => customerService.GetHistoricalTransactionsAsync(customerId)).Returns();
        //    var controller = new CustomerController(customerService);
        //   //Act

        //   //Assert
        //}
    }
}