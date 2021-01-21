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

  it('GetAll - Retorna os cursos filtrando por um termo', () => {
    coursesController.getAllCourses('android', 3, 'id').then((list) => {
      expect(list.items).to.deep.equal([
        {
          id: 'android-api-web',
          title: 'Android: Acessando uma API web',
        },
        {
          id: 'android-avancando-listeners-menu-ui',
          title: 'Android parte 2: Avançando com listeners, menu e UI',
        },
        {
          id: 'android-boas-praticas-e-cenarios-testes',
          title: 'Android parte 2: Boas práticas e novos cenários de testes',
        },
      ]);
    });
  });

  it('GetAll - Requisição filtro com um termo inválido', () => {
    coursesController.getAllCourses('*&&)').then((list) => {
      expect(list.items.length).to.equal(0);
    });
  });

  it('GetOne - Retorna os detalhes de um curso', () => {
    coursesController
      .getAllCourses('android', 3, 'id')
      .then((list) => {
        return list.items[0];
      })
      .then((androidCourse) => {
        coursesController.getOneCourseDetail(androidCourse.id).then((detailedCourse) => {
          expect(detailedCourse).to.deep.equal({
            title: 'Android: Acessando uma API web',
            description:
              'Evite a perda de dados internos do App\r. Aprenda a configurar o Retrofit para realizar ' +
              'requisições HTTP\r. Integre comportamentos de CRUD com a API web\r. Entenda os problemas comuns durante' +
              ' a comunicação com APIs\r. Aprenda a evitar os problemas comuns durantea integração',
            instructorsNames: ['Alex Felipe'],
            score: 9.3,
          });
        });
      });
  });

  it('Post - Cria um curso', () => {
    let pythonTraining: interfaces.CompleteCourse = {
      title: 'Automação de testes com cypress',
      score: 70,
      instructors: [
        {
          name: 'Roberto simão',
          expertise: ['Especialista em Cypress', 'Especialista em Automação'],
        },
      ],
      linkExternalCourse: 'https://www.youtube.com/watch?v=lwhGYHqf-2s',
    };

    coursesController.putCourses(pythonTraining);
  });
});
