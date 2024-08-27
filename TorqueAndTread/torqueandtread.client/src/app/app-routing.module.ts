import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './screens/login/login.component';
import { PageNotFoundComponent } from './screens/page-not-found/page-not-found.component';
import { RegisterComponent } from './screens/register/register.component';
import { MenusComponent } from './screens/menus/menus.component';
import { UsersComponent } from './screens/users/users.component';
import { ProductsComponent } from './screens/products/products.component';
import { ContainersComponent } from './screens/containers/containers.component';
import { ProductionordersComponent } from './screens/productionorders/productionorders.component';
import { PolicyComponent } from './screens/policy/policy.component'
import { RolesComponent } from './screens/roles/roles.component';
import { UserEditComponent } from './screens/user-edit/user-edit.component';
import { UserAddComponent } from './screens/user-add/user-add.component';
import { MenuAddComponent } from './screens/menu-add/menu-add.component';
import { MenuEditComponent } from './screens/menu-edit/menu-edit.component';

const routes: Routes = [
  {path:"",redirectTo:"login",pathMatch:"full"},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path: 'menus',component:MenusComponent},
  {path: 'users',component:UsersComponent},
  {path: 'edit-user' ,component:UserEditComponent},
  {path: 'add-user', component:UserAddComponent},
  {path: 'roles',component:RolesComponent},
  {path: 'products',component:ProductsComponent},
  {path: 'containers',component:ContainersComponent},
  {path: 'productionorders',component:ProductionordersComponent},
  {path: 'policy',component:PolicyComponent},
  {path: 'add-menu-item', component:MenuAddComponent},
  {path: 'edit-menu-item', component:MenuEditComponent},
  {path:"**",component:PageNotFoundComponent},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
