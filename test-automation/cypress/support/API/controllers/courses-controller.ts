/// <reference types="Cypress" />
import * as interfaces from '../interfaces/courses';
const HTTP = 'http://localhost:5000';

export class CoursesController {
  private courses = `${HTTP}/api/v1/courses`;

  getAllCourses(filter?: string): Cypress.Chainable<interfaces.Courses> {
    return cy.request(`${this.courses}?filter=${filter}&pageSize=5&order=title`).then((coursesList) => {
      return coursesList.body as interfaces.Courses;
    });
  }

  putCourses(course: interfaces.SimpleCourse): void {
    cy.request('POST', this.courses, course).then( res => {
      console.log(res.body)
    });
  }
}
