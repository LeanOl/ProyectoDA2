import { CartProduct } from "./cart-product.model";

export interface PurchaseRes{
  purchaseId: string;
  userId: string;
  products: CartProduct[];
  totalPrice: number;
  totalDiscount: number;
  finalPrice: number;
  promotionName: string;
  paymentMethod: string;
  date: Date;
}
