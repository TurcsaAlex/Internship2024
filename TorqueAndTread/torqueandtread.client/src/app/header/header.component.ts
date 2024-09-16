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

      this.profilePictureSource=localStorage.getItem('currentUserPfp');
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
  }
  
  ngOnInit(): void {
    this.loadMenuItems();
    this.authService.loginObservable.subscribe((profilePictureData)=>{
      this.profilePictureSource=profilePictureData;
      this.cdRef.detectChanges();
      this.profilePictureSource = localStorage.getItem('currentUserPfp');
      console.log(this.profilePictureSource);
    });
    
  }

  logout() {
    this.authService.logout().subscribe({
      next: () => {
        this.profilePictureSource = null;
        this.loggedIn=false;
        this.menuItems=[];
        this.router.navigateByUrl('/login');
       
      }
    });
  }


  menuItems : any[] = [];


  toggleNavbar(): void {
    this.isNavbarShown = !this.isNavbarShown;
  }

  openProfile() {
    this.isNavbarShown = false;
    this.modalService.open(UserProfileComponent);
  }

  pictureEventReciever(event:Event){
  }


  loadMenuItems(){
    const menuItems = localStorage.getItem('menuItems');
    console.log(menuItems);
    if(menuItems){
      this.menuItems = JSON.parse(menuItems);
    }
  }

}
