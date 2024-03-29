import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Cart } from 'src/app/models/cart.model';
import { CartService } from 'src/app/services/cart.service';
import { PurchaseService } from 'src/app/services/purchase.service';

@Component({
  selector: 'app-cart-info',
  templateUrl: './cart-info.component.html',
  styleUrls: ['./cart-info.component.css']
})
export class CartInfoComponent {
  @Output() purchaseSuccessful = new EventEmitter<boolean>();
  @Input() cart : Cart = {} as Cart;
  paymentMethod: string = "visa";
  showErrorMessage: boolean = false;

  constructor(private purchaseService: PurchaseService, private cartService:CartService) { }

  makePurchase(){
    this.purchaseService.makePurchase(this.paymentMethod).subscribe(
      {
        next: (res) => {
          this.cartService.clearLocalCartProducts();
          this.purchaseSuccessful.emit(true);
        },
        error: (err) => {
          this.showErrorMessage = true;
          setTimeout(() => {
            this.showErrorMessage = false;
          }, 3000);
        }
      }
    );
  }

}
