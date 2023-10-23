import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ProductService {

  private productUrl = 'https://localhost:7297/api/products';
  activeProduct: Product;
  constructor(private http: HttpClient) {
    this.activeProduct = {
      id: 'abcd',
      name: 'Default',
      price: 4,
      description: 'Default product',
      brand: 'Default brand',
      category: 'Default category',
      colors: ['Default color'],
      stock: 2,
    };
  }
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl);
  }
  getFilteredProducts(filter: string): Observable<Product[]> {
    return this.http.get<Product[]>(this.productUrl + '?filter=' + filter);
  }
  getActiveProduct(): Product {
    return this.activeProduct;
  }
  setActiveProduct(product: Product): void {
    this.activeProduct = product;
  }
}
