import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './screens/login/login.component';
import { PageNotFoundComponent } from './screens/page-not-found/page-not-found.component';
import { RegisterComponent } from './screens/register/register.component';
import { MenusComponent } from './menus/menus.component';
import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './products/products.component';
import { ContainersComponent } from './containers/containers.component';
import { ProductionordersComponent } from './productionorders/productionorders.component';
import { PolicyComponent } from './policy/policy.component'
import { RolesComponent } from './roles/roles.component';

const routes: Routes = [
  {path:"",redirectTo:"login",pathMatch:"full"},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path: 'menus',component:MenusComponent},
  {path: 'users',component:UsersComponent},
  {path: 'roles',component:RolesComponent},
  {path: 'products',component:ProductsComponent},
  {path: 'containers',component:ContainersComponent},
  {path: 'productionorders',component:ProductionordersComponent},
  {path: 'policy',component:PolicyComponent},
  {path:"**",component:PageNotFoundComponent}
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
