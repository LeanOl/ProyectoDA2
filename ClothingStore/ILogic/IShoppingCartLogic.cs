﻿using APIModels.InputModels;
using Domain;

namespace ILogic
{

    public interface IShoppingCartLogic
    {
        void ApplyBestPromotion(ShoppingCart shoppingCart);
        ShoppingCart CreateShoppingCart(ShoppingCartRequest received);
    }
}