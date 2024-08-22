import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Injectable } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {MenuComponent} from '../../../src/app/menu/menu.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MenusComponent } from './menus/menus.component';
import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './products/products.component';
import { ContainersComponent } from './containers/containers.component';
import { ProductionordersComponent } from './productionorders/productionorders.component';
import { PolicyComponent } from './policy/policy.component'
import { RouterModule, Routes } from '@angular/router';
import { RolesComponent } from './roles/roles.component';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome'


@Injectable({
  providedIn:'root'
})
export class AppService {
}
@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HeaderComponent,
    FooterComponent,
    MenusComponent,
    UsersComponent,
    ProductsComponent,
    ContainersComponent,
    ProductionordersComponent,
    PolicyComponent,
    RolesComponent
  ],
  imports: [
    BrowserModule,
    FontAwesomeModule,
    HttpClientModule,
    AppRoutingModule,

  ],
   providers: [],
   bootstrap: [AppComponent],
  
})
export class AppModule { }
