import { Component, Input } from '@angular/core';
import { PurchaseRes } from 'src/app/models/purchase-res.model';
import { PurchaseService } from 'src/app/services/purchase.service';

@Component({
  selector: 'app-purchase-list',
  templateUrl: './purchase-list.component.html',
  styleUrls: ['./purchase-list.component.css'],
})
export class PurchaseListComponent {
  purchases: PurchaseRes[] = [];

  constructor(private purchaseService: PurchaseService) {}

  ngOnInit(): void {
    this.purchaseService.getAllPurchases().subscribe((purchases) => {
      this.purchases = purchases;
    });
  }
}
