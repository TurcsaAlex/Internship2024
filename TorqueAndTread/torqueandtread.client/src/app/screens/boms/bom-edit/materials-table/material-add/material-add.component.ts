import { Component, inject, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ProductService } from '../../../../../service/product.service';
import { Product } from '../../../../../models/product';

@Component({
  selector: 'app-material-add',
  templateUrl: './material-add.component.html',
  styleUrl: './material-add.component.css'
})
export class MaterialAddComponent {
  @Input() roleIds:number[]=[];
  @Input() bomId:number=0;

  quantity=0;
  products:Product[]=[];
  selectedProduct:Product|null=null;
	activeModal = inject(NgbActiveModal);
  constructor(
    private productService:ProductService
  ){}

  ngOnInit(): void {
    this.productService.getAll().subscribe(
      {
        next:(r)=>{
          this.products=r.filter(r=>!this.roleIds.includes(r.productId));
        },
        error:(r)=>{
          console.log(r);
        }
      }
    )
  }

  closeModal(){
    let x={
      bomId : this.bomId,
      quantity:this.quantity,
      productId:this.selectedProduct?.productId
    };
    this.activeModal.close(x);
  }
}
