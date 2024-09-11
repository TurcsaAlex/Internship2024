import { Role } from "../../models/role";

export interface MenuItem{
    menuItemId:number;
    name: string;
    orderNo: number;
    iconClass : string;
    link : string;
    createdOn:string;
    lastUpdatedOn:string;
    roles : Role[];
}