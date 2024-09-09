import { Component, OnInit, TemplateRef } from '@angular/core';
import { ProductService } from '../../../service/product.service';
import { Router } from '@angular/router';
import { ToastService } from '../../../service/toast.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Product, ProductType, UOM } from '../../../models/product';

@Component({
  selector: 'app-products-add',
  templateUrl: './products-add.component.html',
  styleUrl: './products-add.component.css'
})
export class ProductsAddComponent implements OnInit{
  productTypes:ProductType[]=[];
  productUOMs:UOM[]=[];
  productForm:FormGroup= new FormGroup({
    name: new FormControl('',Validators.required),
    productCodeName: new FormControl('',Validators.required),
    productType:new FormControl<ProductType|null>(null,Validators.required),
    defaultUOM:new FormControl<UOM|null>(null,Validators.required)
  })
  constructor(
    private productService:ProductService,
    private router:Router,
    private toastService:ToastService
  ) {}
  ngOnInit(): void {
    this.productService.getAllTypes().subscribe({
      next:(ty)=>{
        this.productTypes=ty;
      }
    })
    this.productService.getAllUOMs().subscribe({
      next:(u)=>{
        this.productUOMs=u;
      }
    })
  }

  onSubmit(toastTemplate:TemplateRef<any>): void {
    if (this.productForm.valid) {
      const createdProduct: Product = this.productForm.value;
      createdProduct.uomId=createdProduct.defaultUOM.uomId;
      createdProduct.productTypeId=createdProduct.productType.productTypeId;
      console.log('Product saved', createdProduct);
      this.productService.createProduct(createdProduct).subscribe(()=>{
        this.toastService.show({template:toastTemplate,classname:'bg-success text-light',data:createdProduct.name});
        console.log("ok")
        this.router.navigateByUrl("/products");
      });
    }else{
      alert("Invalid Form");
    }
  }


  back(){
    this.router.navigateByUrl('/products');
  }
}
