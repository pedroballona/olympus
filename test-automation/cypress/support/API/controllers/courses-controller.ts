import * as interfaces from '../interfaces/courses';

const HTTP = 'http://localhost:5000';


export class CoursesController {

  private getCourses = `${HTTP}/api/courses`;


  getAllCourses(filter?: string): Cypress.Chainable<interfaces.Courses[]> {
    return cy.request(`${this.getCourses}?filter=${filter}`).then((coursesList) => {
      return coursesList.body as interfaces.Courses[];
    });
  }
}
