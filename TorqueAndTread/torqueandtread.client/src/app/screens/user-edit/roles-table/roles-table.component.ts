import { AfterViewInit, Component, Input, OnChanges, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UserRole } from '../../../models/role';
import { MatPaginator } from '@angular/material/paginator';
import { User } from '../../../models/user';
import { RoleService } from '../../../service/role.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddUserRolesComponent } from './add-user-roles/add-user-roles.component';

@Component({
  selector: 'app-roles-table',
  templateUrl: './roles-table.component.html',
  styleUrl: './roles-table.component.css'
})
export class RolesTableComponent implements OnChanges {
  @Input() user:User|null=null;
  
  displayedColumns: string[] = ['name', 'active', 'createdOn', 'lastUpdatedOn' ,'actions' ];
  dataSource = new MatTableDataSource<UserRole>();
  loaded=false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private roleService:RoleService,
    private modalService:NgbModal
  ){}
  
  ngOnChanges(): void {
    this.refreshUserRoles()
  }

  
  refreshUserRoles(){
    if(this.user){
      this.roleService.getAllByUserId(this.user!.userId).subscribe(
        {
          next:(ur)=>{
            this.dataSource.data=ur;
            this.dataSource.paginator=this.paginator;
            this.loaded=true;
          },
        }
      );
    }
  }

  openAddModal(){
    const modalRef=this.modalService.open(AddUserRolesComponent);
    modalRef.componentInstance.roleIds=this.dataSource.data.map(r=>r.roleId);
    modalRef.result.then(
      (result)=>{
        if(result!="Close"){
          this.roleService.createUserRole(this.user!.userId,result.roleId).subscribe({
            next:(e)=>{
              console.log(e)
              this.refreshUserRoles()
            }
          });
        }else{
        }
        console.log(result);
      }
    );
  }

  deleteRole(roleId:number){
    this.roleService.deleteUserRole(this.user!.userId,roleId).subscribe({
      next:(e)=>{
        console.log(e)
        this.refreshUserRoles()
      }
    });
  }
  
}
