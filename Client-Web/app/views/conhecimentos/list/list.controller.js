easyDevApp.controller('ConhecimentosCtrl', function($scope, Conhecimento) {

//Vars
$scope.loading = {pesquisando: true, excluindo:false}
$scope.conhecimentos = []

//Functions
$scope.pesquisar = pesquisar
$scope.openModal = openModal
$scope.excluir = excluir

function pesquisar() {
	$scope.loading.pesquisando = true;
	$scope.conhecimentos = []

	Conhecimento.getAll()
	.then(function (response) {
		response.data.forEach(function (x) {
			$scope.conhecimentos.push(x);
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
	Conhecimento.excluir($scope.objSelecionado.id).then(function (response)
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