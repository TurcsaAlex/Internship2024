import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate,Router } from "@angular/router";
import { RoleAuthorizationService } from "./roleauthorization.service";

@Injectable({
    providedIn : 'root'
})

export class AuthGuard implements CanActivate{
    constructor(private roleAuthService : RoleAuthorizationService, private router : Router){}
    
    canActivate(route: ActivatedRouteSnapshot): boolean {
        return true;
        // const token = localStorage.getItem('authToken');
        // const roles = localStorage.getItem('roles');
        
        // //check if users is authenticated and has roles
        // if(!token || !roles){
        //     this.router.navigate(['/login']);
        //     return false;
        // }
        // return this.roleAuthService.checkAccess(roles.split(','));
    }
        
    }