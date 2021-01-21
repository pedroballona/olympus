import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { PoModalComponent } from '@po-ui/ng-components';
import { Course } from '../../../../models/course.model';
import { assert } from '../../../../shared/assert';

@Component({
  selector: 'app-course-detail-modal',
  templateUrl: './course-detail-modal.component.html',
  styleUrls: ['./course-detail-modal.component.css']
})
export class CourseDetailModalComponent implements OnInit {
  course: Course | null = null;

  @ViewChild(PoModalComponent)
  modal: PoModalComponent | undefined;

  constructor(private changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit(): void {
  }

  open(course: Course): void {
    this.course = course;
    this.changeDetectorRef.detectChanges();
    assert(this.modal);
    this.modal.open();
  }

  close(): void {
    assert(this.modal);
    this.course = null;
    this.close();
  }

}
