import { Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { SimpleCourse } from '../../../../models/course.model';
import { assert } from '../../../../shared/assert';
import { LoaderService } from '../../../../shared/totvs-loader/loader/loader.service';
import { CoursesService } from '../../courses.service';
import { CourseDetailModalComponent } from '../course-detail-modal/course-detail-modal.component';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent {
  @ViewChild(CourseDetailModalComponent)
  private modal: CourseDetailModalComponent | undefined;
  @Input() courses: SimpleCourse[] = [];
  @Input() hasNext = false;
  @Output() nextClicked = new EventEmitter<void>();

  constructor(private loaderService: LoaderService, private service: CoursesService) {}

  async onDetailsClicked(course: SimpleCourse): Promise<void> {
    assert(this.modal);
    this.loaderService.show();
    try {
      const courseDetails = await this.service.getCourse(course.id).toPromise();
      this.modal.open(courseDetails);
    } finally {
      this.loaderService.hide();
    }
  }
}
