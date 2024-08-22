import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductionordersComponent } from './productionorders.component';

describe('ProductionordersComponent', () => {
  let component: ProductionordersComponent;
  let fixture: ComponentFixture<ProductionordersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProductionordersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductionordersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
