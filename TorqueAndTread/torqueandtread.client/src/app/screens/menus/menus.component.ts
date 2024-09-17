import { AfterViewInit, Component, inject, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MenuService } from '../../service/menu.service';
import { MenuItem } from './menu-item.model';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-menus',
  templateUrl: './menus.component.html',
  styleUrl: './menus.component.css',
  imports: [MatTableModule, MatPaginatorModule, CommonModule],
  standalone:true
})
export class MenusComponent 
implements OnInit,AfterViewInit{
  selectedColumns : string[] = ['name', 'orderNo', 'iconClass', 'link', 'createdOn','lastUpdatedOn', 'actions'];
    isEditing: boolean = false;
    dataSource = new MatTableDataSource<MenuItem>();
    loaded=false;
    selectedMenuItem?: MenuItem;
    
    @ViewChild(MatPaginator) paginator!: MatPaginator;
    constructor(private menuService : MenuService, private router: Router,private toastService:ToastService,private modalService:NgbModal) {}
   
    ngAfterViewInit(): void {
      this.dataSource.paginator = this.paginator;
    }
    ngOnInit(): void {
      this.loadMenuItems();
    }
   
    editMenuItem(menuItemId : number):void{
    // this.menuService.setMenuItemID(menuItemId);
      localStorage.setItem('currentMenuItemId',menuItemId.toString());
      this.menuService.getMenuItem(menuItemId).subscribe({next : (menuItem) => {this.selectedMenuItem = menuItem;
      this.router.navigateByUrl('/edit-menu-item');
      }})
       
 
  }
  

  deleteMenuItem(menuItem: MenuItem, template: TemplateRef<any>): void{
    if(menuItem.menuItemId !== undefined)
    {
      this.menuService.deleteMenuItem(menuItem.menuItemId).subscribe({
        next: () =>
        {
          const updatedData = this.dataSource.data.filter(item => item.menuItemId !== menuItem.menuItemId);
          this.dataSource.data = updatedData;
          this.toastService.show({ template, classname: 'bg-danger text-light',data:`Menu item deleted succesfully`});
        },
        error: (err) => { console.error('Failed to delete menu item',err);
        this.toastService.show({ template, classname: 'bg-danger text-light',data:menuItem.name });
        }
      });
    }else{
          console.error('Menu item ID is undefined');
    }
    }

  openDeleteModal(menuItem : MenuItem, modalTemplate : TemplateRef<any>, toastTemplate: TemplateRef<any>): void{
    this.selectedMenuItem = menuItem;
    const modalRef = this.modalService.open(modalTemplate,{ariaLabelledBy: 'modal-basic-title'});
    modalRef.result.then(
			(result) => {
        switch (result){
          case 'Delete':
            this.deleteMenuItem(menuItem,toastTemplate);
            break;
          default:
            console.log('Operation canceled');
        }

    },
  );
  }

  addMenuItem(): void{
    this.router.navigateByUrl('/add-menu-item');
  }
  
   loadMenuItems(): void {
    this.menuService.getMenuItems().subscribe({
      next:(menuItems) => {
        this.dataSource.data = menuItems;
        console.log("ce are menuitems: ", menuItems);
        this.dataSource.paginator = this.paginator;
        this.loaded=true;
      },
      error: (err) => {
        console.error('Failed to fetch menu items', err);
      }
    })
  }
}



