import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoletableComponent } from './roletable.component';

describe('RoletableComponent', () => {
  let component: RoletableComponent;
  let fixture: ComponentFixture<RoletableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RoletableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RoletableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
