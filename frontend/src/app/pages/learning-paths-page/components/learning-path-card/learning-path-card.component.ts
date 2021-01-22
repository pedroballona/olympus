import { Component, EventEmitter, Input, Output } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable, ReplaySubject } from "rxjs";
import { map } from "rxjs/operators";
import {
  LearningPath,
  LearningPathWithImage,
} from "src/app/models/learning-path.model";
import { CourseImageService } from "src/app/pages/courses-page/components/course-card/course-image.service";

@Component({
  selector: "app-learning-path-card",
  templateUrl: "./learning-path-card.component.html",
  styleUrls: ["./learning-path-card.component.css"],
})
export class LearningPathCardComponent {
  @Input() set learningPath(value: LearningPath) {
    this.learningPathSubject.next(value);
  }
  @Output() detailsClicked = new EventEmitter<void>();
  private learningPathSubject = new ReplaySubject<LearningPath>(1);
  mouseOverImage = false;

  learningPath$: Observable<LearningPathWithImage> = this.learningPathSubject.pipe(
    map((learningPath) => {
      const imageUrl = this.courseImageService.getImageUrlByName(
        learningPath.name
      );
      return {
        ...learningPath,
        imageUrl,
      };
    })
  );

  constructor(
    private courseImageService: CourseImageService,
    private activatedRouter: ActivatedRoute
  ) {}

  setMouseOverImage(value: boolean): void {
    this.mouseOverImage = value;
  }
}
