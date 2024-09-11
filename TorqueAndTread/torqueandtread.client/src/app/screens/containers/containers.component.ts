import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Container } from '../../models/container';
import { ContainerService } from '../../service/container.service';

@Component({
  selector: 'app-containers',
  templateUrl: './containers.component.html',
  styleUrl: './containers.component.css'
})
export class ContainersComponent implements OnInit{
  displayedColumns: string[] = [ 'containerName', 'containerCode','productCode', 'quantity','UOM' ,'actions' ];
  dataSource = new MatTableDataSource<Container>();
  selectedContainer?:Container;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private containerService:ContainerService,
    private router: Router,
    private toastService:ToastService,
    private modalService:NgbModal
  ) {}


  ngOnInit(): void {

        this.refreshData();


  }
  refreshData(){
    this.containerService.getAll().subscribe({
      next:(r)=>{
        this.dataSource.data=r;
        this.dataSource.paginator=this.paginator;
      }
    })
    
  }
  editContainer(containter:Container){
    this.containerService.setContainerId(containter.containerId);
    this.router.navigateByUrl("/edit-container");
  }
  deleteContainer(container:Container,template:TemplateRef<any>){
    this.containerService.deleteContainer(container.containerId).subscribe(()=>{
      //this.dataSource.data=this.dataSource.data.filter(u=>u.userId!=userId);
      this.refreshData();
      this.toastService.show({ template, classname: 'bg-danger text-light', delay: 5000 ,data:container.name });
    });
  }
  openDeleteModal(container:Container,modalTemplate:TemplateRef<any>,toastTemplate:TemplateRef<any>){
    this.selectedContainer=container;
    const modalRef = this.modalService.open(modalTemplate, { ariaLabelledBy: 'modal-basic-title'});
    modalRef.result.then(
			(result) => {
        switch (result){
          case 'Delete':
            this.deleteContainer(container,toastTemplate);
            break;
          default:
            console.log('ok');
        }
			},
		);
  }
}
