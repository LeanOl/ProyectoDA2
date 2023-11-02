import { Cart } from "./cart.model";

export interface LoginResponse{
    token?: string;
    email?: string;
    role?: string;
    cart?: Cart;
}
