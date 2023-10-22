import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }
  private productUrl = 'http://localhost:7297/products';
  getProducts() : Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl);
  }
}
