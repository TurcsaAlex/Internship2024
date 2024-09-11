import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
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
import { MenuAddComponent } from './screens/menu-add/menu-add.component';
import { MenuEditComponent } from './screens/menu-edit/menu-edit.component';
import { RolesTableComponent } from './screens/user-edit/roles-table/roles-table.component';
import { WebcamComponent } from './screens/user-edit/webcam/webcam.component';
import { AddUserRolesComponent } from './screens/user-edit/roles-table/add-user-roles/add-user-roles.component';
import { AuthInterceptor } from './service/interceptors/auth.interceptor';
import { TokenInterceptor } from './service/interceptors/token.interceptor';
import { ProductsAddComponent } from './screens/products/products-add/products-add.component';
import { ProductsEditComponent } from './screens/products/products-edit/products-edit.component';
import { RoletableComponent } from './screens/menu-edit/roletable/roletable.component';
import { AddmenuitemsroleComponent } from './screens/menu-edit/roletable/addmenuitemsrole/addmenuitemsrole.component';



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
    ProductsComponent,
    ContainersComponent,
    ProductionordersComponent,
    PolicyComponent,
    UserEditComponent,
    UserAddComponent,
    MenuAddComponent,
    MenuEditComponent,
    RolesTableComponent,
    WebcamComponent,
    AddUserRolesComponent,
    ProductsAddComponent,
    ProductsEditComponent,
    RoletableComponent,
    AddmenuitemsroleComponent,
  ],
  imports: [
    BrowserModule,
    MenusComponent,
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
    RolesComponent
  ],
   providers: [
    provideAnimationsAsync(),
    MenuService,
    {provide: HTTP_INTERCEPTORS, useClass:AuthInterceptor, multi:true},
    {provide: HTTP_INTERCEPTORS, useClass:TokenInterceptor, multi:true}

  ],

   bootstrap: [AppComponent]
  
})
export class AppModule { }
