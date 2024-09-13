import { AfterViewInit, Component, Input, OnChanges, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MenuService } from '../../../service/menu.service';
import { Role } from '../../../models/role'; 
import { MatPaginator } from '@angular/material/paginator';
import { AddmenuitemsroleComponent } from './addmenuitemsrole/addmenuitemsrole.component';
import { RoleService } from '../../../service/role.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-roletable',
  templateUrl: './roletable.component.html',
  styleUrl: './roletable.component.css'
})
export class RoletableComponent implements AfterViewInit, OnChanges{
  @Input() menuItemId: number | null = null;

  displayedColumns: string[] = ['name', 'active', 'createdOn', 'lastUpdatedOn', 'actions'];
  dataSource = new MatTableDataSource<Role>();
  role : Role[] = [];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  

  constructor(
    private roleService: RoleService,
    private modalService: NgbModal,
    private menuService: MenuService,
  ) {}
  

  ngOnChanges(): void {
    console.log('refresh roles:',this.menuItemId);
    this.refreshRoles();
  }
  ngAfterViewInit(){
    this.dataSource.paginator = this.paginator;
  }

  refreshRoles() {
    console.log('refresh roles for menuitemid:' , this.menuItemId);
    if (this.menuItemId) {
      this.roleService.getRolesByMenuItemId(this.menuItemId).subscribe({
        next: (roles) => {
          console.log('roles loaded:', roles);
          this.dataSource.data = roles;
          this.dataSource._updateChangeSubscription();
          this.dataSource.paginator = this.paginator;
          console.log('data source data:', this.dataSource.data);
        },
        error: (err) => {
          console.error('Failed to load roles', err);
        }
      });
    }
  }


  openAddModal() {
    console.log('opening modal with menuitemid: ', this.menuItemId);
    if(this.menuItemId !== null && this.menuItemId !== undefined){

      const modalRef = this.modalService.open(AddmenuitemsroleComponent);
    modalRef.componentInstance.roleIds = this.dataSource.data.map(r => r.roleId);
    modalRef.componentInstance.menuItemId = this.menuItemId;
    modalRef.result.then(
      (result) => {
        console.log('modal result:', result);
        if (result !== 'Close' && this.menuItemId) {
          console.log('MenuItemID:', this.menuItemId);
          console.log('add role with id:', result.roleId);
          this.roleService.addRoleToMenuItem(this.menuItemId, result.roleId).subscribe({
            next: () => {
              this.refreshRoles();
            },
            error: (err) => {
              console.error('Failed to add role', err);
            }
          });
        }
      },
      (dismissReason) => {
        console.log('Modal dismissed', dismissReason);
      }
    );
    }
    
  }


  deleteRole(roleId: number) {
    if(this.menuItemId)
      {
        console.log('dau delete la:', roleId, 'din menu item id:',this.menuItemId);
        this.roleService.removeRoleFromMenuItem(this.menuItemId, roleId).subscribe({
          next: () => {
            this.refreshRoles();
          },
          error: (err) => {
            console.error('Failed to delete role', err);
          }
        });
      }
  }
}

