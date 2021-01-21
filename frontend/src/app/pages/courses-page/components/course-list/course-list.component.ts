import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { SimpleCourse } from '../../../../models/course';

const courses: SimpleCourse[] = [
  {
    id: '1',
    instructors: ['Cristóvão', 'Pedro'],
    rating: 5,
    title: 'Fundamentos de Typescript'
  }
];

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CourseListComponent implements OnInit {
  courses: SimpleCourse[] = [];

  constructor() { }

  ngOnInit(): void {
    for (let index = 0; index < 100; index++) {
      this.courses.push({
        id: index.toString(),
        instructors: ['Cristóvão', 'Pedro'],
        rating: index % 10,
        title: 'Fundamentos de Typescript ' + (index + 1)
      });
    }
  }

}
