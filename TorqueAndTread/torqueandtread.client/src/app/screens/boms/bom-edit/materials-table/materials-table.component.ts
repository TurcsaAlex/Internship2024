import { Component, Input, OnChanges, ViewChild } from '@angular/core';
import { Product } from '../../../../models/product';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ProductBOMService } from '../../../../service/product-bom.service';
import { BOM } from '../../../../models/bom';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MaterialAddComponent } from './material-add/material-add.component';
import { MaterialEditComponent } from './material-edit/material-edit.component';

@Component({
  selector: 'app-materials-table',
  templateUrl: './materials-table.component.html',
  styleUrl: './materials-table.component.css'
})
export class MaterialsTableComponent implements OnChanges{
  
  @Input() bom!:BOM;
  hasProducts=false;
  loaded=false;
  displayedColumns: string[] = [ 'productName', 'productCode','productType','quantity', 'createdOn', 'lastUpdatedOn',"actions"];
  dataSource = new MatTableDataSource<Product>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private productService:ProductBOMService,
    private modalService:NgbModal
  ){}
  ngOnChanges(): void {
    this.refreshMaterials()
  }
  
  refreshMaterials(){
    this.productService.getByBOMId(this.bom.bomId).subscribe({
      next:(r)=>{
        if(r.length!=0)
          this.hasProducts=true;
        this.dataSource.data=r;
        this.dataSource.paginator=this.paginator;
        this.loaded=true;
      }
    });
  }
  

    addMaterial(){
      const modalRef=this.modalService.open(MaterialAddComponent);
      modalRef.componentInstance.roleIds=this.dataSource.data.map(r=>r.productId);
      modalRef.componentInstance.bomId=this.bom.bomId;

      modalRef.result.then(
        (result)=>{
          if(result!="Close"){
            this.productService.createProductBOM({
              productId:result.productId,
              bomId:this.bom.bomId,
              quantity:result.quantity
            }).subscribe({
              next:(e)=>{
                console.log(e)
                this.refreshMaterials()
              }
            });
          }else{
          }
          console.log(result);
        }
      );
    }
    editProduct(product:Product){
      const modalRef=this.modalService.open(MaterialEditComponent);
      modalRef.componentInstance.product=product

      modalRef.result.then(
        (result)=>{
          if(result!="Close"){
            this.productService.updateBOM({
              productId:product.productId,
              bomId:this.bom.bomId,
              quantity:result
            }).subscribe({
              next:(e)=>{
                console.log(e)
                this.refreshMaterials()
              }
            });
          }else{
          }
          console.log(result);
        }
      );
    }
    deleteProduct(product:Product){
      this.productService.deleteProductBOM({bomId:this.bom.bomId,productId:product.productId,quantity:0}).subscribe({
        next:()=>{
          this.refreshMaterials()
        }
      })
    }
}
