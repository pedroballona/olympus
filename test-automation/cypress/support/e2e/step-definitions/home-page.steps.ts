import { Then, When } from 'cypress-cucumber-preprocessor/steps';
import { Courses } from '../page-objects/courses-page.po';
import { Home } from '../page-objects/home-page.po';

function replace(termo: string) {
  termo = termo.replace('<', '');
  termo = termo.replace('>', '');
  return termo;
}

const home = new Home();
const courses = new Courses();

When('a página inicial é carregada', () => {});

Then('uma breve descrição do sistema é exibida', () => {
  home.getHomeDescription().should('have.string', 'OlympusUi');
});

Then('o campo de busca é disponibilizado', () => {
  home.getSearch().should('be.visible');
});

When('digito o termo {string} termo na Busca', (termo) => {
  home.getSearch().type(replace(termo));
});

When('clico em pesquisar', () => {
  home.getSearch().type('{enter}');
});

Then('o treinamento {string} é exibido', (title) => {
  courses.getAllCourses().then((list) => {
    expect(list.length).to.equal(1);
  });

  courses.getCourseTitle(0).then((courseTitle) => {
    expect(courseTitle).to.equal(replace(title));
  });
});
