import {
  ChangeDetectionStrategy,
  Component,
  Input
} from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { SimpleCourse, SimpleCourseWithImage } from '../../../../models/course';
import { CourseImageService } from './course-image.service';

@Component({
  selector: 'app-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CourseCardComponent {
  @Input() set course(value: SimpleCourse) {
    this.courseSubject.next(value);
  }
  private courseSubject = new ReplaySubject<SimpleCourse>(1);

  course$: Observable<SimpleCourseWithImage> = this.courseSubject.pipe(
    map((simpleCourse) => {
      const imageUrl = this.courseImageService.getImageUrlByName(
        simpleCourse.title
      );
      return {
        ...simpleCourse,
        imageUrl,
      };
    })
  );

  constructor(private courseImageService: CourseImageService) {}
}
