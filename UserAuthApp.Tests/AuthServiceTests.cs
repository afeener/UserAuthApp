using Xunit;
using Moq;
using UserAuthApp.Application.Services;
using UserAuthApp.Domain.Entities;
using UserAuthApp.Domain.Interfaces;
using UserAuthApp.Common;

namespace UserAuthApp.Tests
{
    public class AuthServiceTests
    {
        [Fact]
        public void Authenticate_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            var email = "test@example.com";
            var userRepoMock = new Mock<IUserRepository>();
            var notificationMock = new Mock<INotificationService>();

            userRepoMock.Setup(r => r.GetUserByEmail(email))
                        .Returns(new User { Email = email, Password = "password" });

            var service = new AuthService(userRepoMock.Object, notificationMock.Object);

            // Act
            var result = service.Authenticate(email, "password");

            // Assert
            Assert.True(result);
            notificationMock.Verify(n => n.Notify(Messages.UserLoggedIn(email)), Times.Once);
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
            notificationMock.Verify(n => n.Notify(Messages.InvalidCredentials), Times.Once);
        }
    }
}
