import { Component, inject, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from '../../service/user.service';
import { WebcamComponent } from '../user-edit/webcam/webcam.component';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit{
  newPicture=false;
  user?:User|null=null;
  name:string='';
	activeModal = inject(NgbActiveModal);

  constructor(
    private userService:UserService,
    private modalService:NgbModal
  ){}
  ngOnInit(): void {
    const reader=new FileReader();
            reader.addEventListener('load',()=>{
              this.user!.profilePictureData=reader.result;
            });
    this.userService.getCurrentUser().subscribe({
      next:(r)=>{
        this.user=r;
        this.name=this.user.name;
        if(this.user?.profilePicturePath){
          this.userService.getImage(this.user.profilePicturePath).subscribe(
            (r:any)=>{
              if (r) {
                reader.readAsDataURL(r);
             }
            }
          );
        }
      }
    })
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
  submitUpdate(){
      const updatedUser: User = this.user!;
      updatedUser.profilePictureData=this.user!.profilePictureData;
      updatedUser.profilePicturePath=this.user!.profilePicturePath;
      updatedUser.name=this.name;
      console.log('User saved', updatedUser);
      if(this.newPicture)
        this.userService.updateUserWithPicture(updatedUser).subscribe({next:()=>this.activeModal.close(this.user!.profilePictureData)});
      else
        this.userService.updateUser(updatedUser).subscribe({next:()=>this.activeModal.close("ok")});
  }
}
