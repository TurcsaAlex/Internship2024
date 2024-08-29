import { Component, inject, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Role } from '../../../../models/role';
import { RoleService } from '../../../../service/role.service';

@Component({
  selector: 'app-add-user-roles',
  templateUrl: './add-user-roles.component.html',
  styleUrl: './add-user-roles.component.css'
})
export class AddUserRolesComponent implements OnInit{
  @Input() roleIds:number[]=[];
  
  roles:Role[]=[];
  selectedRole:Role|null=null;
	activeModal = inject(NgbActiveModal);
  constructor(
    private roleService:RoleService
  ){}

  ngOnInit(): void {
    this.roleService.getAll().subscribe(
      {
        next:(r)=>{
          this.roles=r.filter(r=>!this.roleIds.includes(r.roleId));
        },
        error:(r)=>{
          console.log(r);
        }
      }
    )
  }

}
