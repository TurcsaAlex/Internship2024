import { Component, inject, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Product } from '../../../../../models/product';

@Component({
  selector: 'app-material-edit',
  templateUrl: './material-edit.component.html',
  styleUrl: './material-edit.component.css'
})
export class MaterialEditComponent {
  @Input() product!:Product;
	activeModal = inject(NgbActiveModal);
  get quantity(){
    return this.product.quantity;
  }

}
