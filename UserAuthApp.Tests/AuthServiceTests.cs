using Xunit;
using Moq;
using UserAuthApp.Application.Services;
using UserAuthApp.Domain.Entities;
using UserAuthApp.Domain.Interfaces;

namespace UserAuthApp.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public void Authenticate_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var notificationMock = new Mock<INotificationService>();

            userRepoMock.Setup(r => r.GetUserByEmail("test@example.com"))
                        .Returns(new User { Email = "test@example.com", Password = "password" });

            var service = new AuthService(userRepoMock.Object, notificationMock.Object);

            // Act
            var result = service.Authenticate("test@example.com", "password");

            // Assert
            Assert.True(result);
            notificationMock.Verify(n => n.Notify(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Authenticate_InvalidCredentials_ReturnsFalse()
        {
            // Arrange
            var userRepoMock = new Mock<IUserRepository>();
            var notificationMock = new Mock<INotificationService>();

            userRepoMock.Setup(r => r.GetUserByEmail("test@example.com"))
                        .Returns(new User { Email = "test@example.com", Password = "password" });

            var service = new AuthService(userRepoMock.Object, notificationMock.Object);

            // Act
            var result = service.Authenticate("test@example.com", "wrongpassword");

            // Assert
            Assert.False(result);
            notificationMock.Verify(n => n.Notify(It.IsAny<string>()), Times.Never);
        }
    }
}
