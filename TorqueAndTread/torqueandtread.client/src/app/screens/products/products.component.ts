import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from '../../models/product';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProductService } from '../../service/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit{
  displayedColumns: string[] = [ 'productName', 'productCode','productType', 'createdOn', 'lastUpdatedOn' ,'actions' ];
  dataSource = new MatTableDataSource<Product>();
  selectedProduct?:Product;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private productService:ProductService,
    private router: Router,
    private toastService:ToastService,
    private modalService:NgbModal
  ) {}

  ngOnInit(){
    this.refreshProducts();
  }
  refreshProducts(){
    this.productService.getAll().subscribe({
      next:(r)=>{
        this.dataSource.data=r;
        this.dataSource.paginator=this.paginator;
      }
    })
  }
  editProduct(productId:number){
    console.log("haloo");
    this.productService.setProductId(productId);
    this.router.navigateByUrl("/edit-product");
  }
  deleteProduct(product:Product,template:TemplateRef<any>){
    this.productService.deleteProduct(product.productId).subscribe(()=>{
      //this.dataSource.data=this.dataSource.data.filter(u=>u.userId!=userId);
      this.refreshProducts();
      this.toastService.show({ template, classname: 'bg-danger text-light', delay: 5000 ,data:product.name });
    });
  }
  openDeleteModal(product:Product,modalTemplate:TemplateRef<any>,toastTemplate:TemplateRef<any>){
    this.selectedProduct=product;
    const modalRef = this.modalService.open(modalTemplate, { ariaLabelledBy: 'modal-basic-title'});
    modalRef.result.then(
			(result) => {
        switch (result){
          case 'Delete':
            this.deleteProduct(product,toastTemplate);
            break;
          default:
            console.log('ok');
        }
			},
		);
  }
  addProduct(){
    this.router.navigateByUrl("/add-product");
  }
}
