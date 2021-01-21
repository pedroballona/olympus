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
    Quando digito um termo na Busca
    E clico em pesquisar
    Entao a seguinte lista de treinamentos, que possuem o termo buscado, é exibida
      | title                                | author      |
      | The Devil in the White City          | Erik Larson |
      | The Lion, the Witch and the Wardrobe | C.S. Lewis  |
      | In the Garden of Beasts              | Erik Larson |