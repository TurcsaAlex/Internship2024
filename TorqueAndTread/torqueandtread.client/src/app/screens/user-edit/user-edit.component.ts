import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../../models/user';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../service/user.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
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
  constructor(private route: ActivatedRoute,private userService:UserService,private router:Router) {}

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
        createdOn: this.user?.createdOn||'',
        lastUpdatedOn: this.user?.lastUpdatedOn || ''});
    });
  }
  
  onSubmit(): void {
    if (this.userForm.valid) {
      const updatedUser: User = this.userForm.value;
      console.log('User saved', updatedUser);
      this.userService.updateUser(updatedUser).subscribe(()=>{
        console.log("ok")
        this.router.navigateByUrl("/users");
      });
    }else{
      alert("Invalid Form");
    }
  }
}
