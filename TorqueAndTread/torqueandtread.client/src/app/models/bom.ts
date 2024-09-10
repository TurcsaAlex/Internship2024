export type BOM={
    bomId :number,
    bomName :string,
    materialId :number|undefined,
    bomCode :string,
    Active :Boolean,
    CreatedOn :string,
    LastUpdatedOn :string,
    productId:number|undefined,
    materialCode:string
}

export type ProductBOM={
    bomId :number,
    quantity:number,
    productId:number
}

