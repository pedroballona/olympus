import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { PoModalAction, PoModalComponent } from '@po-ui/ng-components';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Course } from '../../../../models/course.model';
import { assert } from '../../../../shared/assert';

@Component({
  selector: 'app-course-detail-modal',
  templateUrl: './course-detail-modal.component.html',
  styleUrls: ['./course-detail-modal.component.css'],
})
export class CourseDetailModalComponent implements OnInit {
  course: Course | null = null;
  courseId: string | null = null;

  primaryAction$: Observable<PoModalAction> = this.translateService
    .get('l-start-course')
    .pipe(
      map((label) => {
        const action: PoModalAction = {
          label,
          action: () => {
            this.goToLesson(this.courseId);
          }
        };
        return action;
      })
    );
  secondaryAction$: Observable<PoModalAction> = this.translateService
    .get('l-close')
    .pipe(
      map((label) => {
        const action: PoModalAction = {
          label,
          action: () => this.modal?.close()
        };
        return action;
      })
    );

  @ViewChild(PoModalComponent)
  modal: PoModalComponent | undefined;

  constructor(
    private changeDetectorRef: ChangeDetectorRef,
    private translateService: TranslateService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  open(courseId: string, course: Course): void {
    this.course = course;
    this.courseId = courseId;
    this.changeDetectorRef.detectChanges();
    assert(this.modal);
    this.modal.open();
  }

  close(): void {
    assert(this.modal);
    this.course = null;
    this.courseId = null;
    this.close();
  }

  goToLesson(courseId: string): void {
    this.router.navigate(['lesson', courseId]);
  }
}
