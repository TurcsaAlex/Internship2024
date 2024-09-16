import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable ({
    providedIn: 'root'
}) export class RoleAuthorizationService{
    constructor(private router: Router){}

    isAuthenticated() : boolean {
        const token = localStorage.getItem('authToken');
        return !! token;
    }

    // method to verify if user has one of the roles permited
    hasRoles(requiredRoles : string[]) : boolean {
        const userRoles = (localStorage.getItem('roles') || '').split(',');
        return userRoles.some((role : string) => requiredRoles.includes(role.trim()));
    }

    // method to check access
    checkAccess(requiredRoles : string[]) : boolean {
        if(!this.isAuthenticated()){
            this.router.navigate(['/login']);
            return false;
        }
        else{
            if(!this.hasRoles(requiredRoles)){
                this.router.navigate(['/unathorized']);
                return false;
            }
            return true;
        }
    }
}