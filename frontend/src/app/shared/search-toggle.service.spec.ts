import { TestBed } from '@angular/core/testing';

import { SearchToggleService } from './search-toggle.service';

describe('SearchToggleService', () => {
  let service: SearchToggleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchToggleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
