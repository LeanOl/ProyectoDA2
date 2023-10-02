using APIModels.InputModels;
using APIModels.OutputModels;
using Domain;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace Tests.WebApiTests
{
    [TestClass]
    public class UserControllerTests
    {
        private UserRequest _receivedUserRequest;
        private User _user;

        [TestInitialize]
        public void Initialize()
        {
            _receivedUserRequest = new UserRequest(
                    "test@test.com",
                    "ADMIN",
                    "Cuareim 1234"
                );
            _user = new User(
                    "test@test.com",
                    "ADMIN",
                    "Cuareim 1234"
                );

        }

        [TestCleanup]
        public void Cleanup()
        {
            _receivedUserRequest = null;
        }

        [TestMethod]
        public void CreatUserOk()
        {
            // Arrange
            var expectedMappedResult = new UserResponse(_user);
            Mock<IUserLogic> logic = new Mock<IUserLogic>(MockBehavior.Strict);
            logic.Setup(l => l.CreateUser(It.IsAny<UserRequest>())).Returns(expectedMappedResult);
            UserController controller = new UserController(logic.Object);
            CreatedAtActionResult expectedObjectResult = new CreatedAtActionResult("CreateUser", "CreateUser",
                new { id = 5 }, expectedMappedResult);

            // Act
            IActionResult result = controller.CreateUser(_receivedUserRequest);

            // Assert
            logic.VerifyAll();
            CreatedAtActionResult resultObject = result as CreatedAtActionResult;
            UserResponse resultValue = resultObject.Value as UserResponse;
            Assert.AreEqual(expectedObjectResult.StatusCode, resultObject.StatusCode);
            Assert.AreEqual(expectedMappedResult, resultValue);
        }

        [TestMethod]
        public void GetAllUsersOk()
        {
            // Arrange
            ICollection<UserResponse> expected = new List<UserResponse>
            {
                new UserResponse(_user)
            };

            var expectedMappedResult = expected.Select(u => u);
            Mock<IUserLogic> logic = new Mock<IUserLogic>(MockBehavior.Strict);
            logic.Setup(l => l.GetAllUsers()).Returns(expected);
            UserController controller = new UserController(logic.Object);
            OkObjectResult expectedObjectResult = new OkObjectResult(expectedMappedResult);

            // Act
            IActionResult result = controller.GetAllUsers();

            // Assert
            logic.VerifyAll();
            OkObjectResult resultObject = result as OkObjectResult;
            IEnumerable<UserResponse> resultValue = resultObject.Value as List<UserResponse>;
            Assert.AreEqual(expectedObjectResult.StatusCode, resultObject.StatusCode);
            CollectionAssert.AreEquivalent(expectedMappedResult.ToList(), resultValue.ToList());
        }

    }
}
