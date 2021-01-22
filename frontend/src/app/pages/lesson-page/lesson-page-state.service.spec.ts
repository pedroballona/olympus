import { TestBed } from '@angular/core/testing';

import { LessonPageStateService } from './lesson-page-state.service';

describe('LessonPageStateService', () => {
  let service: LessonPageStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LessonPageStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
