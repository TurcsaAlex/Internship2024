import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../service/user.service';
import { User } from '../../models/user';
import { Router } from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  imports: [MatTableModule, MatPaginatorModule],
  standalone:true
})
export class UsersComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['username', 'name', 'email', 'active', 'createdOn', 'lastUpdatedOn' ,'actions' ];
  dataSource = new MatTableDataSource<User>();

  
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private userService: UserService, private router: Router) {}

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
  
  deleteUser(userId:number){
    this.userService.deleteUser(userId).subscribe(()=>{
      //this.dataSource.data=this.dataSource.data.filter(u=>u.userId!=userId);
      this.refreshUsers();
    });
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
