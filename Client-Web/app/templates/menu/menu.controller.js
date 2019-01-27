easyDevApp.controller('MenuCtrl', function($rootScope, $scope, $route) {

	//Vars
	$scope.active = {carregando: false}
	$scope.current = {name:''}

	//functions
	$scope.openNavMobile = openNavMobile

	function init() {
		$scope.current.name = $route.current.name;
	}

	function openNavMobile() {
		var instance = M.Modal.getInstance($('#nav-mobile').modal());
  		if(instance)
  			instance.open();
	}

	setTimeout(() => init(), 10);

  	$scope.$on('$routeChangeStart', function(next, current) {
		var instance = M.Modal.getInstance($('#nav-mobile').modal());
  		if(instance)
  		{
  			instance.close();
  			$('body').css('overflow','');
  		}
		$scope.current.name = current.$$route.name;
	})

});