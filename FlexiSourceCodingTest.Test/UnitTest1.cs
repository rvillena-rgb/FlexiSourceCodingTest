using Xunit;
using FlexiSourceCodingTest.Models;
using FlexiSourceCodingTest.Controllers;
using FlexiSourceCodingTest.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FlexiSourceCodingTest.Test
{
    public class UnitTest1
    {
        private readonly UserController _controller;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public UnitTest1()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _controller = new UserController(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task GetUserProfile_ReturnsProfiles()
        {
            // Arrange
            var userId = "testUser";
            var profiles = new List<GetUserProfileReturn> { new GetUserProfileReturn { /* set properties */ } };
            _mockUnitOfWork.Setup(u => u.User.GetUserProfile(userId)).ReturnsAsync(profiles);

            // Act
            var result = await _controller.GetUserProfile(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(profiles, result);
        }

        [Fact]
        public async Task GetUserList_ReturnsUserList()
        {
            // Arrange
            var userList = new List<GenericReturnStatusData<GetUserListReturn>> { new GenericReturnStatusData<GetUserListReturn> { /* set properties */ } };
            _mockUnitOfWork.Setup(u => u.User.GetUserList()).ReturnsAsync(userList);

            // Act
            var result = await _controller.GetUserList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userList, result);
        }

        [Fact]
        public async Task GetUserRunningActivity_ReturnsRunningActivity()
        {
            // Arrange
            var userId = "testUser";
            var activities = new List<GetUserRunningActivityReturn> { new GetUserRunningActivityReturn { /* set properties */ } };
            _mockUnitOfWork.Setup(u => u.User.GetUserRunningActivity(userId)).ReturnsAsync(activities);

            // Act
            var result = await _controller.GetUserRunningActivity(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(activities, result);
        }

        [Fact]
        public async Task AddUpdateStudent_ReturnsGenericReturn()
        {
            // Arrange
            var param = new UserProfileParam { /* set properties */ };
            var resultData = new List<GenericReturn> { new GenericReturn { /* set properties */ } };
            _mockUnitOfWork.Setup(u => u.User.AddUpdateUser(param)).ReturnsAsync(resultData);

            // Act
            var result = await _controller.AddUpdateStudent(param);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultData, result);
        }

        [Fact]
        public async Task AddUserRunningActivity_ReturnsGenericReturn()
        {
            // Arrange
            var param = new UserRunningActivityParam { /* set properties */ };
            var resultData = new List<GenericReturn> { new GenericReturn { /* set properties */ } };
            _mockUnitOfWork.Setup(u => u.User.AddUserRunningActivity(param)).ReturnsAsync(resultData);

            // Act
            var result = await _controller.AddUserRunningActivity(param);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultData, result);
        }

        [Fact]
        public async Task DeleteUser_ReturnsGenericReturn()
        {
            // Arrange
            var param = new DeleteuserParam { /* set properties */ };
            var resultData = new List<GenericReturn> { new GenericReturn { /* set properties */ } };
            _mockUnitOfWork.Setup(u => u.User.DeleteUser(param)).ReturnsAsync(resultData);

            // Act
            var result = await _controller.DeleteUser(param);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultData, result);
        }

        [Fact]
        public async Task DeleteUserRunningActivity_ReturnsGenericReturn()
        {
            // Arrange
            var param = new DeleteUserRunningActiviyParam { /* set properties */ };
            var resultData = new List<GenericReturn> { new GenericReturn { /* set properties */ } };
            _mockUnitOfWork.Setup(u => u.User.DeleteUserRunningActiviy(param)).ReturnsAsync(resultData);

            // Act
            var result = await _controller.DeleteUserRunningActiviy(param);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(resultData, result);
        }
    }
}