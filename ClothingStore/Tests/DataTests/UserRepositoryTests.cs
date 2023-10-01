using Data.Concrete;
using Domain;

namespace Tests.DataTests
{
    [TestClass]
    public class UserRepositoryTests : ContextInMemory
    {
        [TestMethod]
        public void AddUser()
        {
            // Arrange
            var dbContext = createDbContext("AddUser");
            var userManagement = new UserManagement(dbContext);
            var expected = new User(
                "test@test.com",
                "ADMIN",
                "Cuareim 1234"
            );

            // Act
            var result = userManagement.Insert(expected);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            // Arrange
            var dbContext = createDbContext("GetAllUsers");
            var userManagement = new UserManagement(dbContext);
            var expected = new User(
                "test@test.com",
                "ADMIN",
                "Cuareim 1234"
            );
            dbContext.Set<User>().Add(expected);
            dbContext.SaveChanges();
            // Act
            var result = userManagement.GetAll<User>();
            // Assert
            Assert.AreEqual(expected, result.First());
        }
    }
}
