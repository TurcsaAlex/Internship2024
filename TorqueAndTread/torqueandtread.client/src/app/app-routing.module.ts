import { Injectable, NgModule } from '@angular/core';
import { ActivatedRouteSnapshot, GuardResult, MaybeAsync, RouterModule, RouterStateSnapshot, Routes } from '@angular/router';
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
import { MenuAddComponent } from './screens/menu-add/menu-add.component';
import { MenuEditComponent } from './screens/menu-edit/menu-edit.component';
import { ProductsAddComponent } from './screens/products/products-add/products-add.component';
import { ProductsEditComponent } from './screens/products/products-edit/products-edit.component';
import { DashboardComponent } from './screens/dashboard/dashboard.component';
import { ContainerAddComponent } from './screens/containers/container-add/container-add.component';
import { UserAddComponent } from './screens/user-add/user-add.component';
import { ContainerEditComponent } from './screens/containers/container-edit/container-edit.component';
import { BomsComponent } from './screens/boms/boms.component';
import { BomAddComponent } from './screens/boms/bom-add/bom-add.component';
import { BomEditComponent } from './screens/boms/bom-edit/bom-edit.component';
import { AuthGuard } from './service/auth.guard';
const routes: Routes = [
  {path:"",redirectTo:"login",pathMatch:"full"},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path: 'menus',component:MenusComponent, canActivate: [AuthGuard]},
  {path: 'users',component:UsersComponent, canActivate: [AuthGuard]},
  {path: 'edit-user' ,component:UserEditComponent},
  {path: 'add-user', component:UserAddComponent},
  {path: 'roles',component:RolesComponent, canActivate: [AuthGuard]},
  {path: 'products',component:ProductsComponent, canActivate: [AuthGuard]},
  {path: 'containers',component:ContainersComponent, canActivate: [AuthGuard]},
  {path: 'productionorders',component:ProductionordersComponent, canActivate: [AuthGuard]},
  {path: 'policy',component:PolicyComponent},
  {path: 'add-menu-item', component:MenuAddComponent},
  {path: 'edit-menu-item', component:MenuEditComponent},
  {path: 'add-product', component:ProductsAddComponent},
  {path: 'edit-product', component:ProductsEditComponent},
  {path: 'dashboard',component:DashboardComponent, canActivate: [AuthGuard]},
  {path: 'add-container', component:ContainerAddComponent},
  {path: 'edit-container', component:ContainerEditComponent},
  {path: 'boms', component:BomsComponent, canActivate: [AuthGuard]},
  {path: 'add-bom', component:BomAddComponent},
  {path: 'edit-bom', component:BomEditComponent},
  {path:"**",component:PageNotFoundComponent},
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }




