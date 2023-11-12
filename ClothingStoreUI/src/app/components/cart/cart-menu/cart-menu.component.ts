import { Component } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart-menu',
  templateUrl: './cart-menu.component.html',
  styleUrls: ['./cart-menu.component.css']
})
export class CartMenuComponent {

  cart = this.cartService.getCart();
  successfulPurchase: boolean = false;
  showCartUpdate: boolean = false;
  cartUpdatedCorrectly: boolean = false;

  constructor(private cartService: CartService) { }

  onItemUpdated(success: boolean): void {
    if (success) {
      this.cart = this.cartService.getCart();
      this.cartUpdatedCorrectly = true;
      this.showCartUpdate = true;
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
