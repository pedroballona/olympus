#language: pt
Funcionalidade: Listagem de cursos
    Eu, como usuário, quero visualizar os cursos, de forma simples, tendo opção de ver detalhes ou iniciar o cursos

  Contexto:
    Dado que eu estou acessando o sistema Olympos
    Quando eu acesso a página de cursos

  Cenario: Listagem dos cursos
    Então os "<20>" primeiros cursos são exibidos
    E o botão para "<carregar mais>" é exibido

  Cenario: Carregar mais cursos
    E clico em carregar mais
    Então mais 20 cursos são exibidos, totalizando "<40>"

  Cenario: Visualizar detalhes do curso
    E clico em "<Detalhes>" do "<21>" curso
    Entao um modal é aberto com as informações
      |           title             | description | instructorsNames | score |
      | The Devil in the White City | Erik Larson |                  |       |