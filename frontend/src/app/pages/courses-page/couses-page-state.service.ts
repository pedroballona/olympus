import { Injectable } from '@angular/core';
import { SimpleCourse } from '../../models/course.model';
import { State } from '../../shared/state/state';
import { CoursesService } from './courses.service';

export interface CoursesPageState {
  readonly page: SimpleCourse[];
  readonly currentPage: number;
  readonly hasNext: boolean;
  readonly isLoading: boolean;
}

const initialState: CoursesPageState = {
  page: [],
  currentPage: 1,
  hasNext: false,
  isLoading: false
};

@Injectable()
export class CoursesPageStateService extends State<CoursesPageState> {
  constructor(private coursesService: CoursesService) {
    super(initialState);
  }

  async initialize(): Promise<void> {
    this.forceSetState({... initialState});
    await this.getPage(this.snapshot.currentPage);
  }

  async getPage(pageNumber: number): Promise<void> {
    this.setState(draft => {
      draft.isLoading = true;
    });
    try {
      const result = await this.coursesService.getAllCourses(pageNumber).toPromise();
      this.setState(draft => {
        draft.page = draft.page.concat(result.items);
        draft.hasNext = result.hasNext;
        draft.currentPage = pageNumber;
      });
    } finally {
      this.setState(draft => {
        draft.isLoading = false;
      });
    }
  }

  async goToNextPage(): Promise<void> {
    return this.getPage(this.snapshot.currentPage + 1);
  }
}
