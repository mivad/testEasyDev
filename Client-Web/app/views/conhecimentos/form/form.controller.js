easyDevApp.controller('ConhecimentoCtrl', function($scope, $routeParams, $location, Conhecimento) {

//Vars
$scope.loading = {carregando: false, salvando:false}
$scope.objSelecionado = {id:0}

//Functions
$scope.salvar = salvar

function carregarForm() {
	$scope.loading.carregando = true;

	Conhecimento.getById($routeParams.id)
	.then(function (response) {
		$scope.objSelecionado = response.data;
	})
	.catch(function (response) {
	  M.toast({html: 'Erro:' + response.status})
	})
	.finally(function () {$scope.loading.carregando = false;});
}

function salvar()
{
	$scope.loading.salvando = true;
	Conhecimento.salvar($scope.objSelecionado).then(function (response)
	{	
		 $scope.objSelecionado.id = response.data.id;
		 M.toast({html: 'Registro salvo com sucesso!'})
		 
		 if(!$routeParams.id)
            	window.location.href='#!/Conhecimentos/Conhecimento/'+$scope.objSelecionado.id;

	}).catch(function(response) {
		 M.toast({html: 'Erro:' + response.status})
	}).finally(function() {$scope.loading.salvando = false;});
}



function init() {
	if($routeParams.id)
		carregarForm();
}

setTimeout(() => init(), 10);

})