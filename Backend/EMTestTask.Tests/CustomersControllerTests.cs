using Moq;
using Microsoft.AspNetCore.Mvc;
using EMTestTask.Controllers;
using EMTestTask.Models;
using EMTestTask.Sevices;

public class CustomersControllerTests
{
    [Fact]
    public async Task Get_All_Customers()
    {
        // Arrange
        var mockService = new Mock<CustomersService>();
        var mockedCustomers = new List<Customer>
        {
            new Customer { Id = "1", FirstName = "Oleh", SecondName = "Malanchuk", Email = "EMTester@everymatrix.com", PhoneNumber = "380985732757", Address = "Lviv" },
            new Customer { Id = "2", FirstName = "Tyler", SecondName = "Durden", Email = "EMTester2@everymatrix.com", PhoneNumber = "380985732756", Address = "Lviv" }
        };
        mockService.Setup(service => service.GetAsync()).ReturnsAsync(mockedCustomers);

        var controller = new CustomersController(mockService.Object);

        // Act
        var result = await controller.Get();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Oleh", result[0].FirstName);
        Assert.Equal("Tyler", result[1].FirstName);
    }

    [Fact]
    public async Task Create_Customer()
    {
        // Arrange
        var mockService = new Mock<CustomersService>();
        var newCustomer = new Customer
        {
            Id = "1",
            FirstName = "Oleh",
            SecondName = "Malanchuk",
            Email = "testmail@everymatrix.com",
            PhoneNumber = "380985732758",
            Address = "Lviv"
        };

        mockService.Setup(service => service.CreateAsync(It.IsAny<Customer>())).Returns(Task.CompletedTask);

        var controller = new CustomersController(mockService.Object);

        // Act
        var result = await controller.Post(newCustomer);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var createdCustomer = Assert.IsType<Customer>(createdAtActionResult.Value);
        Assert.Equal(newCustomer.FirstName, createdCustomer.FirstName);
        Assert.Equal(newCustomer.SecondName, createdCustomer.SecondName);
        Assert.Equal(newCustomer.Email, createdCustomer.Email);
        Assert.Equal(newCustomer.PhoneNumber, createdCustomer.PhoneNumber);
    }
}
