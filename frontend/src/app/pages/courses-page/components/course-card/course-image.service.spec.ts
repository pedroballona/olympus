import { TestBed } from '@angular/core/testing';

import { CourseImageService } from './course-image.service';

describe('CourseImageService', () => {
  let service: CourseImageService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CourseImageService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
