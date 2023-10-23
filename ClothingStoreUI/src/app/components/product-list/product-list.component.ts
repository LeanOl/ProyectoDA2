import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';
@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css'],
})
export class ProductListComponent {
  products: Product[] = [];
  formInputFilter: string = '';
  constructor(private productService: ProductService) {}
  getProducts(): void {
    this.productService
      .getProducts()
      .subscribe((products) => (this.products = products));
  }
  getFilteredProducts(): void {
    this.productService.getFilteredProducts(this.formInputFilter)
    .subscribe(products => this.products = products);
  }
  ngOnInit(): void {
    this.getProducts();
  }



}
