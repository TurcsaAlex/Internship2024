import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { Container, ContainerType } from '../models/container';

@Injectable({
  providedIn: 'root'
})
export class ContainerService {
  
  containerId:number=0;
  private containerBaseUrl="/api/Container";
  constructor(private http:HttpClient) { }

  getContainerNumber(){
    return this.containerId;
  }
  setContainerId(n:number){
    this.containerId=n;
  }

  getAll(){
    return this.http.get<any>(this.containerBaseUrl,{})
    .pipe(
      map(
        (response: Container[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }
  getContainerCodes(){
    return this.http.get<any>(this.containerBaseUrl+'/codes',{})
    .pipe(
      map(
        (response: string[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }
  getContainer(id:number){
    return this.http.get<any>(this.containerBaseUrl+'/'+id).pipe(
      map(
        (r:Container)=>{
          return r;
        }),
        catchError((e)=>{
          console.log(e);
          return throwError(()=>{new Error(e)});
        })
    )
  }

  getAllTypes(){
    return this.http.get<any>(this.containerBaseUrl+"/types",{})
    .pipe(
      map(
        (response: ContainerType[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }

  createContainer(container:Container){
    return this.http.post<any>(this.containerBaseUrl,container).pipe(
      map(r=>{
        console.log(r);
        return r;
      }),
      catchError(e=>throwError(()=>new Error(e)))
    );
  }

  deleteContainer(containerId:number){
    return this.http.delete<any>(this.containerBaseUrl+'/'+containerId,).pipe(
      map(r=>{
        console.log(r);
        return r;
      }),
      catchError(e=>throwError(()=>new Error(e)))
    );
  }

  updateContainer(container:Container){
    return this.http.put<any>(this.containerBaseUrl,container).pipe(
      map(r=>{return r}),
      catchError(e=>throwError(()=>new Error(e)))
    )
  }

}
