import { Pipe, PipeTransform } from '@angular/core';

const rootUrl = 'assets/img/profile-image/';
const numberOfPfp = 4;

@Pipe({
  name: 'instructorImage'
})
export class InstructorImagePipe implements PipeTransform {

  transform(name: string): string {
    const hash = name
      .split('')
      .map((character) => character.charCodeAt(0))
      .reduce((accumulator, currentValue) => accumulator + currentValue);
    const arrayIndex = hash % numberOfPfp;
    return rootUrl + `pfp_${arrayIndex + 1}.jpg`;
  }

}
