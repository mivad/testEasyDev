easyDevApp.config(['$translateProvider', function($translateProvider) {


  $translateProvider.translations("en", {
    FORM_LINGUAGEM: 'Language select',
    FORM_NOME: 'Full Name',
    FORM_CIDADE: 'City',
    FORM_ESTADO: 'State',
    FORM_PORTIFOLIO: 'Portfolio',
    FORM_TELEFONE: 'Phone',
    FORM_Q1: 'What is your willingness to work today? ',
    FORM_Q1_ATE4: 'Up to 4 hours per day',
    FORM_Q1_ATE6: '4 to 6 hours per day',
    FORM_Q1_ATE8: '6 to 8 hours per day',
    FORM_Q1_MAIS8: 'Up to 8 hours a day (are you sure?)',
    FORM_Q1_SOFDS: 'Only weekends',
    FORM_Q2: 'Wha\'s the best time to work for you?',
    FORM_Q2_MANHA: 'Morning (from 08:00 to 12:00)',
    FORM_Q2_TARDE: 'Afternoon (from 1:00 p.m. to 6:00 p.m.)',
    FORM_Q2_NOITE: 'Night (7:00 p.m. to 10:00 p.m.)',
    FORM_Q2_MADRUDAGA: 'Dawn (from 10 p.m. onwards)',
    FORM_Q2_COMERCIAL: 'Business (from 08:00 a.m. to 06:00 p.m.)',
    FORM_Q3_SALARIO: 'What is your hourly salary requirements?',
    FORM_Q4_CONHECIMENTOS: 'Rate yourself from 0 to 5 for the knowledge specified below, and that\'s okay if you do not know many things, the important thing is to be honest!',
    FORM_Q5_OUTROS: 'Do you know any other language or framework that was not listed above? Tell us and evaluate yourself from 0 to 5.',
    FORM_Q6_CRUD: 'Enter the link here CRUD (create, update, delete)- read information in the welcome document quoted in the form description.',
    FORM_Q7_TUTORIAS: 'Tutorials - Check out our tutorials and material explaining how the company works.',
    FORM_NAO_CONHECO: 'I don\'t know',
    FORM_CADASTRAR: 'Register',
    FORM_EDITAR: 'To edit',
    FORM_CANDIDATO: 'Candidate'
  });

  $translateProvider.translations('pt-br', {
    FORM_LINGUAGEM: 'Selecionar Idioma',
    FORM_NOME: 'Nome Completo',
    FORM_CIDADE: 'Cidade',
    FORM_ESTADO: 'Estado',
    FORM_PORTIFOLIO: 'Portfólio',
    FORM_TELEFONE: 'Telefone',
    FORM_Q1: 'Qual é sua disponibilidade para trabalhar hoje?',
    FORM_Q1_ATE4: 'Até 4 horas por dia',
    FORM_Q1_ATE6: 'De 4 á 6 horas por dia',
    FORM_Q1_ATE8: 'De 6 á 8 horas por dia',
    FORM_Q1_MAIS8: 'Acima de 8 horas por dia (tem certeza?)',
    FORM_Q1_SOFDS: 'Apenas finais de semana',
    FORM_Q2: 'Pra você qual é o melhor horário para trabalhar?',
    FORM_Q2_MANHA: 'Manhã (de 08:00 ás 12:00)',
    FORM_Q2_TARDE: 'Tarde (de 13:00 ás 18:00)',
    FORM_Q2_NOITE: 'Noite (de 19:00 as 22:00)',
    FORM_Q2_MADRUDAGA: 'Madrugada (de 22:00 em diante)',
    FORM_Q2_COMERCIAL: 'Comercial (de 08:00 as 18:00)',
    FORM_Q3_SALARIO: 'Qual sua pretensão salarial por hora?',
    FORM_Q4_CONHECIMENTOS: 'Avalie-se de 0 a 5 quanto aos conhecimentos especificados abaixo, e tudo bem se não souber de muitas coisas, o importante é que seja sincero!',
    FORM_Q5_OUTROS: 'Conhece mais alguma linguagem ou framework que não foi listado aqui em cima? Conte para nos e se auto avalie ainda de 0 a 5.',
    FORM_Q6_CRUD: 'Insira aqui o link do CRUD (create, update, delete)- ler informações no documento de Boas Vindas citado na descrição do formulário.',
    FORM_Q7_TUTORIAS: 'Confira nossos tutoriais e material explicando como a empresa funciona.',
    FORM_NAO_CONHECO: 'Não conheço',
    FORM_CADASTRAR: 'Cadastrar',
    FORM_EDITAR: 'Editar',
    FORM_CANDIDATO: 'Candidato'
  });

  $translateProvider.preferredLanguage("pt-br");
  $translateProvider.useSanitizeValueStrategy(null);

}])