easyDevApp.controller("MainCtrl", function($scope,$route, $translate) {
	
  $scope.changeLanguage = function (key) {
    $translate.use(key);
  };

})