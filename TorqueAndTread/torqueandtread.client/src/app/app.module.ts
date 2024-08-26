import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Injectable } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './screens/login/login.component';
import { PageNotFoundComponent } from './screens/page-not-found/page-not-found.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './screens/register/register.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MenusComponent } from './screens/menus/menus.component';
import { UsersComponent } from './screens/users/users.component';
import { ProductsComponent } from './screens/products/products.component';
import { ContainersComponent } from './screens/containers/containers.component';
import { ProductionordersComponent } from './screens/productionorders/productionorders.component';
import { PolicyComponent } from './screens/policy/policy.component'
import { RolesComponent } from './screens/roles/roles.component';
import { MenuService } from './service/menu.service';
import {FontAwesomeModule} from '@fortawesome/angular-fontawesome';
import { UserEditComponent } from './screens/user-edit/user-edit.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { UserAddComponent } from './screens/user-add/user-add.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastsContainer } from './toast-container/toast-container.component';
import { RolesTableComponent } from './screens/user-edit/roles-table/roles-table.component';


@Injectable({
  providedIn:'root'
})
export class AppService {
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PageNotFoundComponent,
    RegisterComponent,
    HeaderComponent,
    FooterComponent,
    MenusComponent,
    ProductsComponent,
    ContainersComponent,
    ProductionordersComponent,
    PolicyComponent,
    RolesComponent,
    UserEditComponent,
    UserAddComponent,
    RolesTableComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    MatTableModule,
    MatPaginatorModule,
    UsersComponent,
    NgbModule,
    ToastsContainer,
  ],
   providers: [
    provideAnimationsAsync(),
    MenuService
  ],

   bootstrap: [AppComponent]
  
})
export class AppModule { }
