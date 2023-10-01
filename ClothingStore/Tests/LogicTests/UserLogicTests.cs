using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Data.Interfaces;
using Logic.Interfaces;
using Logic.Concrete;

namespace Tests.LogicTests
{
    [TestClass]
    public class UserLogicTests
    {
        [TestMethod]
        public void CreateNewUserOk()
        {
            var expected = new User(
                    "test@test.com",
                    "ADMIN",
                    "Cuareim 1234"
                );
            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<User>())).Returns(expected);
            IUserLogic logic = new UserLogic(mockRepo.Object);

            // Act
            User result = logic.CreateUser(expected);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
