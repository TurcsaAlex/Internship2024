import { Injectable } from "@angular/core";

@Injectable({
    providedIn:'root'
})
export class IconService{
    private fontAwesomeIcons =[
        'fas fa-home',
        'fas fa-user',
        'fas fa-cog',
        'fas fa-envelope'
    ];

    getIcons(): string[] {
        return this.fontAwesomeIcons;
    }
}