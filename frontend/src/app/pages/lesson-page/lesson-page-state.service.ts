import { Injectable } from '@angular/core';
import { Course } from '../../models/course.model';
import { State } from '../../shared/state/state';
import { CoursesService } from '../courses-page/courses.service';

export interface LessonPageState {
  readonly courseId?: string;
  readonly course?: Course;
  readonly isLoading: boolean;
}

const initialState: LessonPageState = {
  isLoading: false
};


@Injectable()
export class LessonPageStateService extends State<LessonPageState> {

  constructor(private courseService: CoursesService) {
    super(initialState);
  }

  async setCourseId(courseId: string): Promise<void> {
    this.setState(draft => {
      draft.isLoading = true;
    });
    try {
      const course = await this.courseService.getCourse(courseId).toPromise();
      this.setState(draft => {
        draft.isLoading = false;
        draft.courseId = courseId;
        draft.course = course;
      });
    } finally {
      this.setState(draft => {
        draft.isLoading = false;
      });
    }

  }
}
