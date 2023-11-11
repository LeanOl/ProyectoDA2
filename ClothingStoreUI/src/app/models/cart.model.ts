import { CartProduct } from "./cart-product.model";

export interface Cart {
    id: string;
    userId: string;
    products: CartProduct[];
    totalPrice: number;
    discount: number;
    finalPrice: number;
    promotionName: string;
}
