import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { BOM, ProductBOM } from '../models/bom';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductBOMService {

  bomId:number=0;
  private bomBaseUrl="/api/ProductBOM";
  constructor(private http:HttpClient) { }

  getBOMNumber(){
    return this.bomId;
  }
  setBOMId(n:number){
    this.bomId=n;
  }

  getByBOMId(bomId:number){
    return this.http.get<any>(this.bomBaseUrl+"/"+bomId,{})
    .pipe(
      map(
        (response: Product[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }
  

  

  createProductBOM(bom:ProductBOM){
    return this.http.post<any>(this.bomBaseUrl,bom).pipe(
      map(r=>{
        console.log(r);
        return r;
      }),
      catchError(e=>throwError(()=>new Error(e)))
    );
  }

  deleteProductBOM(bom:ProductBOM){
    return this.http.delete<any>(this.bomBaseUrl,{observe:"body",body:bom}).pipe(
      map(r=>{
        console.log(r);
        return r;
      }),
      catchError(e=>throwError(()=>new Error(e)))
    );
  }

  updateBOM(bom:ProductBOM){
    return this.http.put<any>(this.bomBaseUrl,bom).pipe(
      map(r=>{return r}),
      catchError(e=>throwError(()=>new Error(e)))
    )
  }
}
