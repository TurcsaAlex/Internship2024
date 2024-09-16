import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { MenuService } from '../../service/menu.service';
import { MenuItem } from '../menus/menu-item.model';
import { MenuItemService } from '../../service/menuitem.service';
import { IconService } from '../../service/icon.service';
import { RoleService } from '../../service/role.service';
import { Role } from '../../models/role';

@Component({
  selector: 'app-menu-edit',
  templateUrl: './menu-edit.component.html',
  styleUrl: './menu-edit.component.css'
})
// 
export class MenuEditComponent implements OnInit {
  menuItemForm!: FormGroup;
  isEditMode = false;
  currentMenuItemId: number | null = null;
  fontAwesomeIcons: string[] = [];
  menuItemRoles: Role[] = [];
  availableRoles: Role[] = [];
  menuItemId: number | null = null;

  constructor(
    private formBuilder: FormBuilder,
    private menuService: MenuService,
    private menuItemService : MenuItemService,
    private toastService: ToastService,
    private router: Router,
    private iconService: IconService,
    private roleService: RoleService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {


    const storedMenu = localStorage.getItem('currentMenuItemId');
    if(storedMenu)
    {
      this.menuItemId =Number(storedMenu);
      console.log('s-a preluat menuitemid: ', this.menuItemId);
    }

    this.menuItemForm = this.formBuilder.group({
      name: ['', Validators.required],
      orderNo: ['', Validators.required],
      iconClass: [''],
      link: ['']
    });

    
    this.fontAwesomeIcons = this.iconService.getIcons(); //get icons from service
    const menuItemToEdit = this.menuService.getMenuItemID() || localStorage.getItem('currentMenuItemId');
    if (menuItemToEdit) {
      this.isEditMode = true;
      this.currentMenuItemId =+ menuItemToEdit;
      console.log(this.currentMenuItemId);
      this.menuService.getMenuItem(this.currentMenuItemId).subscribe({
        next: (menuItem) => {  if(this.menuItemId)
          {
            this.menuItemService.setMenuItemId(this.menuItemId);
            this.loadRoles();
          }
          if (menuItem) {
            this.menuItemForm.patchValue(menuItem);
            this.menuItemRoles = menuItem.roles || [];
          } else {
            console.error('Menu item not found');
          }
        },
        error: (err) => console.error('Failed to fetch menu item for editing', err)
      });
    }

}

loadRoles(){
  console.log('loading roles:', this.menuItemId);
  if(this.menuItemId){
   
    this.roleService.getAll().subscribe({
      next: (roles) => {
        this.availableRoles = roles;
      }
    });
    this.roleService.getRolesByMenuItemId(this.menuItemId).subscribe({next:(roles) =>
    {
      this.menuItemRoles = roles;
      console.log('Menu item roles loaded:', this.menuItemRoles);

    },
    error: (err) => {
      console.error('Failed to load roles for menu item', err);
    }
    });
  }
 
}
  

addRole(roleId : number){
  if(this.menuItemId){
    console.log(`adding role with id ${roleId}`);
    this.roleService.addRoleToMenuItem(this.menuItemId,roleId).subscribe({
      next: () => 
        {console.log('roles addded succesfully');
          this.loadRoles();}, 
          error: (err) => console.error('failed to add role')
    });
  }
}

removeRole(roleId: number){
  if(this.menuItemId){
    this.roleService.removeRoleFromMenuItem(this.menuItemId,roleId).subscribe({
      next:()=> this.loadRoles()
    });
  }
}
  onSubmit(toastTemplate: TemplateRef<any>): void {
    const formValues = this.menuItemForm.value;
    console.log('Menu Item Roles: ', this.menuItemRoles);
    if (this.menuItemForm.valid && this.menuItemId !== null) {
      const menuItemUpdate: MenuItem = { menuItemId: this.currentMenuItemId!,
                                        ...formValues,
                                        roles: this.menuItemRoles};
        this.roleService.updateMenuItemsWithRoles(this.currentMenuItemId!,menuItemUpdate).subscribe({
          next: (updateMenuItem) => {
            this.menuItemRoles = updateMenuItem.roles;
            this.toastService.show({
              template: toastTemplate,
              classname: 'bg-success text-light',
              data: { name: menuItemUpdate.name, action: 'updated' }
            });
            this.router.navigate(['/menus']);
          },
          error: (err) => {
            console.error('Failed to update menu item', err); 
            this.toastService.show({
              template: toastTemplate,
              classname: 'bg-danger text-light',
              data: { name: menuItemUpdate.name, action: 'update failed' }
            });
          }
        });
      }else{
        console.log('Form is invalid');
      }
    } 

  back(): void {
    this.router.navigateByUrl('/menus');
  }
    }


  
