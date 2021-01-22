import { Injectable } from "@angular/core";
import { LearningPath } from "src/app/models/learning-path.model";
import { State } from "../../shared/state/state";
import { LearningPathsService } from "./learning-paths.service";

export interface LearningPathsPageState {
  readonly page: LearningPath[];
  readonly currentPage: number;
  readonly hasNext: boolean;
  readonly isLoading: boolean;
  readonly filter: string;
}

const initialState: LearningPathsPageState = {
  page: [],
  currentPage: 1,
  hasNext: false,
  isLoading: false,
  filter: "",
};

@Injectable()
export class LearningPathsPageStateService extends State<LearningPathsPageState> {
  constructor(private service: LearningPathsService) {
    super(initialState);
  }

  async initialize(filter = ""): Promise<void> {
    this.forceSetState({ ...initialState, filter });
    return this.getPage(this.snapshot.currentPage, this.snapshot.filter);
  }

  private async getPage(pageNumber: number, filter: string): Promise<void> {
    this.setState((draft) => {
      draft.isLoading = true;
    });
    try {
      const result = await this.service
        .getAllLearningPaths(pageNumber, filter)
        .toPromise();
      this.setState((draft) => {
        draft.page = draft.page.concat(result.items);
        draft.hasNext = result.hasNext;
        draft.currentPage = pageNumber;
      });
    } finally {
      this.setState((draft) => {
        draft.isLoading = false;
      });
    }
  }

  async goToNextPage(): Promise<void> {
    return this.getPage(this.snapshot.currentPage + 1, this.snapshot.filter);
  }
}
