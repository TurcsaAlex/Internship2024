import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { BOM } from '../../models/bom';
import { BOMService } from '../../service/bom.service';

@Component({
  selector: 'app-boms',
  templateUrl: './boms.component.html',
  styleUrl: './boms.component.css'
})
export class BomsComponent implements OnInit{
  displayedColumns: string[] = [ 'bomName', 'bomCode','materialCode','actions' ];
  dataSource = new MatTableDataSource<BOM>();
  selectedBOM?:BOM;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private bomService:BOMService,
    private router: Router,
    private toastService:ToastService,
    private modalService:NgbModal
  ) {}


  ngOnInit(): void {

        this.refreshData();


  }
  refreshData(){
    this.bomService.getAll().subscribe({
      next:(r)=>{
        this.dataSource.data=r;
        this.dataSource.paginator=this.paginator;
      }
    })
    
  }
  editBOM(bom:BOM){
    this.bomService.setBOMId(bom.bomId);
    this.router.navigateByUrl("/edit-bom");
  }
  deleteBOM(bom:BOM,template:TemplateRef<any>){
    this.bomService.deleteBOM(bom.bomId).subscribe(()=>{
      //this.dataSource.data=this.dataSource.data.filter(u=>u.userId!=userId);
      this.refreshData();
      this.toastService.show({ template, classname: 'bg-danger text-light', delay: 5000 ,data:bom.bomName });
    });
  }
  openDeleteModal(bom:BOM,modalTemplate:TemplateRef<any>,toastTemplate:TemplateRef<any>){
    this.selectedBOM=bom;
    const modalRef = this.modalService.open(modalTemplate, { ariaLabelledBy: 'modal-basic-title'});
    modalRef.result.then(
			(result) => {
        switch (result){
          case 'Delete':
            this.deleteBOM(bom,toastTemplate);
            break;
          default:
            console.log('ok');
        }
			},
		);
  }
}
