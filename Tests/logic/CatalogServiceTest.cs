namespace Tests.logic;

using PT2.data.interfaces;
using PT2.data.model;
using PT2.logic.services;

namespace Tests.logic
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private UserService _userService;

        [TestInitialize]
        public void Setup()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [TestMethod]
        public void RegisterUser_ValidUser_AddsToRepository()
        {
            // Arrange
            string username = "testuser";
            string password = "password";
            string email = "test@example.com";

            // Act
            _userService.RegisterUser(username, password, email);

            // Assert
            _userRepositoryMock.Verify(r => r.AddUser(It.Is<User>(u => 
                    u.Username == username && 
                    u.Password == password && 
                    u.Email == email)), 
                Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_EmptyUsername_ThrowsException()
        {
            _userService.RegisterUser("", "password", "email@test.com");
        }

        [TestMethod]
        public void IsUserRegistered_ExistingUser_ReturnsTrue()
        {
            // Arrange
            string username = "existingUser";
            _userRepositoryMock.Setup(r => r.GetUserByUsername(username))
                .Returns(new User(1, username, "pass", "email"));

            // Act
            bool result = _userService.IsUserRegistered(username);

            // Assert
            Assert.IsTrue(result);
        }
    }
}