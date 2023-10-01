using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Data.Interfaces;
using Logic.Interfaces;
using Logic.Concrete;
using Exceptions.LogicExceptions;

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

        [TestMethod]
        public void CreateNewUserInvalidEmail()
        {
            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            IUserLogic logic = new UserLogic(mockRepo.Object);

            Assert.ThrowsException<InvalidFormatEmailException>(() =>
            {
                var expected = new User(
                    "test1est-com",  // Este correo es inválido
                    "ADMIN",
                    "Cuareim 1234"
                );

                // Act
                User result = logic.CreateUser(expected);
            });
        }
    }
}
