export interface SimpleCourse {
  readonly title: string;
  // alura slug, for get one
  readonly id: string;
}

export interface Course {
  readonly description: string;
  readonly instructors: string[];
  readonly score: number;
  readonly title: string;
  readonly firstClass: string;
}

export interface SimpleCourseWithImage extends SimpleCourse {
  readonly imageUrl: string;
}

export interface CoursesLookupItem {
  readonly id: string;
  readonly title: string;
}
