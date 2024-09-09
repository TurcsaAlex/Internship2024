export type Container={
    containerId: number,
    uomId: any,
    containerTypeId:string,
    containerType:string,
    containerCode:string,
    name: string,
    quantity: number,
    active: boolean,
    uomName:string,
    productCode:string,
    productId:number|undefined,
    containerTypeName:string,
}
export type ContainerType={
    containerTypeId:number;
    containerTypeName:string;
}