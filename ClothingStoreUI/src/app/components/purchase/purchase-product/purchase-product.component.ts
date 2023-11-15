import { Component, Input } from '@angular/core';
import { CartProduct } from 'src/app/models/cart-product.model';


@Component({
  selector: 'app-purchase-product',
  templateUrl: './purchase-product.component.html',
  styleUrls: ['./purchase-product.component.css']
})
export class PurchaseProductComponent {
  @Input () product: CartProduct = {} as CartProduct;
}
