import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  isNavbarShown: boolean = false;

  toggleNavbar(): void {
    this.isNavbarShown = !this.isNavbarShown
  }
}
