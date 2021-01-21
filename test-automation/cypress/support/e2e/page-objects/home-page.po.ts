export class Home {
  getHomeDescription(): Cypress.Chainable<string> {
    return cy
      .get('title')
      .invoke('text')
      .then((text) => {
        return text;
      });
  }

  getSearch() {
    return cy.get('app-search-bar input');
  }
}
