import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { Product, ProductType, UOM } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  productId:number=0;
  private productBaseUrl="/api/Product";
  constructor(private http:HttpClient) { }

  getProductNumber(){
    return this.productId;
  }
  setProductId(n:number){
    this.productId=n;
  }

  getAll(){
    return this.http.get<any>(this.productBaseUrl,{})
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
  getAllTypes(){
    return this.http.get<any>(this.productBaseUrl+"/types",{})
    .pipe(
      map(
        (response: ProductType[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }

  getAllUOMs(){
    return this.http.get<any>(this.productBaseUrl+"/UOM",{})
    .pipe(
      map(
        (response: UOM[]) => {
        console.log(response);
        return response;
      }),
      catchError((e)=>{
        console.log(e);
        return throwError(()=>{new Error(e)});
      })
    );
  }
  deleteProduct(productId:number){
    return this.http.delete<any>(this.productBaseUrl+"/"+productId,{}).pipe(
      map((response: any) => {
        console.log(response)
      })
    );
  }

  getProduct(id:number){
    return this.http.get<any>(this.productBaseUrl+"/"+id,{}).pipe(
      map((response: Product) => {
        return response;
      })
    );
  }

  createProduct(product:Product){
    return this.http.post<any>(this.productBaseUrl,product).pipe(
      map((response: any) => {
        console.log(response)
      })
    );
  }
  editProduct(product:Product){
    return this.http.put<any>(this.productBaseUrl,product).pipe(
      map((response: any) => {
        console.log(response)
      })
    );
  }
}
