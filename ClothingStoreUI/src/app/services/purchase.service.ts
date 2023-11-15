import { Injectable } from '@angular/core';
import { CartService } from './cart.service';
import { PurchaseRes } from '../models/purchase-res.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PurchaseService {
  constructor(
    private cartService: CartService,
    private httpClient: HttpClient
  ) {}

  purchaseUrl = environment.apiUrl + environment.purchaseEndpoint;

  makePurchase(paymentMethod: string): Observable<PurchaseRes> {
    const purchaseReq = {
      userId: this.cartService.getCart().userId,
      paymentMethod: paymentMethod,
    };
    return this.httpClient.post<PurchaseRes>(this.purchaseUrl, purchaseReq);
  }

  getAllPurchases(): Observable<PurchaseRes[]> {
    return this.httpClient.get<PurchaseRes[]>(this.purchaseUrl);
  }

  getPurchasesByUserId(userId: string): Observable<PurchaseRes[]> {
    return this.httpClient.get<PurchaseRes[]>(
      this.purchaseUrl + '/' + userId
    );
  }

}
