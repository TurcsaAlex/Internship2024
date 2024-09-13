import { ChangeDetectorRef, Component, inject, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserProfileComponent } from '../screens/user-profile/user-profile.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  profilePictureSource: any;
  isNavbarShown = false;
  loggedIn=false;
  
  constructor(
    private authService: AuthService,
    private router: Router,
    private modalService: NgbModal,
    private cdRef: ChangeDetectorRef
  ) {
    // this.profilePictureSource = localStorage.getItem('currentUserPfp');
    this.authService.loginObservable.subscribe((profilePictureData)=>{
      console.log(6);
      this.profilePictureSource=profilePictureData;
      if(localStorage.getItem("authToken")){
        this.loggedIn=true;
      }else {
        this.loggedIn=false;
      }
    });
    // this.authService.loginObservable.subscribe({
    //   next: (r) => {
    //     debugger;
    //     this.profilePictureSource = localStorage.getItem('currentUserPfp');
    //     console.log(this.profilePictureSource);
    //     this.cdRef.detectChanges();
    //     debugger;
    //     this.ngOnInit();
    //   }
    // });
    window.onstorage=(e)=>{
     debugger; 
    }
    window.addEventListener('storage',()=>{
      debugger;
    });

    
  }
  
  ngOnInit(): void {
    this.authService.loginObservable.subscribe((profilePictureData)=>{
      console.log(6);
      this.profilePictureSource=profilePictureData;
      this.cdRef.detectChanges();
    });
    this.authService.loginEvent.subscribe((r)=>{
      console.log(7);
      this.cdRef.detectChanges();
    });
    this.profilePictureSource = localStorage.getItem('currentUserPfp');
  }

  logout() {
    this.authService.logout().subscribe({
      next: () => {
        this.profilePictureSource = null;
        this.loggedIn=false;
        this.router.navigateByUrl('/login');
      }
    });
  }

  toggleNavbar(): void {
    this.isNavbarShown = !this.isNavbarShown;
  }

  openProfile() {
    this.isNavbarShown = false;
    this.modalService.open(UserProfileComponent);
  }

  pictureEventReciever(event:Event){
  }
}
