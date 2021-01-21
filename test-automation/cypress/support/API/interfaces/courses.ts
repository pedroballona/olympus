export interface Courses {
  hasNext: boolean;
  items: SimpleCourse[]
}

export interface SimpleCourse {
  id: string; 
  title: string;
}