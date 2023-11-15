import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PurchaseRes } from 'src/app/models/purchase-res.model';
import { PurchaseService } from 'src/app/services/purchase.service';

@Component({
  selector: 'app-purchase-list',
  templateUrl: './purchase-list.component.html',
  styleUrls: ['./purchase-list.component.css'],
})
export class PurchaseListComponent {
  @Input() viewAll: boolean = true;
  @Input() userId: string = '';
  purchases: PurchaseRes[] = [];

  constructor(private purchaseService: PurchaseService,private route:ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      if(params['userId']){
        this.viewAll=false;
        this.userId = params['userId'];
      }
    });

    if(this.viewAll){
    this.purchaseService.getAllPurchases().subscribe((purchases) => {
      this.purchases = purchases;
    });
    }else{
      this.purchaseService.getPurchasesByUserId(this.userId).subscribe((purchases) => {
        this.purchases = purchases;
      });
    }
  }
}
