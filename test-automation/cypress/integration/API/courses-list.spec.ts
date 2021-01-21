import { CoursesController } from '../../support/API/controllers/courses-controller';
import * as interfaces from '../../support/API/interfaces/courses';

const coursesController = new CoursesController();

describe('Listagem dos cursos', () => {
  it('GetAll - Retorna todos os cursos sem filtro', () => {
    coursesController.getAllCourses().then((list) => {
      expect(list.items).to.deep.equal([
        {
          id: 'io-em-r',
          title: '(I/O) com R: Formatos diferentes de entrada e saída',
        },
        {
          id: 'dotnet-mongodb',
          title: '.Net e MongoDB parte 1: Primeiros passos para usar esse famoso banco NoSQL',
        },
        {
          id: 'dotnet-mongodb-parte2',
          title: '.Net e MongoDB parte 2: Integre uma webapp com o banco NoSQL',
        },
        {
          id: 'empresa-agil',
          title: 'A Empresa Ágil: Introduzindo o Business Agility nas organizações',
        },
        {
          id: 'abap',
          title: 'ABAP parte 1: Introdução à linguagem criando relatórios',
        },
      ]);
    });
  });

  xit('GetAll - Retorna todos os cursos filtrando por um termo', () => {
    coursesController.getAllCourses('').then((list) => {
      expect(list.items).to.deep.equal([
        {
          id: 'io-em-r',
          title: '(I/O) com R: Formatos diferentes de entrada e saída',
        },
        {
          id: 'dotnet-mongodb',
          title: '.Net e MongoDB parte 1: Primeiros passos para usar esse famoso banco NoSQL',
        },
        {
          id: 'dotnet-mongodb-parte2',
          title: '.Net e MongoDB parte 2: Integre uma webapp com o banco NoSQL',
        },
        {
          id: 'empresa-agil',
          title: 'A Empresa Ágil: Introduzindo o Business Agility nas organizações',
        },
        {
          id: 'abap',
          title: 'ABAP parte 1: Introdução à linguagem criando relatórios',
        },
      ]);
    });
  });

  xit('GetAll - Retorna todos os cursos filtrando por um termo inválido', () => {
    coursesController.getAllCourses('*&&)').then((list) => {
      expect(list.items.length).to.equal(0);
    });
  });

  it('Put - Cria um curso', () => {
    let pythonTraining: interfaces.SimpleCourse;
    coursesController
      .getAllCourses('PYthon')
      .then((course) => {
        pythonTraining = course.items[0];
      })
      .then(() => {
        coursesController.putCourses(pythonTraining);
      });
  });
});
