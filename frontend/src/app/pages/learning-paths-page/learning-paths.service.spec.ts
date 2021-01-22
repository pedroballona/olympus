import { TestBed } from '@angular/core/testing';

import { LearningPathsService } from './learning-paths.service';

describe('LearningPathsService', () => {
  let service: LearningPathsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LearningPathsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
