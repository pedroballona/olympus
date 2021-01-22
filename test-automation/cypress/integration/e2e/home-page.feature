#language: pt
Funcionalidade: Home Page
    Eu, como usuário, quero visualizar a página inicial com uma breve descrição do sistema e um fácil mecanismo de busca

  Contexto:
    Dado que eu estou acessando o sistema Olympos

  Cenario: Exibição do 'about us' e busca na home page
    Quando a página inicial é carregada
    Entao uma breve descrição do sistema é exibida
    E o campo de busca é disponibilizado

  Cenario: Busca simples por treinamento
    Quando digito o termo "<ABAP parte 3:>" termo na Busca
    E clico em pesquisar
    Entao o treinamento "ABAP parte 3: Persistindo dados" é exibido
