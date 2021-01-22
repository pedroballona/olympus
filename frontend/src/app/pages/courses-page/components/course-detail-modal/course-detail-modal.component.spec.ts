import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { PoModalComponent } from '@po-ui/ng-components';
import { of } from 'rxjs';
import { Course } from '../../../../models/course.model';
import { CourseDetailModalComponent } from './course-detail-modal.component';

const course: Course = {
  title: 'Title',
  description: 'Description',
  firstClass: 'First Class',
  instructors: [
    'instructor 1',
    'instructor 2'
  ],
  score: 4
};

describe('CourseDetailModalComponent', () => {
  let component: CourseDetailModalComponent;
  let translateService: jasmine.SpyObj<TranslateService>;
  let modal: jasmine.SpyObj<PoModalComponent>;
  let changeDetectorRef: jasmine.SpyObj<ChangeDetectorRef>;
  let router: jasmine.SpyObj<Router>;

  beforeEach(() => {
    translateService = jasmine.createSpyObj('translate', ['get']);
    translateService.get.and.callFake((key) => of(key));
    modal = jasmine.createSpyObj('modal', ['open', 'close']);
    router = jasmine.createSpyObj('router', ['navigate']);
    changeDetectorRef = jasmine.createSpyObj('changeDetectorRef', ['detectChanges']);

    component = new CourseDetailModalComponent(
      changeDetectorRef,
      translateService,
      router
    );
    component.modal = modal;
  });

  it('open', () => {
    component.open('1', course);
    expect(component.course).toEqual(course);
    expect(component.courseId).toEqual('1');
    expect(modal.open).toHaveBeenCalled();
  });

  it('close', () => {
    component.course = course;
    component.courseId = '1';
    component.close();
    expect(modal.close).toHaveBeenCalled();
    expect(component.course).toBeNull();
    expect(component.courseId).toBeNull();
  });

  it('goToLesson', () => {
    component.goToLesson('1');
    expect(router.navigate).toHaveBeenCalledWith(['lesson', '1']);
  });
});
