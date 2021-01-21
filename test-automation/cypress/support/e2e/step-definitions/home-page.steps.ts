import { Then, When } from 'cypress-cucumber-preprocessor/steps';
import { Home } from '../page-objects/home-page.po';

const home = new Home();

When('a página inicial é carregada', () => {

});

Then('uma breve descrição do sistema é exibida', () => {
  home.getHomeDescription().should('have.string', 'OlympusUi');
});

Then('o campo de busca é disponibilizado', () => {
  home.getSearch().should('be.visible');
});

When('digito um termo na Busca', () => {

});

When('clico em pesquisar', () => {

});

Then('a seguinte lista de treinamentos, que possuem o termo buscado, é exibida', (table) => {

});
