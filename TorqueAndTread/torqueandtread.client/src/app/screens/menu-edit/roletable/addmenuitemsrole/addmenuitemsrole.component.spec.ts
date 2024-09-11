import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddmenuitemsroleComponent } from './addmenuitemsrole.component';

describe('AddmenuitemsroleComponent', () => {
  let component: AddmenuitemsroleComponent;
  let fixture: ComponentFixture<AddmenuitemsroleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddmenuitemsroleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddmenuitemsroleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
