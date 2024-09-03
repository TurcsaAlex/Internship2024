import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMenuitemsRolesComponent } from './add-menuitems-roles.component';

describe('AddMenuitemsRolesComponent', () => {
  let component: AddMenuitemsRolesComponent;
  let fixture: ComponentFixture<AddMenuitemsRolesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddMenuitemsRolesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddMenuitemsRolesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
