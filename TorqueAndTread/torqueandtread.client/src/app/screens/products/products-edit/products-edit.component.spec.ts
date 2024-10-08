import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsEditComponent } from './products-edit.component';

describe('ProductsEditComponent', () => {
  let component: ProductsEditComponent;
  let fixture: ComponentFixture<ProductsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProductsEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
