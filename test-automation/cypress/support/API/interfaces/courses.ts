export interface Courses {
  hasNext: boolean;
  items: SimpleCourse[];
}

interface SimpleCourse {
  id?: string;
  title: string;
}

export interface NewCourse {
  title: string;
  score: number;
  instructors: {
    name: string;
    expertise: string[];
  }[];
  linkExternalCourse: string;
  externalId: string;
  firstClass: string;
}

export interface CourseDetail {
  title: string;
  description: string;
  score: number;
  instructors: string[];
  firstClass: string;
}
