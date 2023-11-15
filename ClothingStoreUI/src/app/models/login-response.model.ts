import { Cart } from "./cart.model";

export interface LoginResponse{
    userId?: string;
    token?: string;
    email?: string;
    role?: string;
    cart?: Cart;
}
