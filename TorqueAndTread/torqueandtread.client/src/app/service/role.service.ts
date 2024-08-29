import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { Role, UserRole } from '../models/role';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private userRolebaseUrl="/api/UserRole";
  private rolebaseUrl="/api/Role";
  constructor(private http:HttpClient) { }
  private getToken(){
    return 'Bearer '+ localStorage.getItem("authToken");
  }


  getAllByUserId(userId:number){
    return this.http.get<any>(this.userRolebaseUrl+"/all/"+userId,{
      headers:{
        Authentification:this.getToken()
      }
    }).pipe(
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
    return this.http.get<any>(this.rolebaseUrl,{
      headers:{
        Authentification:this.getToken()
      }
    }).pipe(
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
      headers:{
        Authentification:this.getToken()
      }
    }).pipe(
      map((response: any) => {
        console.log(response);
      }),
      catchError((e)=>throwError(()=>console.log(e)))
    );
  }

  deleteUserRole(userId:number,roleId:number){
    return this.http.delete<any>(this.userRolebaseUrl,{
      headers:{
        Authentification:this.getToken()
      },
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
}
