import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormRecord, isFormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { MenuService } from '../../service/menu.service';
import { MenuItem } from '../menus/menu-item.model';
import { IconService } from '../../service/icon.service';

@Component({
  selector: 'app-menu-add',
  templateUrl: './menu-add.component.html',
  styleUrl: './menu-add.component.css'
})
export class MenuAddComponent implements OnInit{
  menuItemForm : FormGroup;
  fontAwesomeIcons: string[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private menuService: MenuService,
    private toastService: ToastService,
    private router: Router,
    private iconService: IconService){
    this.menuItemForm = this.formBuilder.group({
        name:['',Validators.required],
        orderNo:['',Validators.required],
        iconClass:[''],
        link:['']
      })
    }

    ngOnInit(): void {
      this.fontAwesomeIcons = this.iconService.getIcons(); //get icons from service
    }

    onSubmit(toastTemplate:TemplateRef<any>){
      if(this.menuItemForm.valid){
      const formData: MenuItem = this.menuItemForm.value;
      console.log('form data: ', formData);
      this.menuService.addMenuItem(formData).subscribe({
        next: (addMenuITems) => {
          console.log('added menu item: ', addMenuITems);
          this.toastService.show({
            template: toastTemplate,
            classname: 'bg-success text-light',
            data: { name: formData.name, action: 'added' }
          });
          this.router.navigate(['/menus']);
        
        },
        error: (err) => {
          console.error('Failed to add menu item', err);
          this.toastService.show({
            template: toastTemplate,
            classname: 'bg-danger text-light',
            data: { name: formData.name, action: 'addition failed' }
          });
        }
      });
    } else {
      alert('Please fill out the form before submitting');
    }
  }


back(){
  this.router.navigateByUrl('/menus');
}
}
