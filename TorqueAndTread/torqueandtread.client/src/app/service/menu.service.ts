import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { MenuItem } from "../screens/menus/menu-item.model";

@Injectable ({
    providedIn:'root'
})
export class MenuService{
    private apiUrl = '/api/MenuItem';
    constructor (private http: HttpClient){}
    getMenuItems():
    
        Observable<MenuItem[]>{
            return this.http.get<MenuItem[]>(this.apiUrl);
        }
    

    getMenuItem(id:number):
    Observable<MenuItem>{
        return this.http.get<MenuItem>(`${this.apiUrl}/${id}`);
    }

    addMenuItem(menuItem : MenuItem):
    Observable<MenuItem>{
        return this.http.post<MenuItem>(this.apiUrl,menuItem);
    }

    editMenuItem(id:number, menuItem: MenuItem): 
    Observable<MenuItem>{
        return this.http.put<MenuItem>(`${this.apiUrl}/${id}`,menuItem);
    }

    deleteMenuItem(id:number):
    Observable<MenuItem>{
        return this.http.delete<MenuItem>(`${this.apiUrl}/${id}`);
    }
}