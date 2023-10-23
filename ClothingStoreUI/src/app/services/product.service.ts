import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  private productUrl = 'https://localhost:7297/api/products';
  getProducts() : Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl);
  }
  getFilteredProducts(filter:string) : Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl + '?filter=' + filter);
  }
}
