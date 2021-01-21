import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
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
  primaryAction$: Observable<PoModalAction> = this.translateService
    .get('l-start-course')
    .pipe(
      map((label) => {
        const action: PoModalAction = {
          label,
          action: () => {}
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
    private translateService: TranslateService
  ) {}

  ngOnInit(): void {}

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
