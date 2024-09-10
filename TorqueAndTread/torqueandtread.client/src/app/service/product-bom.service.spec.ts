import { TestBed } from '@angular/core/testing';

import { ProductBOMService } from './product-bom.service';

describe('ProductBOMService', () => {
  let service: ProductBOMService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductBOMService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
