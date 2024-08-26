import { AfterViewInit, Component, inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { UserService } from '../../service/user.service';
import { User } from '../../models/user';
import { Router } from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { ToastService } from '../../service/toast.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  imports: [MatTableModule, MatPaginatorModule, CommonModule],
  standalone:true
})
export class UsersComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['username', 'name', 'email', 'active', 'createdOn', 'lastUpdatedOn' ,'actions' ];
  dataSource = new MatTableDataSource<User>();
  selectedUser?:User;
  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private userService: UserService, private router: Router,private toastService:ToastService,private modalService:NgbModal) {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.refreshUsers()
  }

  editUser(userId: number): void {
    this.userService.setUserId(userId);
    this.router.navigateByUrl('/edit-user');
  }
  
  deleteUser(user:User,template:TemplateRef<any>){
    this.userService.deleteUser(user.userId).subscribe(()=>{
      //this.dataSource.data=this.dataSource.data.filter(u=>u.userId!=userId);
      this.refreshUsers();
      this.toastService.show({ template, classname: 'bg-danger text-light', delay: 5000 ,data:user.userName });
    });
  }

  openDeleteModal(user:User,modalTemplate:TemplateRef<any>,toastTemplate:TemplateRef<any>){
    this.selectedUser=user;
    const modalRef = this.modalService.open(modalTemplate, { ariaLabelledBy: 'modal-basic-title'});
    modalRef.result.then(
			(result) => {
        switch (result){
          case 'Delete':
            this.deleteUser(user,toastTemplate);
            break;
          default:
            console.log('ok');
        }
			},
		);
    
  }
  addUser(){
    this.router.navigateByUrl('/add-user');
  }

  private refreshUsers(){
    this.userService.getAll().subscribe({
      next: (r) => {
        this.dataSource.data = r;
        this.dataSource.paginator = this.paginator;
      }
    });
  }
}
