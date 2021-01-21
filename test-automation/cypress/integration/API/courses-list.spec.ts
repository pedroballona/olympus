import { CoursesController } from '../../support/API/controllers/courses-controller';

const coursesController = new CoursesController();

describe('Listagem dos cursos', () => {
  it('GetAll - Retorna todos os cursos sem filtro', () => {
    expect(coursesController.getAllCourses()).to.equal([
      {
        id: '89328928032',
        name: 'Typescript 1',
        author: 'Roberto',
        hasSigned: false,
        progress: 0,
      },
      {
        id: '22423455346',
        name: 'Typescript 2',
        author: 'Roberto',
        hasSigned: false,
        progress: 0,
      },
      {
        id: '89328928032',
        name: 'Angular',
        author: 'Mariana',
        hasSigned: true,
        progress: 10,
      },
    ]);
  });

  it('GetAll - Retorna todos os cursos filtrando por um termo', () => {
    expect(coursesController.getAllCourses('Mariana')).to.equal([
      {
        id: '89328928032',
        name: 'Angular',
        author: 'Mariana',
        hasSigned: true,
        progress: 10,
      },
    ]);
  });
});
