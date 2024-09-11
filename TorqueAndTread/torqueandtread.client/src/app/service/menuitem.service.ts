import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";


@Injectable({
    providedIn:'root'
})
export class MenuItemService {
    private menuItemIDSource = new BehaviorSubject<number | null>(null);
    currentMenuItemId$ = this.menuItemIDSource.asObservable();
    

    setMenuItemId(id: number | null){
        this.menuItemIDSource.next(id);
    }


    getMenuItemId() : number | null {
        return this.menuItemIDSource.getValue();
    }
}