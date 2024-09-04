import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { LoginAttempt } from '../models/loginAttempt';

@Injectable({
  providedIn: 'root'
})
export class LoginAttemptsService {
  private productBaseUrl="/api/LoginAttempts";
  constructor(private http:HttpClient) {}

  getAttemptsForCharts(start:Date,stop:Date){
    return this.http.get<any>(this.productBaseUrl+"/chart",{
      params:{
        start:start.toISOString(),
        stop:stop.toISOString(),
      }
    }).pipe(
      map(
        (respone : any)=>{
          return respone;
        }
      )
    )
  }
}
