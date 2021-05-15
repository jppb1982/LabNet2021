import { TestBed } from '@angular/core/testing';

import { AbmProductosService } from './abm-productos.service';

describe('AbmProductosService', () => {
  let service: AbmProductosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AbmProductosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
