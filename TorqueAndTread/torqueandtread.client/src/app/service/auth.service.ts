import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { UserService } from './user.service';
import { BehaviorSubject, catchError, map, Observable, Subject, switchMap, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl="/api/auth"
  private imageUrl="/api/Image";
  img=''
  loginEvent = new BehaviorSubject<string|null>(null);
  constructor(
    private http:HttpClient,
    private userService:UserService,
    private router:Router
  ) {
    console.log("00");
    // this.loginEvent.next(3);
  }

  loginObservable = this.loginEvent.asObservable();
  register(registerForm:any){
    return this.http.post<any>(this.baseUrl+'/register', registerForm).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }
  savePfp=(pfpData:string) => {
      this.img='data:image/png;base64,'+pfpData;
      localStorage.setItem('currentUserPfp', this.img);
      this.loginEvent.next(this.img);
  }

  getPfp(path:string){
    return this.http.get<any>(this.imageUrl+`/base64/${path}`);
  }
  login(loginForm: any) {
    console.log('login');
    console.log(0);
    this.loginEvent.next("gugu");
    console.log(1);
    return this.http.post<any>(this.baseUrl + '/login', loginForm).pipe(
      map((response: any) => {
        console.log(2);
        localStorage.setItem('authToken', `Bearer ${response.token}`);
        this.loginEvent.next("lulu");
        console.log(3);
        if (response.imgFile) {
          this.getPfp(response.imgFile).subscribe((r)=>{
            console.log(4)
            this.savePfp(r.image);
            window.location.href="/dashboard";
          })
          // this.userService.getImage(response.imgFile).subscribe((r: Blob) => {
          //   if (r) {
          //     reader.readAsDataURL(r);
          //   }
          // });
  
          // reader.addEventListener('load', () => {
          //   if (reader.result) {
          //     let pfpData = reader.result as string;
          //     this.savePfp(pfpData);
          //   }
          // });
        }
  
        console.log(response);
        return response;
      }),
      map((response)=>{
        if (response.imgFile) {
          this.getPfp(response.imgFile).subscribe((r)=>{
            console.log(5);
            this.savePfp(r.image);
          })
          // this.userService.getImage(response.imgFile).subscribe((r: Blob) => {
          //   if (r) {
          //     reader.readAsDataURL(r);
          //   }
          // });
  
          // reader.addEventListener('load', () => {
          //   if (reader.result) {
          //     let pfpData = reader.result as string;
          //     this.savePfp(pfpData);
          //   }
          // });
        }
      })
    );
  }
  
  logout() {
    let token=localStorage.getItem('authToken');
    token=token!.slice(6);
    localStorage.removeItem('authToken');
    localStorage.removeItem('currentUserPfp');
    return this.http.post<any>(this.baseUrl+"/logout",{token},{
      headers:{
        accept:"application/json, text/plain, */*"
      }
    }).pipe(
      map((r)=>{})
    )
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('authToken');
  }
}
