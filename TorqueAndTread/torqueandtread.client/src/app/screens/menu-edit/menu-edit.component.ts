import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { MenuService } from '../../service/menu.service';
import { MenuItem } from '../menus/menu-item.model';

@Component({
  selector: 'app-menu-edit',
  templateUrl: './menu-edit.component.html',
  styleUrl: './menu-edit.component.css'
})
export class MenuEditComponent 
  implements OnInit{
    menuItemForm !: FormGroup;
    menuItemID!: number;
    isEditMode = false;

    constructor(
      private formBuilder: FormBuilder,
      private menuService: MenuService,
      private toastService: ToastService,
      private route: ActivatedRoute,
      private router: Router){}
  

    ngOnInit(): void {
    this.menuItemID = +this.route.snapshot.paramMap.get('id')!;
    this.menuItemForm = this.formBuilder.group({menuItemId:['',Validators.required],
      name:['',Validators.required],
      orderNo:['',Validators.required],
      iconClass:['',Validators.required],
      link:['',Validators.required]
    });
    if(this.menuItemID)
    {
      this.isEditMode = true;
      this.menuService.getMenuItem(this.menuItemID).subscribe((menuItem) => {this.menuItemForm.patchValue(menuItem)});
  }
    }
    

      onSubmit(toastTemplate:TemplateRef<any>){
        if (this.menuItemForm.invalid) {
          return;
        }
        const menuItemUpdate: MenuItem = this.menuItemForm.value;
        if(this.isEditMode){}
        console.log('Menu item saved', menuItemUpdate);

        this.menuService.addMenuItem(menuItemUpdate).subscribe(() => {this.toastService.show({template:toastTemplate,classname: 'bg-success text-light'});
        this.router.navigate(['/menus']);
      });
      }
    
      back(){
        this.router.navigateByUrl('/menus');
      }
    }


  
