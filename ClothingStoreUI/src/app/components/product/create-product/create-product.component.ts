import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { ProductCreateRequest } from 'src/app/models/product-create-request.model';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css'],
})
export class CreateProductComponent {
  productForm: FormGroup;
  showAlert: boolean = false;
  alertMessage: string = '';

  constructor(private fb: FormBuilder, private productService: ProductService) {
    this.productForm = this.fb.group({
      name: '',
      price: '',
      description: '',
      brand: '',
      category: '',
      stock: 1,
      excluded: false,
      colors: this.fb.array([]),
    });
  }

  get colors() {
    return this.productForm.get('colors') as FormArray;
  }

  addColor() {
    this.colors.push(this.fb.control(''));
  }
  getColorsFormArray(): FormArray {
    return this.productForm.get('colors') as FormArray;
  }
  removeColor(index: number) {
    this.colors.removeAt(index);
  }

  onSubmit() {
    let product :ProductCreateRequest = {
      name: this.productForm.value.name,
      price: this.productForm.value.price,
      description: this.productForm.value.description,
      brand: this.productForm.value.brand,
      category: this.productForm.value.category,
      colors: this.productForm.value.colors,
      stock: this.productForm.value.stock,
      excluded: this.productForm.value.excluded,
    }
    this.productService.createProduct(product).subscribe({
      next: (product: Product) => {
        this.showAlert = true;
        this.alertMessage = "Product created successfully!";
        this.productForm.reset();
        setTimeout(() => {
          this.showAlert = false;
        },2000)

      },
      error: (err) => {
        this.showAlert = true;
        this.alertMessage = "Error creating product!";
        setTimeout(() => {
          this.showAlert = false;
        },2000)
      },
    });
  }


}
