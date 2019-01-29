easyDevApp.controller('CandidatosCtrl', function($scope, Candidato) {

//Vars
$scope.loading = {pesquisando: true, excluindo:false}
$scope.candidatos = []
$scope.query = {email:'', nome:''}

//Functions
$scope.pesquisar = pesquisar
$scope.openModal = openModal
$scope.excluir = excluir

function pesquisar() {
	$scope.loading.pesquisando = true;

	Candidato.getAll($scope.query)
	.then(function (response) {
			$scope.candidatos = response.data;
	})
	.catch(function (response) {
	  M.toast({html: 'Erro:' + response.status})
	})
	.finally(function () {$scope.loading.pesquisando = false;});
}

function excluir()
{
	$scope.loading.excluindo = true;
	Candidato.excluir($scope.objSelecionado.id).then(function (response)
	{	
        M.toast({html: 'Registro excluído com sucesso!'})
		pesquisar()
		openModal(false)
	}).catch(function(response) {
		 M.toast({html: 'Erro:' + response.status})
	}).finally(function() {$scope.loading.excluindo = false;});
}


function openModal(_obj) {

	var instance = M.Modal.getInstance($('.modal').modal());

	

	if(_obj)
	{
	    instance.open();
	    $scope.objSelecionado = _obj;
	}
	else {
		instance.destroy();
	    $('body').css('overflow','');
	}
}


function onModalClose() {
	alert('s')
}


function init() {
	pesquisar();
}

setTimeout(() => init(), 10);

})