import { Component, TemplateRef } from '@angular/core';
import { Product } from '../../../models/product';
import { BOM } from '../../../models/bom';
import { BOMService } from '../../../service/bom.service';
import { ProductService } from '../../../service/product.service';
import { Router } from '@angular/router';
import { ToastService } from '../../../service/toast.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { notInListValidator } from '../../../service/codeValidator';

@Component({
  selector: 'app-bom-add',
  templateUrl: './bom-add.component.html',
  styleUrl: './bom-add.component.css'
})
export class BomAddComponent {
  selectedProduct:Product|null=null;
  products:Product[]=[];

  existingBOMCodes:string[]=[];
  bomForm:FormGroup= new FormGroup({
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

  }

  onSubmit(toastTemplate:TemplateRef<any>): void {
    if (this.bomForm.valid && this.selectedProduct != null) {
      const createdBOM: BOM = this.bomForm.value;
      createdBOM.materialId=this.selectedProduct?.productId;
      console.log('BOM saved', createdBOM);
      this.bomService.createBOM(createdBOM).subscribe(()=>{
        this.toastService.show({template:toastTemplate,classname:'bg-success text-light',data:createdBOM.bomName});
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

  back(){
    this.router.navigateByUrl('/boms');
  }
}
