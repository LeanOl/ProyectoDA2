import { Product } from './product.model';

export interface CartProduct {
  productId: string;
  quantity: number;
  product:Product;
}
