export interface LearningPath {
  readonly id: string;
  readonly name: string;
  readonly description: string;
  readonly courses: string[];
  readonly employeeRoles: string[];
}

export interface LearningPathWithImage extends LearningPath {
  readonly imageUrl: string;
}
