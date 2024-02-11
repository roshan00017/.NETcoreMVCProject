using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MVCProject.Controllers;
using MVCProject.Models.Domain;
using MVCProject.Services.Interface;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace MVCProject.Tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfUsers()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var controller = new UserController(mockUserService.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact]
        public async Task UserDetails_ReturnsAViewResult_WithAUser()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            var controller = new UserController(mockUserService.Object);

            // Act
            var result = await controller.UserDetails(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact]
        public async Task CreateUser_ReturnsARedirectToActionResult_WhenModelStateIsValid()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(repo => repo.CreateUserAsync(It.IsAny<User>())).ReturnsAsync(true);
            var controller = new UserController(mockUserService.Object);

            // Act
            var result = await controller.CreateUser(new User());

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("User", redirectToActionResult.ControllerName);
        }

    }
}
