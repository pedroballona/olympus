/// <reference types="Cypress" />
import * as interfaces from '../interfaces/courses';
const HTTP = 'http://localhost:5000';

export class CoursesController {
  private courses = `${HTTP}/api/v1/courses`;

  getAllCourses(filter = '', pageSize = 5, order = 'title'): Cypress.Chainable<interfaces.Courses> {
    return cy
      .request('GET', `${this.courses}?filter=${filter}&pageSize=${pageSize}&order=${order}`)
      .then((coursesList) => {
        return coursesList.body as interfaces.Courses;
      });
  }

  getOneCourseDetail(courseId: string) {
    return cy.request('GET', this.courses + `/${courseId}`).then((response) => {
      return response.body as interfaces.CourseDetail;
    });
  }

  putCourses(course: interfaces.NewCourse): void {
    cy.request('POST', this.courses, course).then((res) => {
      console.log(res.body);
    });
  }
}
