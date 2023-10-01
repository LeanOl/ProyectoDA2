using System.Linq.Expressions;
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

        [TestMethod]
        public void GetAllUsersByCondition()
        {
            // Arrange
            var dbContext = createDbContext("GetAllUsersByCondition");
            var userManagement = new UserManagement(dbContext);
            var email = "test@test.com";
            var expected = new User(
                email,
                "ADMIN",
                "Cuareim 1234"
            );

            Func<User, bool> searchCondition = user =>
                user.GetType().GetProperty("Email")?.GetValue(user)?.ToString() == email;

            dbContext.Set<User>().Add(expected);
            dbContext.SaveChanges();
            // Act
            var result = userManagement.GetAll<User>(searchCondition);
            // Assert
            Assert.AreEqual(expected, result.First());
        }

        [TestMethod]
        public void UpdateUser()
        {
            // Arrange
            var dbContext = createDbContext("UpdateUser");
            var userManagement = new UserManagement(dbContext);
            var expected = new User(
                "test@test.com",
                "ADMIN",
                "Cuareim 1234"
            );

            // Act
            userManagement.Insert(expected);

            var address = "Paraguay 3131";
            expected.DeliveryAddress = address;

            var result = userManagement.Update(expected);

            // Assert
            Assert.AreEqual(address, result.DeliveryAddress);
        }

        [TestMethod]
        public void DeleteUser()
        {
            // Arrange
            var dbContext = createDbContext("DeleteUser");
            var userManagement = new UserManagement(dbContext);
            var expected = new User(
                "test@test.com",
                "ADMIN",
                "Cuareim 1234"
            );

            // Act
            userManagement.Insert(expected);
            userManagement.Delete(expected);

            var result = userManagement.GetAll<User>();
            // Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetUser()
        {
            // Arrange
            var dbContext = createDbContext("GetUser");
            var userManagement = new UserManagement(dbContext);
            var email = "test@test.com";
            var expected = new User(
                email,
                "ADMIN",
                "Cuareim 1234"
            );

            Expression<Func<User, bool>> searchCondition = user => user.Email == email;

            dbContext.Set<User>().Add(expected);
            dbContext.SaveChanges();
            // Act
            var result = userManagement.Get(searchCondition);
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
