import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../../models/user';
import { UserService } from '../../service/user.service';
import { ToastService } from '../../service/toast.service';

@Component({
  selector: 'app-user-add',
  templateUrl: './user-add.component.html',
  styleUrls: ['./user-add.component.css']
})
export class UserAddComponent implements OnInit {
  user: User | null = null;
  userForm: FormGroup=new FormGroup({
    userId: new FormControl(this.user?.userId || 0, Validators.required),
    name: new FormControl(this.user?.name || '', Validators.required),
    password: new FormControl(this.user?.password || '', Validators.required),
    userName: new FormControl(this.user?.userName || '', Validators.required),
    email: new FormControl(this.user?.email || '', [Validators.required, Validators.email]),
    active: new FormControl(this.user?.active|| false),
    createdOn: new FormControl({value:this.user?.createdOn || '',disabled:true}, Validators.required),
    lastUpdatedOn: new FormControl({value:this.user?.lastUpdatedOn || '',disabled:true}, Validators.required)
  });
  constructor(
    private userService:UserService,
    private router:Router,
    private toastService:ToastService
  ) {}

  ngOnInit(): void {
  }

  onSubmit(toastTemplate:TemplateRef<any>): void {
    if (this.userForm.valid) {
      const createdUser: User = this.userForm.value;
      console.log('User saved', createdUser);
      this.userService.createUser(createdUser).subscribe(()=>{
        this.toastService.show({template:toastTemplate,classname:'bg-success text-light',data:createdUser.userName});
        console.log("ok")
        this.router.navigateByUrl("/users");
      });
    }else{
      alert("Invalid Form");
    }
  }

  back(){
    this.router.navigateByUrl('/users');
  }
}
