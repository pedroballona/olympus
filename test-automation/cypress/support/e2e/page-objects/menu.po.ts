/// <reference types="Cypress" />

type menuName = 'Início' | 'Cursos';

export class Menu {

  private menu = '.menu a';

  clickOnMenu(menuName: menuName): void {
    cy.get(this.menu).contains(menuName).click();
  }
}