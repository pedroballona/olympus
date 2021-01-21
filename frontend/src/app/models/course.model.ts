export interface SimpleCourse {
  readonly title: string;
  // alura slug, for get one
  readonly id: string;
}

export interface SimpleCourseWithImage extends SimpleCourse {
  readonly imageUrl: string;
}
