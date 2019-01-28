easyDevApp.controller('CandidatoCtrl', function($scope, $routeParams, $location, $filter, $translate, Candidato, Conhecimento) {

//Vars
$scope.loading = {carregando: false, salvando:false, conhecimentos:true}
$scope.objSelecionado = {id:0, conhecimentos:[]}
$scope.conhecimentos = []
$scope.linguagens = [{key:'Português', value:'pt-br'},{key:'English', value:'en'}]
$scope.linguagem = {selecionada:{value:'pt-br'}}

//Functions
$scope.salvar = salvar
$scope.onChangeLinguagem = onChangeLinguagem

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
	if(!validarForm())
		return;

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
	$scope.loading.conhecimentos = true;
	Conhecimento.getAll()
	.then(function (response) {
		response.data.forEach(function (x) {
			$scope.conhecimentos.push(x);
		})
	})
	.catch(function (response) {
	  M.toast({html: 'Erro:' + response.status})
	})
	.finally(function () {$scope.loading.conhecimentos = false; setConhecimentos();});
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

function onChangeLinguagem()
{
    $translate.use($scope.linguagem.selecionada.value);
}

function init() {
	getConhecimentos();

	if($routeParams.id)
		carregarForm();
}

function  validarForm() {
	if(!$scope.objSelecionado.nomeCompleto || $scope.objSelecionado.nomeCompleto.length == 0)
	{
	 	M.toast({html: $translate.instant('FORM_NOME')})
		return false;
	}
	else if(!$scope.objSelecionado.email || $scope.objSelecionado.email.length == 0)
	{
	 	M.toast({html: 'Email'})
		return false;
	}
	return true;
}


setTimeout(() => init(), 10);

})