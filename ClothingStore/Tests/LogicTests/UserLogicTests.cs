using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Data.Interfaces;
using Logic.Interfaces;
using Logic.Concrete;
using Exceptions.LogicExceptions;
using APIModels.InputModels;
using APIModels.OutputModels;

namespace Tests.LogicTests
{
    [TestClass]
    public class UserLogicTests
    {
        [TestMethod]
        public void CreateNewUserOk()
        {
            var userMock = new User(
                    "test@test.com",
                    "123",
                    "ADMIN",
                    "Cuareim 1234"
                );
            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            mockRepo.Setup(repo => repo.Insert(It.IsAny<User>())).Returns(userMock);
            IUserLogic logic = new UserLogic(mockRepo.Object);

            var expected = new UserRequest(
                    "test@test.com",
                    "123",
                    "ADMIN",
                    "Cuareim 1234"
                );

            // Act
            UserResponse result = logic.CreateUser(expected);

            // Assert
            Assert.AreEqual(expected.Email, result.Email);
            mockRepo.VerifyAll();
        }

        [TestMethod]
        public void CreateNewUserInvalidEmail()
        {
            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            IUserLogic logic = new UserLogic(mockRepo.Object);

            Assert.ThrowsException<InvalidFormatEmailException>(() =>
            {
                var expected = new UserRequest(
                    "test1est-com",
                    "123",
                    "ADMIN",
                    "Cuareim 1234"
                );

                // Act
                UserResponse result = logic.CreateUser(expected);
            });
        }

        [TestMethod]
        public void GetAllUsersOk()
        {
            var expected = new User(
                    "test@test.com",
                    "123",
                    "ADMIN",
                    "Cuareim 1234"
                );
            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            mockRepo.Setup(repo => repo.GetAll<User>()).Returns(new List<User> { expected });
            IUserLogic logic = new UserLogic(mockRepo.Object);

            // Act
            IEnumerable<UserResponse> result = logic.GetAllUsers();
            // Assert
            mockRepo.VerifyAll();
            Assert.AreEqual(expected.Email, result.First().Email);
        }

        [TestMethod]
        public void DeleteUserOk()
        {
            Guid id = Guid.NewGuid();
            var expected = new User(
                    "test@test.com",
                    "123",
                    "ADMIN",
                    "Cuareim 1234"
                );

            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            mockRepo.Setup(repo => repo.Get(p => p.Id == id, null)).Returns(expected);
            mockRepo.Setup(repo => repo.Delete(expected));

            IUserLogic logic = new UserLogic(mockRepo.Object);

            // Act
            logic.DeleteUser(id);

            // Assert
            mockRepo.VerifyAll();
        }

        [TestMethod]
        public void UpdateUserOk()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var userMock = new User(
                    "test@test.com",
                    "123",
                    "ADMIN",
                    "Cuareim 1234"
                );
            Mock<IGenericRepository<User>> mockRepo = new Mock<IGenericRepository<User>>();
            mockRepo.Setup(repo => repo.Get(p => p.Id == id, null)).Returns(userMock);
            mockRepo.Setup(repo => repo.Update(userMock)).Returns(userMock);
            UserLogic logic = new UserLogic(mockRepo.Object);

            var expected = new UserRequest(
                    "test@test.com",
                    "123",
                    "ADMIN",
                    "Cuareim 1234"
                );
            // Act
            UserResponse result = logic.UpdateUser(id, expected);
            // Assert
            mockRepo.VerifyAll();
            Assert.AreEqual(expected.Email, result.Email);
        }
    }
}
