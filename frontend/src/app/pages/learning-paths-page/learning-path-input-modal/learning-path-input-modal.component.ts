import {
  ChangeDetectorRef,
  Component,
  EventEmitter,
  OnInit,
  Output,
  ViewChild,
} from "@angular/core";
import { TranslateService } from "@ngx-translate/core";
import {
  PoModalAction,
  PoModalComponent,
  PoMultiselectFilterMode,
  PoMultiselectOption,
} from "@po-ui/ng-components";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { LearningPath } from "src/app/models/learning-path.model";
import { assert } from "src/app/shared/assert";
import { CoursesService } from "../../courses-page/courses.service";
import { LearningPathsService } from "../learning-paths.service";

enum roles {
  Apprentice,
  Trainee,
  Assistant,
  Technician,
  AnalystI,
  AnalystII,
  AnalystIII,
  Leader,
  Coordinator,
  Manager,
  ExecutiveManager,
  Director,
  SpecialistI,
  SpecialistII,
  Master,
  Expert,
  TechDirector,
}

@Component({
  selector: "app-learning-path-input-modal",
  templateUrl: "./learning-path-input-modal.component.html",
  styleUrls: ["./learning-path-input-modal.component.css"],
})
export class LearningPathInputModalComponent implements OnInit {
  primaryAction$: Observable<PoModalAction> = this.translateService
    .get("l-save")
    .pipe(
      map((label) => {
        const action: PoModalAction = {
          label,
          action: () => {
            this.save();
          },
        };
        return action;
      })
    );
  secondaryAction$: Observable<PoModalAction> = this.translateService
    .get("l-cancel")
    .pipe(
      map((label) => {
        const action: PoModalAction = {
          label,
          action: () => this.modal?.close(),
        };
        return action;
      })
    );

  rolesOptions: PoMultiselectOption[];
  coursesOptions: PoMultiselectOption[];
  filterMode: PoMultiselectFilterMode = 1;

  @Output() saved = new EventEmitter();

  @ViewChild(PoModalComponent)
  modal: PoModalComponent | undefined;
  courses$: Observable<
    PoMultiselectOption[]
  > = this.courseService.getCoursesLookup().pipe(
    map((courses) => {
      return courses.map((course) => {
        return { label: course.title, value: course.id };
      });
    })
  );

  model: Partial<LearningPath> = {};

  constructor(
    private changeDetectorRef: ChangeDetectorRef,
    private translateService: TranslateService,
    private courseService: CoursesService,
    private learningPathService: LearningPathsService
  ) {}

  async ngOnInit(): Promise<void> {
    this.rolesOptions = [];
    this.coursesOptions = [];

    for (let role in roles) {
      if (!isNaN(Number(role))) {
        this.rolesOptions.push({
          label: await this.translateService
            .get("l-" + roles[role].toLowerCase())
            .toPromise(),
          value: role,
        });
      }
    }
  }

  private async save(): Promise<void> {
    await this.learningPathService
      .inputLearningPath(this.model as LearningPath)
      .toPromise();

    this.saved.emit();
    this.modal.close();
  }

  public open(): void {
    this.model = {};

    assert(this.modal);
    this.modal.open();
  }
}
