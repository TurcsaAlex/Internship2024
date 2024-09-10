import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { BOM } from '../models/bom';

@Injectable({
  providedIn: 'root'
})
export class BOMService {

  bomId:number=0;
  private bomBaseUrl="/api/BOM";
  constructor(private http:HttpClient) { }

  getBOMNumber(){
    return this.bomId;
  }
  setBOMId(n:number){
    this.bomId=n;
  }

  getAll(){
    return this.http.get<any>(this.bomBaseUrl,{})
    .pipe(
      map(
        (response: BOM[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }
  getBOMCodes(){
    return this.http.get<any>(this.bomBaseUrl+'/codes',{})
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
  getBOM(id:number){
    return this.http.get<any>(this.bomBaseUrl+'/'+id).pipe(
      map(
        (r:BOM)=>{
          return r;
        }),
        catchError((e)=>{
          console.log(e);
          return throwError(()=>{new Error(e)});
        })
    )
  }

  

  createBOM(bom:BOM){
    return this.http.post<any>(this.bomBaseUrl,bom).pipe(
      map(r=>{
        console.log(r);
        return r;
      }),
      catchError(e=>throwError(()=>new Error(e)))
    );
  }

  deleteBOM(bomId:number){
    return this.http.delete<any>(this.bomBaseUrl+'/'+bomId,).pipe(
      map(r=>{
        console.log(r);
        return r;
      }),
      catchError(e=>throwError(()=>new Error(e)))
    );
  }

  updateBOM(bom:BOM){
    return this.http.put<any>(this.bomBaseUrl,bom).pipe(
      map(r=>{return r}),
      catchError(e=>throwError(()=>new Error(e)))
    )
  }
}
