import { Injectable } from '@angular/core';
import { Cart } from '../models/cart.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cartUrl = environment.apiUrl + environment.cartEndpoint;
  constructor(private httpClient:HttpClient) { }

  setCart(cart: Cart): void {
    localStorage.setItem('cart', JSON.stringify(cart));
  }

  addToCart(product: Product): Observable<Cart> {
    let cartItem = localStorage.getItem('cart');
    let cart: Cart = cartItem ? JSON.parse(cartItem) : { products: [] };
    if (cart.products.some(p => p.productId === product.id)) {
      let productInCart = cart.products.find(p => p.productId === product.id);
      if (productInCart) {
        productInCart.quantity++;
      }
    }else {
      cart.products.push({ productId: product.id, quantity: 1 ,product:product});
    }
    this.setCart(cart);
    return this.updateCart(cart);

  }

  updateCart(cart: Cart): Observable<Cart> {
    return this.httpClient.put<Cart>(this.cartUrl, cart);
  }
}
