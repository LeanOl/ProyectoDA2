import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { CartProduct } from 'src/app/models/cart-product.model';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent {

  @Input() item: CartProduct;
  @Output() itemUpdated = new EventEmitter<boolean>();

  constructor(private cartService: CartService) {
    this.item = {
      quantity : 0,
      productId : '',
      product : {
        id : '',
        name : '',
        description : '',
        price : 0,
        stock : 0,
        brand : '',
        category : '',
        colors : []
      }
    };
  }

  decreaseQuantity(item:CartProduct): void {
    this.cartService
      .decreaseQuantity(item)
      .pipe(tap((success) => this.itemUpdated.emit(success)))
      .subscribe();
  }

  increaseQuantity(item:CartProduct): void {
    this.cartService
      .increaseQuantity(item)
      .pipe(tap((success) => this.itemUpdated.emit(success)))
      .subscribe();
  }

  removeFromCart(item:CartProduct): void {
    this.cartService
      .removeFromCart(item)
      .pipe(tap((success) => this.itemUpdated.emit(success)))
      .subscribe();
  }
}
