import { SafeUrl } from "@angular/platform-browser";

export interface ProductDto {
    
    entities: any[];
    product: SafeUrl;
    id:number,
    name:string,
    nameAr:string,
    nongDescription:string,
    shortDescription:string,
    stockQuantity:number,
    realPrice:number,
    discount:number,
    images:SafeUrl[],
    subCategoryId:number,
    brandId:number,
    addedToCart?: boolean,
    cartQuantity:number
    addedTowashlist?: boolean,
    brandName:string
    prodcutid:string
}
