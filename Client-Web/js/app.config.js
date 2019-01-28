easyDevApp.factory("configuracoes", function() {
  var urlAPI = 'http://localhost:54314/api/';
  //var urlAPI = 'http://easydevtest.gearhostpreview.com/api/'

  var _getApi = function() {
    return urlAPI;
  };

  return {
    getApi: _getApi
  };

});
