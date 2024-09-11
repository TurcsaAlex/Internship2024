import { Component, TemplateRef, ViewChild } from '@angular/core';
import { BOM } from '../../../models/bom';
import { Product } from '../../../models/product';
import { BOMService } from '../../../service/bom.service';
import { ProductService } from '../../../service/product.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { notInListValidator } from '../../../service/codeValidator';
import { ToastService } from '../../../service/toast.service';


@Component({
  selector: 'app-bom-edit',
  templateUrl: './bom-edit.component.html',
  styleUrl: './bom-edit.component.css'
})
export class BomEditComponent {
  selectedProduct:Product|null=null;
  products:Product[]=[];
  bom!:BOM;
  existingBOMCodes:string[]=[];

  bomForm:FormGroup= new FormGroup({
    bomId:new FormControl<number>(0,Validators.required),
    bomName: new FormControl('',Validators.required),
    bomCode:new FormControl<string>('',[Validators.required
      ,notInListValidator(this.existingBOMCodes)
    ])
  })
  constructor(
    private bomService:BOMService,
    private productService:ProductService,
    private router:Router,
    private toastService:ToastService
  ) {}
  ngOnInit(): void {
    
    this.productService.getAll().subscribe({
      next:(p)=>{this.products=p}
    })
    this.bomService.getBOMCodes().subscribe({
      next:(r)=>{this.existingBOMCodes=r; console.log(this.existingBOMCodes)}
    });

    this.bomService.getBOM(this.bomService.getBOMNumber()).subscribe({
      next:(r)=>{
        this.bom=r;
        if(r.materialId)
        {
          this.productService.getProduct(r.materialId!).subscribe({
            next:(r)=>{
              this.selectedProduct=r;
            }
          });
        }
        this.bomForm.patchValue({
          bomId: r.bomId,
          bomName: r.bomName,
          bomCode:r.bomCode
        });
      }
    });

  }
  
  onSubmit(toastTemplate:TemplateRef<any>): void {
    if (this.bomForm.valid && this.selectedProduct != null) {
      const createdBOM: BOM = this.bomForm.value;
      createdBOM.materialId=this.selectedProduct?.productId;
      console.log('BOM saved', createdBOM);
      this.bomService.updateBOM(createdBOM).subscribe(()=>{
        this.toastService.show({template:toastTemplate,classname:'bg-success text-light',data: createdBOM.bomName});
        console.log("ok")
        this.router.navigateByUrl("/boms");
      });
    }else{
      console.log(this.bomForm)
      alert("Invalid Form");
    }
  }
  selectProduct(product:Product){
    this.selectedProduct=product;
  }
  addMaterial(){

  }
  back(){
    this.router.navigateByUrl('/boms');
  }
}
