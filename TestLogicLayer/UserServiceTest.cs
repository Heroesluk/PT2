using PT2.logic;
using Tests.logic.helper;

namespace TestLogicLayer
{
    [TestClass]
    public class UserServiceTests
    {

        [TestMethod]
        public void RegisterUser_ValidUser_ShouldAddSuccessfully()
        {
            var fakeDataService = new FakeDataService();
            var userService = new UserService(fakeDataService);

            userService.RegisterUser("testUser", "securePass", "test@example.com");

            var user = fakeDataService.userRepo.GetUserByUsername("testUser");
            Assert.IsNotNull(user);
            Assert.AreEqual("testUser", user.Username);
            Assert.AreEqual("securePass", user.Password);
            Assert.AreEqual("test@example.com", user.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_EmptyUsername_ShouldThrowException()
        {
            var fakeDataService = new FakeDataService();
            var userService = new UserService(fakeDataService);

            userService.RegisterUser("", "securePass", "test@example.com");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterUser_DuplicateUsername_ShouldThrowException()
        {
            var fakeDataService = new FakeDataService();
            var userService = new UserService(fakeDataService);

            userService.RegisterUser("testUser", "securePass", "test@example.com");
            userService.RegisterUser("testUser", "anotherPass", "another@example.com");
        }

        [TestMethod]
        public void RemoveUser_ExistingUser_ShouldRemoveSuccessfully()
        {
            var fakeDataService = new FakeDataService();
            var userService = new UserService(fakeDataService);

            userService.RegisterUser("testUser", "securePass", "test@example.com");
            userService.RemoveUser("testUser");

            var user = fakeDataService.userRepo.GetUserByUsername("testUser");
            Assert.IsNull(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveUser_NonExistingUser_ShouldThrowException()
        {
            var fakeDataService = new FakeDataService();
            var userService = new UserService(fakeDataService);

            userService.RemoveUser("nonexistentUser");
        }

        [TestMethod]
        public void IsUserRegistered_ExistingUser_ShouldReturnTrue()
        {
            var fakeDataService = new FakeDataService();
            var userService = new UserService(fakeDataService);

            userService.RegisterUser("testUser", "securePass", "test@example.com");

            Assert.IsTrue(userService.IsUserRegistered("testUser"));
        }

        [TestMethod]
        public void IsUserRegistered_NonExistingUser_ShouldReturnFalse()
        {
            var fakeDataService = new FakeDataService();
            var userService = new UserService(fakeDataService);

            Assert.IsFalse(userService.IsUserRegistered("nonexistentUser"));
        }
    }
}