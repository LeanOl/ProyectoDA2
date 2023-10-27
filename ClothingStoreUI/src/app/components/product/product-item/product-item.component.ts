import { Component, Input } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css'],
})

export class ProductItemComponent {
  @Input() product: Product;

  addToCart() {
    // Add product to cart
  }

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
  setActiveProduct() {
    this.productService.setActiveProduct(this.product);
  }
}
