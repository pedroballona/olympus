import { TestBed } from '@angular/core/testing';

import { CousesPageStateService } from './couses-page-state.service';

describe('CousesPageStateService', () => {
  let service: CousesPageStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CousesPageStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
