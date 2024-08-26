import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { mockRoles, UserRole } from '../../../models/role';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-roles-table',
  templateUrl: './roles-table.component.html',
  styleUrl: './roles-table.component.css'
})
export class RolesTableComponent implements OnInit, AfterViewInit {
  
  
  displayedColumns: string[] = ['name', 'active', 'createdOn', 'lastUpdatedOn' ,'actions' ];
  dataSource = new MatTableDataSource<UserRole>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;


  ngOnInit(): void {
      this.dataSource.data=mockRoles;
      this.dataSource.paginator=this.paginator;
  }
  
  ngAfterViewInit(): void {
    this.dataSource.data=mockRoles;
    this.dataSource.paginator=this.paginator;
  }
}
