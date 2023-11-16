export interface ProductCreateRequest {
    name: string;
    price: number;
    description: string;
    brand: string;
    category: string;
    colors: string[];
    stock: number;
    excluded:boolean;
}
