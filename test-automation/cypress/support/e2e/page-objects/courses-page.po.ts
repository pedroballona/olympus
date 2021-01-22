/// <reference types="Cypress" />


export class Courses {
  private widgetCourse = 'app-course-card';
  private buttonLoadMore = '.show-more button';
  private widgetActions = '.po-widget-action';
  private modalTitle = 'po-modal .po-modal-title';
  private modalInstructor = 'po-modal .instructor-name';
  private modalDescription = 'po-modal .description';

  getAllCourses() {
    return cy.get(this.widgetCourse).parent();
  }

  getCourseTitle(idx: number): Cypress.Chainable<string> {
    return this.getAllCourses()
      .eq(idx)
      .find('.title')
      .invoke('text')
      .then((label) => {
        return label as string;
      });
  }

  getLabelFromButton(): Cypress.Chainable<string> {
    return cy
      .get(this.buttonLoadMore)
      .invoke('text')
      .then((label) => {
        return label as string;
      });
  }

  clickOnLoadMoreButton(): void {
    cy.get(this.buttonLoadMore).click().wait(1_000);
  }

  clickOnWidgetAction(buttonName: string, idx: number): void {
    this.getAllCourses().eq(idx).find(this.widgetActions).contains(buttonName).click();
  }

  getCourseTitleFromModal(): Cypress.Chainable<string> {
    return cy
      .get(this.modalTitle)
      .invoke('text')
      .then((title) => {
        return title as string;
      });
  }

  getCourseInstructorFromModal(): Cypress.Chainable<string> {
    return cy
      .get(this.modalInstructor)
      .invoke('text')
      .then((instructor) => {
        return instructor as string;
      });
  }

  getCourseDescriptionFromModal(): Cypress.Chainable<string> {
    return cy
      .get(this.modalDescription)
      .invoke('text')
      .then((description) => {
        return description as string;
      });
  }
}
