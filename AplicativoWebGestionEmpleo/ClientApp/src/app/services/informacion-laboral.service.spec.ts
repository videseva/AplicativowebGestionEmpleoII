import { TestBed } from '@angular/core/testing';

import { InformacionLaboralService } from './informacion-laboral.service';

describe('InformacionLaboralService', () => {
  let service: InformacionLaboralService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InformacionLaboralService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
