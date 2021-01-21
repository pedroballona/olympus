export interface SimpleCourse {
  readonly title: string;
  // alura slug, for get one
  readonly id: string;
}

export interface Course {
  readonly description:	string;
  readonly instructorsNames: string[];
  readonly score: number;
  readonly title: string;
}

export interface SimpleCourseWithImage extends SimpleCourse {
  readonly imageUrl: string;
}


