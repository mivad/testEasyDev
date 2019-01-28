easyDevApp.controller('CandidatoCtrl', function($scope, $routeParams, $location, $filter, Candidato, Conhecimento) {

//Vars
$scope.loading = {carregando: false, salvando:false}
$scope.objSelecionado = {id:0, conhecimentos:[]}
$scope.conhecimentos = []

//Functions
$scope.salvar = salvar

function carregarForm() {
	$scope.loading.carregando = true;

	Candidato.getById($routeParams.id)
	.then(function (response) {
		$scope.objSelecionado = response.data;
	})
	.catch(function (response) {
	  M.toast({html: 'Erro:' + response.status})
	})
	.finally(function () {$scope.loading.carregando = false; setConhecimentos();});
}

function salvar()
{
	$scope.loading.salvando = true;
	Candidato.salvar($scope.objSelecionado).then(function (response)
	{	
		 $scope.objSelecionado.id = response.data.id;
		 M.toast({html: 'Registro salvo com sucesso!'})
		 
		 if(!$routeParams.id)
            	window.location.href='#!/Candidatos/Candidato/'+$scope.objSelecionado.id;

	}).catch(function(response) {
		 M.toast({html: 'Erro:' + response.status})
	}).finally(function() {$scope.loading.salvando = false;});
}


function getConhecimentos()
{
	Conhecimento.getAll()
	.then(function (response) {
		response.data.forEach(function (x) {
			$scope.conhecimentos.push(x);
		})
	})
	.catch(function (response) {
	  M.toast({html: 'Erro:' + response.status})
	})
	.finally(function () {$scope.loading.pesquisando = false; setConhecimentos();});
}

function setConhecimentos() {

	$scope.conhecimentos.forEach(function(_conhecimento){

		var conhecimentoEncontrado = $filter('filter')($scope.objSelecionado.conhecimentos, {conhecimentoId : _conhecimento.id})[0]
		if(!conhecimentoEncontrado)
		{
			var obj = {
				candidatoId: $scope.objSelecionado.id,
				conhecimentoId: _conhecimento.id,
				conhecimento: _conhecimento,
				valor:0
			}

			$scope.objSelecionado.conhecimentos.push(obj)
		}
	})
}

function init() {
	getConhecimentos();

	if($routeParams.id)
		carregarForm();
}




setTimeout(() => init(), 10);

})