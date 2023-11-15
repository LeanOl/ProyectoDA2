import { Component, Input, NgModule } from '@angular/core';
import { PurchaseRes } from 'src/app/models/purchase-res.model';

@Component({
  selector: 'app-purchase-item',
  templateUrl: './purchase-item.component.html',
  styleUrls: ['./purchase-item.component.css'],
})
export class PurchaseItemComponent {
  @Input() purchase: PurchaseRes = {} as PurchaseRes;
  isCollapsed = true;
  constructor() {}
}
