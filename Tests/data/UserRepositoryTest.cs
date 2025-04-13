using PT2.data.model;
using PT2.data.repository;

namespace Tests.data
{
    [TestClass]
    public class UserRepositoryTests
    {
        //private User CreateTestUser(string username = "testuser", string password = "password", string email = "test@example.com")
        //{
        //    return new User(1, username, password, email);
        //}

        [TestMethod]
        public void GetUserByUsername_ExistingUser_ReturnsCorrectUser()
        {
            var repository = new UserRepository(new DataContext());
            var user1 = new User(0, "user1", "pass1", "user1@test.com");
            var user2 = new User(1, "user2", "pass2", "user2@test.com");
            repository.AddUser(user1);
            repository.AddUser(user2);
            var expectedUsername = "user1";

            var result = repository.GetUserByUsername(expectedUsername);

            Assert.AreSame(user1, result);
        }

        [TestMethod]
        public void GetUserByUsername_NonExistingUser_ThrowsException()
        {
            var repository = new UserRepository(new DataContext());
            var user1 = new User(0, "user1", "pass1", "user1@test.com");
            repository.AddUser(user1);
            var usernameToFind = "nonexistent";

            Assert.ThrowsException<InvalidOperationException>(
                () => repository.GetUserByUsername(usernameToFind)
            );
        }

        [TestMethod]
        public void AddUser_AutoNumbering_CorrectAssoc()
        {
            //preparation
            var repository = new UserRepository(new DataContext());

            int[] uIds = {5, 0, 3, 6};

            for (int i = 0; i < 4; i++)
            {
                repository.AddUser(new User(uIds[i], $"User{i}", "qwerty", "e@e.local"));
            }

            //test
            repository.AddUser(new User(-1, "Test", "qwerty", "e@e.local"));

            User testUser = repository.GetUserByUsername("Test");

            Assert.AreEqual(7, testUser.Id);

        }

    }
}
