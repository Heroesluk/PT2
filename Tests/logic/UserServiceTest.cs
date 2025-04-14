using PT2.logic.services;
using Tests.logic.helper;

namespace Tests.logic
{
    [TestClass]
    public class UserServiceTests
    {

        [TestMethod]
        public void RegisterUser_ValidUser_ShouldAddSuccessfully()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);

            userService.RegisterUser("testUser", "securePass", "test@example.com");

            var user = fakeRepository.GetUserByUsername("testUser");
            Assert.IsNotNull(user);
            Assert.AreEqual("testUser", user.Username);
            Assert.AreEqual("securePass", user.Password);
            Assert.AreEqual("test@example.com", user.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterUser_EmptyUsername_ShouldThrowException()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);

            userService.RegisterUser("", "securePass", "test@example.com");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterUser_DuplicateUsername_ShouldThrowException()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);

            userService.RegisterUser("testUser", "securePass", "test@example.com");
            userService.RegisterUser("testUser", "anotherPass", "another@example.com");
        }

        [TestMethod]
        public void RemoveUser_ExistingUser_ShouldRemoveSuccessfully()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);

            userService.RegisterUser("testUser", "securePass", "test@example.com");
            userService.RemoveUser("testUser");

            var user = fakeRepository.GetUserByUsername("testUser");
            Assert.IsNull(user);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveUser_NonExistingUser_ShouldThrowException()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);

            userService.RemoveUser("nonexistentUser");
        }

        [TestMethod]
        public void IsUserRegistered_ExistingUser_ShouldReturnTrue()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);

            userService.RegisterUser("testUser", "securePass", "test@example.com");

            Assert.IsTrue(userService.IsUserRegistered("testUser"));
        }

        [TestMethod]
        public void IsUserRegistered_NonExistingUser_ShouldReturnFalse()
        {
            var fakeRepository = new FakeUserRepository();
            var userService = new UserService(fakeRepository);

            Assert.IsFalse(userService.IsUserRegistered("nonexistentUser"));
        }
    }
}