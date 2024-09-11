import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BomEditComponent } from './bom-edit.component';

describe('BomEditComponent', () => {
  let component: BomEditComponent;
  let fixture: ComponentFixture<BomEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BomEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BomEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
