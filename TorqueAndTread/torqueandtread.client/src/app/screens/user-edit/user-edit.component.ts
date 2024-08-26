import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../../models/user';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../service/user.service';
import { DatePipe } from '@angular/common';
import { ToastService } from '../../service/toast.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css'],
  providers:[DatePipe]
})
export class UserEditComponent implements OnInit {
  user: User | null = null;
  userForm: FormGroup=new FormGroup({
    userId: new FormControl(this.user?.userId || 0, Validators.required),
    name: new FormControl(this.user?.name || '', Validators.required),
    userName: new FormControl(this.user?.userName || '', Validators.required),
    email: new FormControl(this.user?.email || '', [Validators.required, Validators.email]),
    active: new FormControl(this.user?.active|| false),
    createdOn: new FormControl({value:this.user?.createdOn || '',disabled:true}, Validators.required),
    lastUpdatedOn: new FormControl({value:this.user?.lastUpdatedOn || '',disabled:true}, Validators.required)
  });
  constructor(
    private datePipe: DatePipe,
    private userService:UserService,
    private router:Router,
    private toastService:ToastService
  ) {}

  ngOnInit(): void {
    var userId=this.userService.getUserId();

    this.userService.getUser(userId).subscribe(resp=>{
      this.user=resp?resp:null;
      console.log(this.user);

      this.userForm.patchValue({
        userId: this.user?.userId,
        name: this.user?.name ,
        userName: this.user?.userName ,
        email: this.user?.email || '',
        active:this.user?.active || false,
        createdOn: this.datePipe.transform(this.user?.createdOn||'',"medium"),
        lastUpdatedOn: this.datePipe.transform(this.user?.lastUpdatedOn || '',"medium") });
    });
  }
  
  onSubmit(toastTemplate:TemplateRef<any>): void {
    if (this.userForm.valid) {
      const updatedUser: User = this.userForm.value;
      console.log('User saved', updatedUser);
      this.userService.updateUser(updatedUser).subscribe(()=>{
        this.toastService.show({template:toastTemplate,classname:'bg-success text-light',data:this.user?.userName});
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
