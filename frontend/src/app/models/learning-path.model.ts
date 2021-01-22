export interface LearningPath {
  id: string;
  name: string;
  description: string;
  courses: string[];
  employeeRoles: number[];
}

export interface LearningPathWithImage extends LearningPath {
  readonly imageUrl: string;
}
