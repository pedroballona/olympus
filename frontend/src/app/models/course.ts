export interface SimpleCourse {
  readonly title: string;
  readonly rating: number;
  // alura slug, for get one
  readonly id: string;
  readonly instructors: string[];
}

export interface SimpleCourseWithImage extends SimpleCourse {
  readonly imageUrl: string;
}
