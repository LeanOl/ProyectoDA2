using APIModels.InputModels;
using Domain;
using Exceptions.LogicExceptions;
using IData;
using Logic;

namespace Tests.LogicTests;
[TestClass]
public class PurchaseLogicTests
{
    private List<ShoppingCartProducts> _userShoppingCartProducts;
    private ShoppingCart _userShoppingCart;
    private List<PurchaseProduct> _expectedPurchaseProducts;
    private Purchase _expectedPurchase;

    [TestInitialize]
    public void TestInitialize()
    {
        Guid userId = Guid.NewGuid();
        _userShoppingCartProducts = new List<ShoppingCartProducts>()
        {
            new ShoppingCartProducts()
            {
                ProductId = Guid.NewGuid(),
                Product = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "TestProduct1",
                    Price = 10,
                    Description = "TestDescription1",
                    Category = "TestCategory1"
                },
                ShoppingCartId = Guid.NewGuid(),
            }
        };

        _userShoppingCart = new ShoppingCart()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            ShoppingCartProducts = _userShoppingCartProducts,
            TotalPrice = 50,
            FinalPrice = 40,
            Discount = 10,
            PromotionName = null,
        };


        _expectedPurchaseProducts = new List<PurchaseProduct>()
        {
            new PurchaseProduct()
            {
                ProductId = _userShoppingCartProducts[0].ProductId,
                Product = _userShoppingCartProducts[0].Product,
                PurchaseId = Guid.NewGuid(),

            }
        };

        _expectedPurchase = new Purchase()
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Products = _expectedPurchaseProducts,
            TotalPrice = 50,
            FinalPrice = 40,
            Discount = 10,
            PromotionName = null,
        };
    }

    


    [TestMethod]
    public void CreatePurchase_Ok()
    {
        // Arrange
        Mock<IPurchaseManagement> mockPurchaseManagement = new Mock<IPurchaseManagement>(MockBehavior.Strict);
        Mock<IShoppingCartManagement> mockShoppingCartManagement = new Mock<IShoppingCartManagement>();
        mockShoppingCartManagement.Setup(x => x.GetShoppingCartByUserId(It.IsAny<Guid>())).Returns(_userShoppingCart);
        mockShoppingCartManagement.Setup(x => x.ClearShoppingCart(It.IsAny<ShoppingCart>()));
        mockPurchaseManagement.Setup(x => x.AddPurchase(It.IsAny<Purchase>())).Returns(_expectedPurchase);
        PurchaseLogic purchaseLogic = new PurchaseLogic(mockPurchaseManagement.Object, mockShoppingCartManagement.Object);
        
        // Act
        Purchase result=purchaseLogic.CreatePurchase(new PurchaseRequest() { UserId = _expectedPurchase.UserId });

        // Assert
        mockShoppingCartManagement.VerifyAll();
        mockPurchaseManagement.VerifyAll();
        Assert.AreEqual(_expectedPurchase, result);

    }

    [TestMethod]
    public void CreatePurchase_EmptyCart_ThrowException()
    {
        // Arrange
        Mock<IPurchaseManagement> mockPurchaseManagement = new Mock<IPurchaseManagement>(MockBehavior.Strict);
        Mock<IShoppingCartManagement> mockShoppingCartManagement = new Mock<IShoppingCartManagement>();
        mockShoppingCartManagement.Setup(x => x.GetShoppingCartByUserId(It.IsAny<Guid>())).Returns(new ShoppingCart());
        PurchaseLogic purchaseLogic = new PurchaseLogic(mockPurchaseManagement.Object, mockShoppingCartManagement.Object);

        // Act
        // Assert
        Assert.ThrowsException<EmptyProductsPurchaseException>(() => purchaseLogic.CreatePurchase(new PurchaseRequest() { UserId = _expectedPurchase.UserId }));
    }

    [TestMethod]
    public void GetAllPurchases_Ok()
    {
        // Arrange
        List<Purchase> expectedPurchases = new List<Purchase>
        {
            _expectedPurchase
        };
        Mock<IPurchaseManagement> mockPurchaseManagement = new Mock<IPurchaseManagement>(MockBehavior.Strict);
        Mock<IShoppingCartManagement> mockShoppingCartManagement = new Mock<IShoppingCartManagement>();
        mockPurchaseManagement.Setup(x => x.GetAllPurchases()).Returns(expectedPurchases);
        PurchaseLogic purchaseLogic = new PurchaseLogic(mockPurchaseManagement.Object, mockShoppingCartManagement.Object);

        // Act
        List<Purchase> result = purchaseLogic.GetAllPurchases().ToList();

        // Assert
        mockPurchaseManagement.VerifyAll();
        CollectionAssert.AreEquivalent(expectedPurchases, result);
        
    }

    [TestMethod]
    public void GetPurchasesByUser_Ok()
    {
        // Arrange
        List<Purchase> expectedPurchases = new List<Purchase>
        {
            _expectedPurchase
        };
        Mock<IPurchaseManagement> mockPurchaseManagement = new Mock<IPurchaseManagement>(MockBehavior.Strict);
        Mock<IShoppingCartManagement> mockShoppingCartManagement = new Mock<IShoppingCartManagement>();
        mockPurchaseManagement.Setup(x => x.GetPurchasesByUser(It.IsAny<Guid>())).Returns(expectedPurchases);
        PurchaseLogic purchaseLogic = new PurchaseLogic(mockPurchaseManagement.Object, mockShoppingCartManagement.Object);

        // Act
        List<Purchase> result = purchaseLogic.GetPurchasesByUser(_expectedPurchase.UserId).ToList();

        // Assert
        mockPurchaseManagement.VerifyAll();
        CollectionAssert.AreEquivalent(expectedPurchases, result);

    }

    
    
}