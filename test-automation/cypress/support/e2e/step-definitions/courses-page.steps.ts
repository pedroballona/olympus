import { Then, When } from 'cypress-cucumber-preprocessor/steps';
import { Courses } from '../page-objects/courses-page.po';
import { Menu } from '../page-objects/menu.po';

const menu = new Menu();
const courses = new Courses();

function replace(termo: string) {
  termo = termo.replace('<', '');
  termo = termo.replace('>', '');
  return termo;
}

When('eu acesso a página de cursos', () => {
  menu.clickOnMenu('Cursos');
});

Then('os {string} primeiros cursos são exibidos', (qtyCourses) => {
  courses.getAllCourses().then((list) => {
    console.log(+replace(qtyCourses));
    expect(list.length).to.equal(+replace(qtyCourses));
  });
});

Then('o botão para {string} é exibido', (buttonLabel) => {
  courses.getLabelFromButton().then((label) => {
    expect(label).to.equal(replace(buttonLabel));
  });
});

When('clico em carregar mais', () => {
  courses.clickOnLoadMoreButton();
});

Then('mais 20 cursos são exibidos, totalizando {string}', (qtyCourses) => {
  courses.getAllCourses().then((list) => {
    expect(list.length).to.equal(+replace(qtyCourses));
  });
});

When('clico em {string} do {string} curso', (buttonLabel, courseIndex) => {
  const course = +replace(courseIndex);
  const idx = course - 1;
  courses.clickOnWidgetAction(replace(buttonLabel), idx);
});

Then('um modal é aberto com as informações do curso {string}', (courseName) => {
  const course = {
    title: replace(courseName),
    instructor: 'Rafael Balbi',
    description:
      'Adobe Illustrator: Trabalhando com edição tipográfica',
  };
  courses.getCourseTitleFromModal().then((title) => {
    expect(title.trim()).to.equal(course.title);
  });
  courses.getCourseInstructorFromModal().then((instructor) => {
    expect(instructor.trim()).to.equal(course.instructor);
  });
  courses.getCourseDescriptionFromModal().then((description) => {
    expect(description.trim()).to.equal(course.description);
  });
});
