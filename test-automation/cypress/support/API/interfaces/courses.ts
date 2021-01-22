export interface Courses {
  hasNext: boolean;
  items: SimpleCourse[];
}

interface SimpleCourse {
  id: string;
  title: string;
}

export interface CompleteCourse {
  title: string;
  score: number;
  instructors: {
    name: string;
    expertise: string[];
  }[];
  linkExternalCourse: string;
}
