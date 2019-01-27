var easyDevApp = angular.module('EasyDevApp', ['ngRoute', 'ngAnimate'])

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
      .otherwise({
        name:'404',
        redirectTo: '/404'
      });
  }
]);
