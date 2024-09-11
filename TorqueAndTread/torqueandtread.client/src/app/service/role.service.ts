import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, throwError } from 'rxjs';
import { Role, UserRole } from '../models/role';
import { MenuItem } from '../screens/menus/menu-item.model';


@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private userRolebaseUrl="/api/UserRole";
  private rolebaseUrl="/api/Role";
  private menuItemRoleBaseUrl = "/api/MenuItem";
  
  constructor(private http:HttpClient) { }

  
  getAllByUserId(userId:number){
    return this.http.get<any>(this.userRolebaseUrl+"/all/"+userId,{})
    .pipe(
      map(
        (response: UserRole[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }

  getAll(){
    return this.http.get<any>(this.rolebaseUrl,{})
    .pipe(
      map(
        (response: Role[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }

  createUserRole(userId:number,roleId:number){
    return this.http.post<any>(this.userRolebaseUrl,
      {
        userId,
        roleId
      }
      ,{
      
    }).pipe(
      map((response: any) => {
        console.log(response);
      }),
      catchError((e)=>throwError(()=>console.log(e)))
    );
  }

  deleteUserRole(userId:number,roleId:number){
    return this.http.delete<any>(this.userRolebaseUrl,{
      body:{
        userId,
        roleId
      }
    }).pipe(
      map((response: any) => {
        console.log(response);
      }),
      catchError((e)=>throwError(()=>console.log(e)))
    );
  }

  getRolesByMenuItemId(menuItemId : number)
  {
    return this.http.get<any>(`${this.menuItemRoleBaseUrl}/${menuItemId}`)
      .pipe(map((response: MenuItem) => {
        console.log(response.roles);
        return response.roles;
      }), 
      catchError((e) => {
        console.log(e);
        return throwError(() => new Error(e));
      })
    );
  }

  addRoleToMenuItem(menuItemId: number, roleId: number){
    if(!roleId)
    {
      console.error('roleId is undefined or null');
    }
    console.group(`Adding role ${roleId} to menu item ${menuItemId}`);
    console.log('Roleid is being sent: ', roleId);
    const headers = new HttpHeaders().set('Content-Type','application/json');
    return this.http.post<any>(`/api/MenuItemRole/${menuItemId}/roles`, roleId, {headers})
    .pipe(map((response: any) => {
      console.log(response);
      return response;
    }),
    catchError((e)=> throwError(() => console.log(e)))
  );
  }

  removeRoleFromMenuItem(menuItemId: number, roleId: number){
    return this.http.delete<any>(`/api/MenuItemRole/${menuItemId}/roles/${roleId}`).pipe(map((response:any)=> {
      console.log(response);
      return response;
    }),
    catchError((e) => throwError(()=> console.log(e)))
  );
  }
}

