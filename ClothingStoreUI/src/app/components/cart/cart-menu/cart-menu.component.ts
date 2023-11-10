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

  constructor(private cartService: CartService) { }

  onItemUpdated(success: boolean): void {
    if (success) {
      this.cart = this.cartService.getCart();
      alert("Success");
    }else
    {
      alert("Error");
    }
  }

}
