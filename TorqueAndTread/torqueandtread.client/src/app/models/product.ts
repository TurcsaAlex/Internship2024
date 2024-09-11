export type Product = {
    productId: number;
    name: string;
    productCodeName: string;
    active: boolean;
    createdOn: string;
    lastUpdatedOn: string;
    productTypeName: string;
    productType:any;
    uomName:string;
    defaultUOM:any;
    productTypeId:number;
    uomId:number;
    quantity:number|null;
};

export type ProductType={
    productTypeId:number;
    productTypeName:string;
}

export type UOM={
    uomId:number;
    uomName:string;
}

