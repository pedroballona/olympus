import { ChangeDetectorRef, Component, OnInit, ViewChild } from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import { PoModalAction, PoModalComponent } from "@po-ui/ng-components";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { LearningPath } from "src/app/models/learning-path.model";
import { CoursesService } from "src/app/pages/courses-page/courses.service";
import { Course } from "../../../../models/course.model";
import { assert } from "../../../../shared/assert";

@Component({
  selector: "app-learning-path-detail-modal",
  templateUrl: "./learning-path-detail-modal.component.html",
  styleUrls: ["./learning-path-detail-modal.component.css"],
})
export class LearningPathDetailModalComponent implements OnInit {
  learningPath: LearningPath | null = null;
  courses: Course[] | null = null;
  primaryAction$: Observable<PoModalAction> = this.translateService
    .get("l-start-learning-path")
    .pipe(
      map((label) => {
        const action: PoModalAction = {
          label,
          action: () => {},
        };
        return action;
      })
    );
  secondaryAction$: Observable<PoModalAction> = this.translateService
    .get("l-close")
    .pipe(
      map((label) => {
        const action: PoModalAction = {
          label,
          action: () => this.modal?.close(),
        };
        return action;
      })
    );

  @ViewChild(PoModalComponent)
  modal: PoModalComponent | undefined;

  constructor(
    private changeDetectorRef: ChangeDetectorRef,
    private translateService: TranslateService,
    private courseService: CoursesService
  ) {}

  ngOnInit(): void {}

  async open(learningPath: LearningPath): Promise<void> {
    this.learningPath = learningPath;
    this.courses = [];

    for (var course of learningPath.courses) {
      this.courses.push(await this.courseService.getCourse(course).toPromise());
    }

    this.changeDetectorRef.detectChanges();
    assert(this.modal);
    this.modal.open();
  }

  close(): void {
    assert(this.modal);
    this.learningPath = null;
    this.courses = null;
    this.close();
  }
}
