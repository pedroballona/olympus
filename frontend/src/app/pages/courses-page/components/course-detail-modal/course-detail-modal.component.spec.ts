import { TranslateService } from '@ngx-translate/core';
import { Observable, of } from 'rxjs';
import { CourseDetailModalComponent } from './course-detail-modal.component';


class TranslateServiceMock {
  get(key: string): Observable<string> {
    return of(key);
  }
}

describe('CourseDetailModalComponent', () => {
  let component: CourseDetailModalComponent;
  let translateService: jasmine.SpyObj<TranslateService>;

  beforeEach(() => {
    translateService = jasmine.createSpyObj('teste', ['get']);
    translateService.get.and.callFake(key => of(key));
  });
});
