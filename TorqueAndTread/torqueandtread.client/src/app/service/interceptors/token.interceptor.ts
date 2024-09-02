import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    var authToken:string | null =localStorage.getItem('authToken');
    var authReq:HttpRequest<any>;
    if (authToken){
      authReq = req.clone({
        headers: req.headers.set('Authorization', authToken)
      });  
    }else authReq=req.clone();
    
    return next.handle(authReq);
  }
}
