import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../../models/user';
import { Router } from '@angular/router';
import { UserService } from '../../service/user.service';
import { DatePipe } from '@angular/common';
import { ToastService } from '../../service/toast.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { WebcamComponent } from './webcam/webcam.component';

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
  private newPicture:boolean=false;
  constructor(
    private datePipe: DatePipe,
    private userService:UserService,
    private router:Router,
    private toastService:ToastService,
    private modalService:NgbModal
  ) {}


  ngOnInit(): void {
    var userId=this.userService.getUserId();
    const reader=new FileReader();
            reader.addEventListener('load',()=>{
              this.user!.profilePictureData=reader.result;
            });
    this.userService.getUser(userId).subscribe(resp=>{
      this.user=resp?resp:null;
      console.log(this.user);
      if(this.user?.profilePicturePath){
        this.userService.getImage(this.user.profilePicturePath).subscribe(
          (r:any)=>{
            if (r) {
              reader.readAsDataURL(r);
           }
          }
        );
      }
      this.userForm.patchValue({
        userId: this.user?.userId,
        name: this.user?.name ,
        userName: this.user?.userName ,
        email: this.user?.email || '',
        active:this.user?.active || false,
        createdOn: this.datePipe.transform(this.user?.createdOn||'',"medium"),
        lastUpdatedOn: this.datePipe.transform(this.user?.lastUpdatedOn || '',"medium"),
      });
    });
  }
  
  onSubmit(toastTemplate:TemplateRef<any>): void {
    const afterUpdate = ()=>{
      this.toastService.show({template:toastTemplate,classname:'bg-success text-light',data:this.user?.userName});
      this.router.navigateByUrl("/users");
    }
    if (this.userForm.valid) {
      const updatedUser: User = this.userForm.value;
      updatedUser.profilePictureData=this.user!.profilePictureData;
      updatedUser.profilePicturePath=this.user!.profilePicturePath;
      console.log('User saved', updatedUser);
      if(this.newPicture)
        this.userService.updateUserWithPicture(updatedUser).subscribe(afterUpdate);
      else
        this.userService.updateUser(updatedUser).subscribe(afterUpdate);
    }else{
      alert("Invalid Form");
    }
  }
  openCameraModal(){
    this.newPicture=true;
    const modalRef=this.modalService.open(WebcamComponent);
    modalRef.result.then(
      (result)=>{
        if(result!="Close"){
          this.user!.profilePictureData=result;
        }else{
          this.newPicture=false;
        }
        console.log(result);
      }
    );
  }
  
  back(){
    this.router.navigateByUrl('/users');
  }
}
