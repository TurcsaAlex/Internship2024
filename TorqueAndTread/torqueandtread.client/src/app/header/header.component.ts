import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent  implements OnInit{
  isNavbarShown: boolean = false;
  menuItems : any[] = [];
  constructor(){}

  toggleNavbar(): void {
    this.isNavbarShown = !this.isNavbarShown
  }
  ngOnInit(): void { // de vazut de ce nu apar 
    this.loadMenuItems();
  }

  loadMenuItems(){
    const menuItems = localStorage.getItem('menuItems');
    console.log(menuItems);
    if(menuItems){
      this.menuItems = JSON.parse(menuItems);
    }
  }

  logout(){
    localStorage.removeItem('authToken');
    localStorage.removeItem('menuItems'); 
    localStorage.removeItem('roles');// navigate to login after logout
  }
}
