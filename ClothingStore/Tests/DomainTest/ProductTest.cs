using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Tests.DomainTest
{

    [TestClass]
    public class ProductTest
    {
       

        [TestMethod]
        public void SetsGuidNotNull() {
            Product product = new Product();

            Assert.AreNotEqual(Guid.Empty,product.Id);
                
        }

        public void createsProductCorrect() {
            
            string name = "TestProduct";
            decimal price = 99.99M;
            string description = "This is a test product";
            string brand = "TestBrand";
            string category = "TestCategory";
            List<ProductColor> colors = new List<ProductColor>
            {
                new ProductColor { Color = "Red" },
                new ProductColor { Color = "Blue" }
            };
            int stock = 100;
            bool excluded = false;

            Product product = new Product(name, price, description, brand, category, colors, stock, excluded);

            Assert.AreNotEqual(Guid.Empty, product.Id);
            Assert.AreEqual(name, product.Name);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(description, product.Description);
            Assert.AreEqual(brand, product.Brand);
            Assert.AreEqual(category, product.Category);
            Assert.AreEqual(colors, product.Colors);
            Assert.AreEqual(stock, product.Stock);
            Assert.AreEqual(excluded, product.Excluded);

        }

    }
}
