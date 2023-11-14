import { Component, EventEmitter, Output } from '@angular/core';
import { Cart } from 'src/app/models/cart.model';
import { Product } from 'src/app/models/product.model';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart-menu',
  templateUrl: './cart-menu.component.html',
  styleUrls: ['./cart-menu.component.css']
})
export class CartMenuComponent {

  @Output() cartUpdated = new EventEmitter<Cart>();
  cart: Cart = {} as Cart;
  successfulPurchase: boolean = false;
  showCartUpdate: boolean = false;
  cartUpdatedCorrectly: boolean = false;

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.cart = this.cartService.getCart();
  }
    
  onItemUpdated(success: boolean): void {
    if (success) {
      this.cart = this.cartService.getCart();
      this.cartUpdatedCorrectly = true;
      this.showCartUpdate = true;
      this.cartUpdated.emit(this.cart);
      setTimeout(() => {
        this.showCartUpdate = false;
      }, 3000);
    }else
    {
      this.cartUpdatedCorrectly = false;
      this.showCartUpdate = true;
      setTimeout(() => {
        this.showCartUpdate = false;
      }, 3000);
    }
  }

  onPurchase(succcess:boolean): void {
    if (succcess) {
      this.successfulPurchase = true;
    }
  }
}
