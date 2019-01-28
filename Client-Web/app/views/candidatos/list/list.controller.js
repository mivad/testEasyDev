easyDevApp.controller('CandidatosCtrl', function($scope, Candidato) {

//Vars
$scope.loading = {pesquisando: true, excluindo:false}
$scope.candidatos = []

//Functions
$scope.pesquisar = pesquisar
$scope.openModal = openModal
$scope.excluir = excluir

function pesquisar() {
	$scope.loading.pesquisando = true;
	$scope.candidatos = []

	Candidato.getAll()
	.then(function (response) {
		response.data.forEach(function (x) {
			$scope.candidatos.push(x);
		})
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