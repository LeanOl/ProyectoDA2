import { Injectable } from '@angular/core';
import { Cart } from '../models/cart.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product.model';
import { Observable, catchError, map, of, tap } from 'rxjs';
import { CartProduct } from '../models/cart-product.model';
import { PurchaseRes } from '../models/purchase-res.model';
import { SessionService } from './session.service';

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

    let cart = this.getCart();
    if (cart.products.some(p => p.productId == product.id)) {
      let productInCart = cart.products.find(p => p.productId === product.id);
      if (productInCart) {
        productInCart.quantity++;
      }
    }else {
      cart.products.push({ productId: product.id, quantity: 1 ,product:product});
    }
    if(this.isLogged()){
      return this.addToCartLogged(cart);
    }else{
      return this.updateCartNotLogged(cart);
    }
  }

  decreaseQuantity(product: CartProduct): Observable<boolean> {
    let cart = this.getCart();
    let productInCart = cart.products.find(p => p.productId === product.productId);
    if (productInCart) {
      productInCart.quantity--;
      if (productInCart.quantity === 0) {
        return this.deleteProduct(product);
      }
      if(this.isLogged()){
        return this.decreaseQuantityLogged(cart);
      }else{
        this.updateCartNotLogged(cart);
        return of(true);
      }

    }
    return of(false);
  }

  increaseQuantity(product: CartProduct): Observable<boolean> {
    let cartItem = localStorage.getItem('cart');
    let cart: Cart = cartItem ? JSON.parse(cartItem) : { products: [] };
    let productInCart = cart.products.find(p => p.productId === product.productId);
    if (productInCart) {
      productInCart.quantity++;
      if(this.isLogged()){
        return this.increaseQuantityLogged(cart);
      }
      else{
        this.updateCartNotLogged(cart);
        return of(true);
      }
    }
    return of(false);
  }

  removeFromCart(product: CartProduct): Observable<boolean> {
    return this.deleteProduct(product);
  }
  deleteProduct(product: CartProduct): Observable<boolean> {
    let productId = product.productId;
    let cart = this.getCart();
    cart.products = cart.products.filter(p => p.productId !== product.productId);

    if(this.isLogged()){
      return this.deleteProductLogged(productId,cart);
    }
    else{
      this.updateCartNotLogged(cart);
      return of(true);
    }
  }

  getCart(): Cart {
    let cart = localStorage.getItem('cart');
    let parsedCart: Cart;
    if (!cart) {
      parsedCart = { id: '', userId: '', products: [], totalPrice: 0, discount: 0, finalPrice: 0, promotionName: ''};
    } else {
      parsedCart = JSON.parse(cart);
    }
    return parsedCart;
  }
  clearLocalCartProducts(): void {
    let cart =localStorage.getItem('cart');
    if(cart){
      let cartObj:Cart = JSON.parse(cart);
      cartObj.products = [];
      cartObj.totalPrice = 0;
      cartObj.discount = 0;
      cartObj.finalPrice = 0;
      cartObj.promotionName = "";
      this.setCart(cartObj);
    }
  }



  fuseCarts(cart:Cart): Observable<Cart> {
    let localCart = this.getCart();
    let fusedCart:Cart;
    localCart.products.forEach(product => {
      if(cart.products.some(p => p.productId == product.productId)){
        let productInCart = cart.products.find(p => p.productId === product.productId);
        if (productInCart) {
          productInCart.quantity += product.quantity;
        }
      }else{
        cart.products.push(product);
      }
    });
    fusedCart = cart;
    return this.updateCart(fusedCart);
  }
  private updateCart(cart: Cart): Observable<Cart> {
    return this.httpClient.put<Cart>(this.cartUrl, cart).pipe(
      tap(updatedCart => this.setCart(updatedCart))
    );
  }

  private addToCartLogged(cart: Cart): Observable<Cart> {
    return this.updateCart(cart);
  }

  private updateCartNotLogged(cart: Cart): Observable<Cart> {
    this.setCart(cart);
    return of(cart);
  }

  private decreaseQuantityLogged(cart: Cart): Observable<boolean> {
    return this.updateCart(cart).pipe(
      map(() => true),
      catchError(error => {
        console.error(error);
        return of(false);
      })
    );
  }

  private increaseQuantityLogged(cart: Cart): Observable<boolean> {
    return this.updateCart(cart).pipe(
      map(() => true),
      catchError(error => {
        console.error(error);
        return of(false);
      })
    );
  }

  private deleteProductLogged(productId:String, cart:Cart): Observable<boolean> {
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

  private isLogged(): boolean {
    return localStorage.getItem('token') !== null;
  }
}
