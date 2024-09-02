import { Component, TemplateRef } from '@angular/core';
import { Product, ProductType, UOM } from '../../../models/product';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProductService } from '../../../service/product.service';
import { Router } from '@angular/router';
import { ToastService } from '../../../service/toast.service';

@Component({
  selector: 'app-products-edit',
  templateUrl: './products-edit.component.html',
  styleUrl: './products-edit.component.css'
})
export class ProductsEditComponent {
  productTypes:ProductType[]=[];
  productUOMs:UOM[]=[];
  product:Product | null=null;
  productForm:FormGroup= new FormGroup({
    productId: new FormControl(this.product?.productId || 0, Validators.required),
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
    const pid=this.productService.getProductNumber();
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
    this.productService.getProduct(pid).subscribe({
        next:(p)=>{
          console.log(p);
          this.product=p;
          this.productForm.patchValue({
          productId: this.product.productId,
          name: this.product?.name,
          productCodeName: this.product?.productCodeName,
          productType:{
            productTypeId:this.product?.productTypeId,
            productTypeName:this.product?.productTypeName,
          },
          defaultUOM:{
            uomId:this.product?.uomId,
            uomName:this.product?.uomName,
          }
        })}
      }
    )
    
  }

  onSubmit(toastTemplate:TemplateRef<any>): void {
    if (this.productForm.valid) {
      const createdUser: Product = this.productForm.value;
      createdUser.uomId=createdUser.defaultUOM.uomId;
      createdUser.productTypeId=createdUser.productType.productTypeId;
      console.log('User edited', createdUser);
      this.productService.editProduct(createdUser).subscribe(()=>{
        this.toastService.show({template:toastTemplate,classname:'bg-success text-light',data:createdUser.name});
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
