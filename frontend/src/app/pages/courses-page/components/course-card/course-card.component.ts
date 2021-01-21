import {
  Component,
  EventEmitter,
  Input,
  Output
} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { SimpleCourse, SimpleCourseWithImage } from '../../../../models/course.model';
import { CourseImageService } from './course-image.service';

@Component({
  selector: 'app-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.css'],
})
export class CourseCardComponent {
  @Input() set course(value: SimpleCourse) {
    this.courseSubject.next(value);
  }
  @Output() detailsClicked = new EventEmitter<void>();
  private courseSubject = new ReplaySubject<SimpleCourse>(1);
  mouseOverImage = false;

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

  constructor(private courseImageService: CourseImageService, private activatedRouter: ActivatedRoute) {}

  setMouseOverImage(value: boolean): void {
    this.mouseOverImage = value;
  }
}
