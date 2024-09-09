import { Component, TemplateRef } from '@angular/core';
import { Product, UOM } from '../../../models/product';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ContainerService } from '../../../service/container.service';
import { Router } from '@angular/router';
import { ToastService } from '../../../service/toast.service';
import { Container, ContainerType } from '../../../models/container';
import { ProductService } from '../../../service/product.service';
import { notInListValidator } from '../../../service/codeValidator';

@Component({
  selector: 'app-container-add',
  templateUrl: './container-add.component.html',
  styleUrl: './container-add.component.css'
})
export class ContainerAddComponent {
  containerUOMs:UOM[]=[];
  containerTypes:ContainerType[]=[];
  selectedProduct:Product|null=null;
  products:Product[]=[];

  existingContainerCodes:string[]=[];
  containerForm:FormGroup= new FormGroup({
    name: new FormControl('',Validators.required),
    quantity:new FormControl<number|null>(null,[Validators.min(0)]),
    containerType:new FormControl<ContainerType|null>(null,Validators.required),
    defaultUOM:new FormControl<UOM|null>(null),
    containerCode:new FormControl<string>('',[Validators.required,notInListValidator(this.existingContainerCodes)])
  })
  constructor(
    private containerService:ContainerService,
    private productService:ProductService,
    private router:Router,
    private toastService:ToastService
  ) {}
  ngOnInit(): void {
    this.productService.getAllUOMs().subscribe({
      next:(u)=>{
        this.containerUOMs=u;
      }
    })
    this.containerService.getAllTypes().subscribe({
      next:(t)=>{
        this.containerTypes=t;
      }
    })
    this.productService.getAll().subscribe({
      next:(p)=>{this.products=p}
    })
    this.containerService.getContainerCodes().subscribe({
      next:(r)=>{this.existingContainerCodes=r; console.log(this.existingContainerCodes)}
    });

  }

  onSubmit(toastTemplate:TemplateRef<any>): void {
    if (this.containerForm.valid) {
      const createdContainer: Container = this.containerForm.value;
      createdContainer.uomId=this.containerForm.value.defaultUOM?this.containerForm.value.defaultUOM.uomId:null;
      createdContainer.containerTypeId=this.containerForm.value.containerType.containerTypeId;
      createdContainer.productId=this.selectedProduct?.productId;
      console.log('Container saved', createdContainer);
      this.containerService.createContainer(createdContainer).subscribe(()=>{
        this.toastService.show({template:toastTemplate,classname:'bg-success text-light',data:createdContainer.name});
        console.log("ok")
        this.router.navigateByUrl("/containers");
      });
    }else{
      alert("Invalid Form");
    }
  }
  selectProduct(product:Product){
    this.selectedProduct=product;
    this.containerForm.get("defaultUOM")?.setValue({
      uomId:product.uomId,
      uomName:product.uomName
    });
    this.containerForm.get('defaultUOM')?.setValidators(Validators.required);
  }

  back(){
    this.router.navigateByUrl('/containers');
  }
}
