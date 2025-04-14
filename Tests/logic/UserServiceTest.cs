using PT2.data.API.repository;
using PT2.DataModel;
using PT2.logic.services;

namespace Tests.logic
{
    [TestClass]
    public class UserServiceTests
    {
        private class FakeUserRepository : IUserRepository
        {
            private readonly Dictionary<string, IUser> _users = new Dictionary<string, IUser>();

            public IUser GetUserByUsername(string username)
            {
                _users.TryGetValue(username, out var user);
                return user;
            }

            public List<IUser> GetAllUsers()
            {
                return new List<IUser>(_users.Values);
            }

            public int AddUser(IUser user)
            {
                if (_users.ContainsKey(user.Username))
                    throw new InvalidOperationException("User already exists.");
                _users[user.Username] = user;
                return user.Id;
            }

            public bool DeleteUserByUsername(string username)
            {
                return _users.Remove(username);
            }
        }

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