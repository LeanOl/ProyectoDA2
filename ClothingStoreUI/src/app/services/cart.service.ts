import { Injectable } from '@angular/core';
import { Cart } from '../models/cart.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product.model';
import { Observable, catchError, map, of, tap } from 'rxjs';
import { CartProduct } from '../models/cart-product.model';

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
    if (cart.products.some(p => p.productId == product.id)) {
      let productInCart = cart.products.find(p => p.productId === product.id);
      if (productInCart) {
        productInCart.quantity++;
      }
    }else {
      cart.products.push({ productId: product.id, quantity: 1 ,product:product});
    }
    return this.updateCart(cart);

  }

  updateCart(cart: Cart): Observable<Cart> {
    return this.httpClient.put<Cart>(this.cartUrl, cart).pipe(
      tap(updatedCart => this.setCart(updatedCart))
    );
  }

  decreaseQuantity(product: CartProduct): Observable<boolean> {
    let cartItem = localStorage.getItem('cart');
    let cart: Cart = cartItem ? JSON.parse(cartItem) : { products: [] };
    let productInCart = cart.products.find(p => p.productId === product.productId);
    if (productInCart) {
      productInCart.quantity--;
      if (productInCart.quantity === 0) {
        return this.deleteProduct(product);
      }
      return this.updateCart(cart).pipe(
        map(() => true),
        catchError(error => {
          console.error(error);
          return of(false);
        })
      );
    }
    return of(false);
  }

  increaseQuantity(product: CartProduct): Observable<boolean> {
    let cartItem = localStorage.getItem('cart');
    let cart: Cart = cartItem ? JSON.parse(cartItem) : { products: [] };
    let productInCart = cart.products.find(p => p.productId === product.productId);
    if (productInCart) {
      productInCart.quantity++;
      return this.updateCart(cart).pipe(
        map(() => true),
        catchError(error => {
          console.error(error);
          return of(false);
        })
      );
    }
    return of(false);
  }

  removeFromCart(product: CartProduct): Observable<boolean> {
    return this.deleteProduct(product);
  }
  deleteProduct(product: CartProduct): Observable<boolean> {
    let productId = product.productId;
    let cartItem = localStorage.getItem('cart');
    let cart: Cart = cartItem ? JSON.parse(cartItem) : { products: [] };
    console.log(cart);
    cart.products = cart.products.filter(p => p.productId !== product.productId);
    const options ={
      body: {
        cart: cart,
        productId: productId,
      }
    };
    return this.httpClient.delete<Cart>(this.cartUrl,options).pipe(
      tap((updatedCart) => {
        this.setCart(updatedCart);
      }),
      map(() => true),
      catchError(error => {
        console.error(error);
        return of(false);
      })
    );
  }

  getCart(): Cart {
    return JSON.parse(localStorage.getItem('cart') || '{ products: [] }');
  }

}
