import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { SimpleCourse } from '../../../../models/course.model';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CourseListComponent {
  @Input() courses: SimpleCourse[] = [];
  @Input() hasNext = false;
  @Output() nextClicked = new EventEmitter<void>();
}
