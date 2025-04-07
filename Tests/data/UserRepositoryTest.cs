using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using PT2.data;

namespace Tests.data 
{
    [TestClass]
    public class UserRepositoryTests
    {
        private User CreateTestUser(string username = "testuser", string password = "password", string email = "test@example.com")
        {
            return new User(username, password, email);
        }

        [TestMethod]
        public void GetUserByUsername_ExistingUser_ReturnsCorrectUser()
        {
            var repository = new UserRepository();
            var user1 = CreateTestUser("user1", "pass1", "user1@test.com");
            var user2 = CreateTestUser("user2", "pass2", "user2@test.com");
            repository.AddUser(user1);
            repository.AddUser(user2);
            var expectedUsername = "user1";

            var result = repository.GetUserByUsername(expectedUsername);

            Assert.AreSame(user1, result);
        }

        [TestMethod]
        public void GetUserByUsername_NonExistingUser_ThrowsException()
        {
            var repository = new UserRepository();
            var user1 = CreateTestUser("user1");
            repository.AddUser(user1);
            var usernameToFind = "nonexistent";

            Assert.ThrowsException<InvalidOperationException>(
                () => repository.GetUserByUsername(usernameToFind)
            );
        }

    }
}
