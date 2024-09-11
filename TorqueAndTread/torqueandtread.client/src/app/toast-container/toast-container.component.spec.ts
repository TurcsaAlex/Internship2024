import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ToastsContainer } from './toast-container.component';

describe('ToastContainerComponent', () => {
  let component: ToastsContainer;
  let fixture: ComponentFixture<ToastsContainer>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ToastsContainer]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ToastsContainer);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
