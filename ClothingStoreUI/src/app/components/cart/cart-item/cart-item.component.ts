import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { CartProduct } from 'src/app/models/cart-product.model';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.css']
})
export class CartItemComponent {

  @Input() item: CartProduct;

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

  decreaseQuantity(item:CartProduct): Observable<boolean> {
    return this.cartService.decreaseQuantity(item)
  }

  increaseQuantity(item:CartProduct): Observable<boolean> {
    return this.cartService.increaseQuantity(item)
  }

  removeFromCart(item:CartProduct): Observable<boolean> {
    return this.cartService.removeFromCart(item)
  }
}
