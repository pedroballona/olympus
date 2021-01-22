import {
  Component,
  EventEmitter,
  Input,
  Output,
  ViewChild,
} from "@angular/core";
import { LearningPath } from "src/app/models/learning-path.model";
import { assert } from "../../../../shared/assert";
import { LoaderService } from "../../../../shared/totvs-loader/loader/loader.service";
import { LearningPathsService } from "../../learning-paths.service";
import { LearningPathDetailModalComponent } from "../learning-path-detail-modal/learning-path-detail-modal.component";

@Component({
  selector: "app-learning-path-list",
  templateUrl: "./learning-path-list.component.html",
  styleUrls: ["./learning-path-list.component.css"],
})
export class LearningPathListComponent {
  @ViewChild(LearningPathDetailModalComponent)
  private modal: LearningPathDetailModalComponent | undefined;
  @Input() learningPaths: LearningPath[] = [];
  @Input() hasNext = false;
  @Output() nextClicked = new EventEmitter<void>();

  constructor(
    private loaderService: LoaderService,
    private service: LearningPathsService
  ) {}

  async onDetailsClicked(learningPath: LearningPath): Promise<void> {
    assert(this.modal);
    this.loaderService.show();
    try {
      const learningPathDetails = await this.service
        .getLearningPath(learningPath.id)
        .toPromise();
      this.modal.open(learningPathDetails);
    } finally {
      this.loaderService.hide();
    }
  }
}
