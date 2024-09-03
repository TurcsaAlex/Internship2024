import { AfterViewInit, Component, Input, OnChanges, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MenuItem } from '../../menus/menu-item.model';
import { MatPaginator } from '@angular/material/paginator';
import { AddMenuitemsRolesComponent } from './add-menuitems-roles/add-menuitems-roles.component';
import { RoleService } from '../../../service/role.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';



@Component({
  selector: 'app-roles-table',
  templateUrl: './roles-table.component.html',
  styleUrl: './roles-table.component.css'
})
export class RolesTableComponent  implements OnChanges{
  @Input() menuItem: MenuItem | null = null;

  displayedColumns: string [] = ['name','active','createdOn','lastUpdatedOn','actions'];

}
