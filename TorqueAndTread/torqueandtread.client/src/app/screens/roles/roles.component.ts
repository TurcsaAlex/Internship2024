import { AfterViewInit, Component, inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { RoleService } from '../../service/role.service';
import { Role } from '../../models/role';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrl: './roles.component.css',
  imports: [MatTableModule, MatPaginatorModule, CommonModule],
  standalone:true
})
export class RolesComponent 
  implements OnInit,AfterViewInit{
    selectedColumns : string[] = ['name', 'active', 'createdOn','lastUpdatedOn'];
    roles: Role [] = [];
    dataSource = new MatTableDataSource<Role>();
    loaded=false;

      @ViewChild(MatPaginator) paginator!: MatPaginator;
      constructor(private roleService: RoleService) {}

      ngAfterViewInit(): void {
        this.dataSource.paginator = this.paginator;
      }
      ngOnInit(): void {
        this.loadRoles();
      }

      loadRoles() : void{
        this.roleService.getAll().subscribe({
          next:(roleItem) => {
            this.dataSource.data = roleItem;
            this.dataSource.paginator = this.paginator;
            this.loaded=true;
          }, error : (err) => {
            console.log('Failed to load roles',err);
          }
        })
      }
}
