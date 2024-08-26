import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl="/api/user";
  private selectedUserId:number=0;
  constructor(private http:HttpClient) { }
  private getToken(){
    return 'Bearer '+ localStorage.getItem("authToken");
  }

  setUserId(id:number){
    this.selectedUserId=id;
  }
  getUserId():number{
    return this.selectedUserId;
  }

  getAll(){
    return this.http.get<any>(this.baseUrl+"/all",{
      headers:{
        Authentification:this.getToken()
      }
    }).pipe(
      map((response: User[]) => {
        console.log(response);
        return response;
      })
    );
  }

  getUser(id:number){
    return this.http.get<any>(this.baseUrl+"/"+id,{
      headers:{
        Authentification:this.getToken()
      }
    }).pipe(
      map((response: User[]) => {
        return response.at(0);
      })
    );
  }

  updateUser(user:User){
    return this.http.put<any>(this.baseUrl,user,{
      headers:{
        Authentification:this.getToken()
      }
    }).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }
  createUser(user:User){
    return this.http.post<any>(this.baseUrl,user,{
      headers:{
        Authentification:this.getToken()
      }
    }).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }

  deleteUser(id:number){
    return this.http.delete<any>(this.baseUrl+"/"+id,{
      headers:{
        Authentification:this.getToken()
      }
    }).pipe(
      map((response: any) => {
        console.log(response)
      })
    );
  }
}
