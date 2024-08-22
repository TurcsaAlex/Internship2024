import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenusComponent } from './menus/menus.component';
import { UsersComponent } from './users/users.component';
import { ProductsComponent } from './products/products.component';
import { ContainersComponent } from './containers/containers.component';
import { ProductionordersComponent } from './productionorders/productionorders.component';
import { PolicyComponent } from './policy/policy.component'
import { RolesComponent } from './roles/roles.component';

const routes: Routes =[
  {path: 'menus',component:MenusComponent},
  {path: 'users',component:UsersComponent},
  {path: 'roles',component:RolesComponent},
  {path: 'products',component:ProductsComponent},
  {path: 'containers',component:ContainersComponent},
  {path: 'productionorders',component:ProductionordersComponent},
  {path: 'policy',component:PolicyComponent},
  {path: '', redirectTo: '/menus', pathMatch:'full'},
  {path: '**', redirectTo: '/menus'} //redirect to menus for any unknown routes
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
