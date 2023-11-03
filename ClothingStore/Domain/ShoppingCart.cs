﻿using System.ComponentModel.DataAnnotations;

namespace Domain
{

    public class ShoppingCart
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<ShoppingCartProducts>? ShoppingCartProducts { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? FinalPrice { get; set; }
        public decimal? Discount { get; set; }
        public string? PromotionName { get; set; }

        public ShoppingCart()
        {
        }

        public ShoppingCart(Guid idusuario, List<ShoppingCartProducts> productList)
        {
            Id = Guid.NewGuid();
            UserId = idusuario;
            ShoppingCartProducts = productList;
        }

        public List<Product> GetProducts ()
        {
            if (ShoppingCartProducts == null || ShoppingCartProducts.Count == 0)
            {
                return new List<Product>();
            }

            var products = new List<Product>();
            foreach (var product in ShoppingCartProducts)
            {
                for (int i = 0; i < product.Quantity; i++)
                {
                    products.Add(product.Product);
                }
            }
            return products;
        }

        public void UpdatePrices()
        {
            TotalPrice = GetTotalPrice();
            FinalPrice = GetFinalPrice();
        }

        private decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var product in ShoppingCartProducts)
            {
                totalPrice += product.Product.Price * product.Quantity;
            }
            return totalPrice;
        }

        private decimal GetFinalPrice()
        {
            if (Discount == null)
            {
                return TotalPrice ?? 0;
            }
            var finalPrice = (TotalPrice ?? 0) - (Discount ?? 0);
            return finalPrice ;
        }
    }
}