import { HttpClient } from '@angular/common/http';
import {  Injectable,  } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';

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
    //private userService:UserService,
    //private router:Router
  ) {
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
    return this.http.post<any>(this.baseUrl + '/login', loginForm).pipe(
      map((response: any) => {
        localStorage.setItem('authToken', `Bearer ${response.token}`);
        if (response.imgFile) {
          this.getPfp(response.imgFile).subscribe((r)=>{
            this.savePfp(r.image);
            localStorage.setItem('authToken',`Bearer ${response.token}`);
            localStorage.setItem('menuItems', JSON.stringify(response.menuItems));
            localStorage.setItem('roles', response.roles.join(','));
            window.location.href="/dashboard";
          });
        }
        else
        {
          localStorage.setItem('authToken',`Bearer ${response.token}`);
          localStorage.setItem('menuItems', JSON.stringify(response.menuItems));
          localStorage.setItem('roles', response.roles.join(','));
          window.location.href="/dashboard";
        }
        return response;
      })
    );
  }
  
  logout() {
    let token=localStorage.getItem('authToken');
    token=token!.slice(6);
    localStorage.removeItem('authToken');
    localStorage.removeItem('currentUserPfp');
    localStorage.removeItem('menuItems'); 
    localStorage.removeItem('roles');
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
