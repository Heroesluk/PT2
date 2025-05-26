using PT2.data;
using PT2.data.API;

namespace TestDataLayer
{
    [TestClass]
    public class UserRepositoryTests
    {
        private UserRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new UserRepository(new DataContext());
            _repository.AddUser(new User(0, "user1", "pass1", "user1@test.com"));
            _repository.AddUser(new User(1, "user2", "pass2", "user2@test.com"));
        }

        [TestMethod]
        public void GetUserByUsername_ExistingUser_ReturnsCorrectUser()
        {
            var expectedUsername = "user1";

            var result = _repository.GetUserByUsername(expectedUsername);

            Assert.AreEqual(expectedUsername, result.Username);
        }

        [TestMethod]
        public void GetUserByUsername_NonExistingUser_ThrowsException()
        {
            var usernameToFind = "nonexistent";

            Assert.ThrowsException<InvalidOperationException>(
                () => _repository.GetUserByUsername(usernameToFind)
            );
        }

        [TestMethod]
        public void AddUser_AutoNumbering_CorrectAssoc()
        {
            _repository.AddUser(new User(-1, "Test", "qwerty", "e@e.local"));

            IUser testUser = _repository.GetUserByUsername("Test");

            Assert.AreEqual(2, testUser.Id); // Assuming IDs are auto-incremented starting from 0
        }
    }
}
