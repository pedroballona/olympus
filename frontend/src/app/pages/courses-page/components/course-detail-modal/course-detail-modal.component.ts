import { Component, OnInit, ViewChild } from '@angular/core';
import { PoModalComponent } from '@po-ui/ng-components';
import { SimpleCourseWithImage as SimpleCourse } from '../../../../models/course.model';
import { assert } from '../../../../shared/assert';

@Component({
  selector: 'app-course-detail-modal',
  templateUrl: './course-detail-modal.component.html',
  styleUrls: ['./course-detail-modal.component.css']
})
export class CourseDetailModalComponent implements OnInit {
  course: SimpleCourse | null = null;

  @ViewChild(PoModalComponent)
  modal: PoModalComponent | undefined;

  constructor() { }

  ngOnInit(): void {
  }

  open(course: SimpleCourse): void {
    assert(this.modal);
    this.course = course;
    this.modal.open();
  }

  close(): void {
    assert(this.modal);
    this.course = null;
    this.close();
  }

}
