import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { MenuItem } from "../screens/menus/menu-item.model";

@Injectable ({
    providedIn:'root'
})
export class MenuService{
    private apiUrl = '/api/MenuItem';
    private selectedMenuItemId:number=0;
    constructor(private http: HttpClient) {}

    setMenuItemID(id: number): void {
        this.selectedMenuItemId = id;
    }

    getMenuItemID(): number {
        return this.selectedMenuItemId;
    }

    getMenuItems(): Observable<MenuItem[]> {
        const token = localStorage.getItem('authToken');
        const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`);
        return this.http.get<MenuItem[]>(this.apiUrl, {headers});
    }

    getMenuItem(id: number): Observable<MenuItem> {
        return this.http.get<MenuItem>(`${this.apiUrl}/${id}`);
    }

    addMenuItem(menuItem: MenuItem): Observable<MenuItem> {
        return this.http.post<MenuItem>(this.apiUrl, menuItem);
    }
    editMenuItem(menuItem: MenuItem): Observable<MenuItem> {
        return this.http.put<MenuItem>(`${this.apiUrl}/${menuItem.menuItemId}`, menuItem);
    }

    deleteMenuItem(id: number): Observable<MenuItem> {
        return this.http.delete<MenuItem>(`${this.apiUrl}/${id}`);
    }
}