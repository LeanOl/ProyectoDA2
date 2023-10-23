import { Component } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { Input } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css'],
})
export class ProductDetailComponent {
  product: Product;

  constructor(private productService: ProductService) {
    this.product = {
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

  ngOnInit(): void {
    this.product = this.productService.getActiveProduct();
  }
}
