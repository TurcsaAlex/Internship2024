import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl="/api/auth"
  constructor(private http:HttpClient) { }

  register(registerForm:any){
    return this.http.post<any>(this.baseUrl+'/register', registerForm).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }

  login(loginForm:any):Observable<any>{
    console.log('login')
    return this.http.post<any>(this.baseUrl+'/login', loginForm).pipe(
      map((response: any) => {
        console.log(response);
        localStorage.setItem('authToken',`Bearer ${response.token}`);
        return response;
      })
    );
  }
  logout(): void {
    localStorage.removeItem('authToken');
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('authToken');
  }
}
