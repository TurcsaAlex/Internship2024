import { Component,OnInit } from '@angular/core';
import { MenuService } from '../../service/menu.service';
import { MenuItem } from './menu-item.model';

@Component({
  selector: 'app-menus',
  templateUrl: './menus.component.html',
  styleUrl: './menus.component.css'
})
export class MenusComponent 
implements OnInit{
  menuItems: MenuItem[] = [];
  selectedMenuItem: MenuItem = {
    name: '', orderNo: 0, iconClass: '', link: '',
    menuItemId: 0
  };
    isEditing: boolean = false;
    constructor(private menuService : MenuService){}
    ngOnInit(): void {
      this.loadMenuItems();
    }
    loadMenuItems() : void {

   this.menuService.getMenuItems().subscribe(data => {this.menuItems = data}); }
  

  addMenuItem(): void{
    this.menuService.addMenuItem(this.selectedMenuItem).subscribe(() => {this.loadMenuItems});
  }

  updateMenuItem(): void{
    if(this.selectedMenuItem.menuItemId){
      this.menuService.editMenuItem(this.selectedMenuItem.menuItemId, this.selectedMenuItem).subscribe(() => this.loadMenuItems)
    }
  }

  editMenuItem(id:number):void{
    const menuItem = this.menuItems.find(item => item.menuItemId === id)
    if(!menuItem)
    {console.error('Menu Item not found')
      return;
    }
 
  }
  

  deleteMenuItem(menuItemId:number): void{
    this.menuService.deleteMenuItem(menuItemId).subscribe(() => {this.loadMenuItems();})
  }
  
  selectMenuItem(item: MenuItem): void{
    this.selectedMenuItem = {...item};
    this.isEditing = true;
  }

  resetForm(): void{
    this.selectedMenuItem = {
      name: '', orderNo: 0, iconClass: '', link: '',
      menuItemId: 0
    };
    this.isEditing = false;
  }

}



