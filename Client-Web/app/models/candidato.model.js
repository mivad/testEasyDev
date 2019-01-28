easyDevApp.factory("Candidato", function ($http, configuracoes) {

	var _getAll = function (parametros, opts) {

		if(!opts)
			opts = {}

		return $http({
		    method: 'GET',
		    url: configuracoes.getApi() + 'Candidatos',
		    params: parametros
		})
	};


	var _getById = function (id) {
		return $http.get(configuracoes.getApi() + "Candidatos/"+id);
	};


	var _salvar = function (_obj) {
		var url = configuracoes.getApi() + 'Candidatos';

		return $http({
		    method: _obj.id > 0 ? 'PUT' : 'POST',
		    url: _obj.id > 0 ? url + '/' + _obj.id : url,
	     	data: angular.toJson(_obj),
		    headers: {'Content-Type': 'application/json'}
		})
	};


	var _excluir = function (_id) {
		var url = configuracoes.getApi() + 'Candidatos/' + _id;

		return $http({
		    method: 'DELETE',
		    url: url,
		    headers: {'Content-Type': 'application/json'}
		})
	};

	return {
		getAll 					: 	_getAll,
		getById 				: 	_getById,
		salvar  				: 	_salvar,
		excluir					:   _excluir
	};

});