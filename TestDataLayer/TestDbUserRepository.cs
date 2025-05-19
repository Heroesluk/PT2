using Microsoft.EntityFrameworkCore;
using PT2.data;
using PT2.data.API;

namespace TestDataLayer
{
    [TestClass]
    public class UserDbRepositoryTests
    {
        private TestDbContext _dbContext;
        private UserDbRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new TestDbContext(options);
            _repository = new UserDbRepository(_dbContext);

            // Seed data
            _dbContext.Users.Add(new User(1, "user1", "pass1", "user1@test.com"));
            _dbContext.Users.Add(new User(2, "user2", "pass2", "user2@test.com"));
            _dbContext.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [TestMethod]
        public void GetUserByUsername_ExistingUser_ReturnsCorrectUser()
        {
            var result = _repository.GetUserByUsername("user1");

            Assert.IsNotNull(result);
            Assert.AreEqual("user1", result.Username);
        }

        [TestMethod]
        public void GetUserByUsername_NonExistingUser_ReturnsNull()
        {
            var result = _repository.GetUserByUsername("nonexistent");

            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAllUsers_ReturnsAllUsers()
        {
            var result = _repository.GetAllUsers();

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void AddUser_ValidUser_AddsSuccessfully()
        {
            var newUser = new User(3, "user3", "pass3", "user3@test.com");

            _repository.AddUser(newUser);

            var result = _repository.GetUserByUsername("user3");
            Assert.IsNotNull(result);
            Assert.AreEqual("user3", result.Username);
        }

        [TestMethod]
        public void AddUser_DuplicateUsername_ThrowsException()
        {
            var duplicateUser = new User(1, "user1", "pass1", "user1@test.com");

            Assert.ThrowsException<InvalidOperationException>(() => _repository.AddUser(duplicateUser));
        }

        [TestMethod]
        public void DeleteUserByUsername_ExistingUser_DeletesSuccessfully()
        {
            var result = _repository.DeleteUserByUsername("user1");

            Assert.IsTrue(result);
            Assert.IsNull(_repository.GetUserByUsername("user1"));
        }

        [TestMethod]
        public void DeleteUserByUsername_NonExistingUser_ThrowsException()
        {
            Assert.ThrowsException<InvalidOperationException>(() => _repository.DeleteUserByUsername("nonexistent"));
        }
    }
}