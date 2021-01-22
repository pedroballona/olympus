import { TestBed } from '@angular/core/testing';

import { LearningPathsPageStateService } from './learning-paths-page-state.service';

describe('LearningPathsPageStateService', () => {
  let service: LearningPathsPageStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LearningPathsPageStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
