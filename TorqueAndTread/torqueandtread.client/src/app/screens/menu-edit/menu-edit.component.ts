import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { MenuService } from '../../service/menu.service';
import { MenuItem } from '../menus/menu-item.model';
import { IconService } from '../../service/icon.service';

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

  constructor(
    private formBuilder: FormBuilder,
    private menuService: MenuService,
    private toastService: ToastService,
    private router: Router,
    private iconService: IconService
  ) {}

  ngOnInit(): void {
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
        next: (menuItem) => {
          if (menuItem) {
            this.menuItemForm.patchValue(menuItem);
          } else {
            console.error('Menu item not found');
          }
        },
        error: (err) => console.error('Failed to fetch menu item for editing', err)
      });
    }
  }
  onSubmit(toastTemplate: TemplateRef<any>): void {
    const formValues = this.menuItemForm.value;
    if (this.menuItemForm.valid) {
      const menuItemUpdate: MenuItem = { menuItemId: this.currentMenuItemId!, ...formValues};
        this.menuService.editMenuItem(menuItemUpdate).subscribe({
          next: () => {
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


  
