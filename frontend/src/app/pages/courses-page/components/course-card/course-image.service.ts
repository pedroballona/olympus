import { Injectable } from '@angular/core';

const rootUrl = 'assets/img/course-images/';
const numberOfImages = 19;

@Injectable({
  providedIn: 'root',
})
export class CourseImageService {
  getImageUrlByName(name: string): string {
    const hash = name
      .split('')
      .map((character) => character.charCodeAt(0))
      .reduce((accumulator, currentValue) => accumulator + currentValue);
    const arrayIndex = hash % numberOfImages;
    return rootUrl + `course_${arrayIndex + 1}.jpg`;
  }
}
