import { TestBed } from '@angular/core/testing';
import { CoursesPageStateService } from './couses-page-state.service';


describe('CoursesPageStateService', () => {
  let service: CoursesPageStateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoursesPageStateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
