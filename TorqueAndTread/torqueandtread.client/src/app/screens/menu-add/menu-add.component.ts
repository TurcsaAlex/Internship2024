import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormRecord, isFormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { MenuService } from '../../service/menu.service';
import { MenuItem } from '../menus/menu-item.model';

@Component({
  selector: 'app-menu-add',
  templateUrl: './menu-add.component.html',
  styleUrl: './menu-add.component.css'
})
export class MenuAddComponent implements OnInit{
  menuItemForm : FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private menuService: MenuService,
    private toastService: ToastService,
    private router: Router){
      this.menuItemForm = this.formBuilder.group({menuItemId:['',Validators.required],
        name:['',Validators.required],
        orderNo:['',Validators.required],
        iconClass:['',Validators.required],
        link:['',Validators.required]
      })
    }

    ngOnInit(): void {
      
    }

    onSubmit(toastTemplate:TemplateRef<any>){
      if(this.menuItemForm.invalid){
        return;
      }

      const formData: MenuItem = this.menuItemForm.value;
      this.menuService.addMenuItem(formData).subscribe(() => {this.toastService.show({template:toastTemplate,classname: 'bg-success text-light'});
      this.router.navigate(['/menus']);
    })
}
back(){
  this.router.navigateByUrl('/menus');
}
}
