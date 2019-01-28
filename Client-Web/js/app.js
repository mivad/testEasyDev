var easyDevApp = angular.module('EasyDevApp', ['ngRoute', 'ngAnimate', 'rzModule'])

.run(function() {

});

easyDevApp.config([
  '$routeProvider',
  function($routeProvider) {
    $routeProvider
      .when("/", {
        templateUrl: 'app/views/conhecimentos/list/list.tpl.html',
        controller: ''
      })
      .when("/Conhecimentos", {
        name:'conhecimentos',
        templateUrl: 'app/views/conhecimentos/list/list.tpl.html',
        controller: 'ConhecimentosCtrl'
      })
      .when("/Conhecimentos/Conhecimento", {
        name:'conhecimentos',
        templateUrl: 'app/views/conhecimentos/form/form.tpl.html',
        controller: 'ConhecimentoCtrl'
      })
       .when("/Conhecimentos/Conhecimento/:id", {
        name:'conhecimentos',
        templateUrl: 'app/views/conhecimentos/form/form.tpl.html',
        controller: 'ConhecimentoCtrl'
      })
      .when("/Candidatos", {
        name:'candidatos',
        templateUrl: 'app/views/candidatos/list/list.tpl.html',
        controller: 'CandidatosCtrl'
      })
      .when("/Candidatos/Candidato", {
        name:'candidatos',
        templateUrl: 'app/views/candidatos/form/form.tpl.html',
        controller: 'CandidatoCtrl'
      })
       .when("/Candidatos/Candidato/:id", {
        name:'candidatos',
        templateUrl: 'app/views/candidatos/form/form.tpl.html',
        controller: 'CandidatoCtrl'
      })
      .otherwise({
        name:'404',
        redirectTo: '/404'
      });
  }
]);
