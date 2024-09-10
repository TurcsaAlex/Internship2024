import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BomsComponent } from './boms.component';

describe('BomsComponent', () => {
  let component: BomsComponent;
  let fixture: ComponentFixture<BomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BomsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
