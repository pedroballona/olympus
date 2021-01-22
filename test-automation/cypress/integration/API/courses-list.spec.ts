import { CoursesController } from '../../support/API/controllers/courses-controller';
import * as interfaces from '../../support/API/interfaces/courses';

const coursesController = new CoursesController();

describe('(API) Listagem dos cursos', () => {
  it('GetAll - Retorna todos os cursos sem filtro', () => {
    const expectedList = [
      {
        title: '(I/O) com R: Formatos diferentes de entrada e saída',
      },
      {
        title: '.Net e MongoDB parte 1: Primeiros passos para usar esse famoso banco NoSQL',
      },
      {
        title: '.Net e MongoDB parte 2: Integre uma webapp com o banco NoSQL',
      },
      {
        title: 'A Empresa Ágil: Introduzindo o Business Agility nas organizações',
      },
      {
        title: 'ABAP parte 1: Introdução à linguagem criando relatórios',
      },
    ];
    coursesController.getAllCourses().then((list) => {
      list.items.forEach((item, idx) => {
        expect(item.title).to.equal(expectedList[idx].title);
      });
    });
  });

  it('GetAll - Retorna os cursos filtrando por um termo', () => {
    const expectedList = [
      {
        title: 'Android Brasil: Validações e formatações',
      },
      {
        title: 'Android Fragments: Reutilizando componentes visuais',
      },
      {
        title: 'Android Room parte 1: Introdução a persistência de dados com ORM',
      },
    ];

    coursesController.getAllCourses('android', 3, 'title').then((list) => {
      list.items.forEach((course, idx) => {
        expect(course.title).to.deep.equal(expectedList[idx].title);
      });
    });
  });

  it('GetAll - Requisição filtro com um termo inválido', () => {
    coursesController.getAllCourses('*&&)').then((list) => {
      expect(list.items.length).to.equal(0);
    });
  });

  it('GetOne - Retorna os detalhes de um curso', () => {
    coursesController
      .getAllCourses('abap', 3, 'id')
      .then((list) => {
        return list.items[0];
      })
      .then((abapCourse) => {
        coursesController.getOneCourseDetail(abapCourse.id as string).then((detailedCourse) => {
          expect(detailedCourse).to.deep.equal({
            title: 'ABAP parte 2: Construindo relatórios ALV no SAP',
            description: 'ABAP parte 2: Construindo relatórios ALV no SAP',
            instructors: ['Erick Carvalho'],
            score: 8.9,
            firstClass:
              'https://video.alura.com.br/alura/355443041-sd.mp4?cdn_hash=5032eba5d621cb4578a3aae81c73471f',
          });
        });
      });
  });

  it('Post - Cria um curso', () => {
    let pythonTraining: interfaces.NewCourse = {
      title: 'ZZ Automação de testes com cypress',
      score: 70,
      instructors: [
        {
          name: 'Roberto simão',
          expertise: ['Especialista em Cypress', 'Especialista em Automação'],
        },
      ],
      linkExternalCourse: 'https://www.youtube.com/watch?v=lwhGYHqf-2s',
      externalId: '189',
      firstClass: 'https://www.youtube.com/watch?v=lwhGYHqf-2s',
    };

    coursesController.putCourses(pythonTraining);
  });
});
