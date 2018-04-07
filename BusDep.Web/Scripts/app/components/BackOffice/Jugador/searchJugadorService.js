'use strict';
app.service('searchJugadorService', ['$http', '$q', function ($http, $q) {
    var serviceBase = '/api/SearchJugador/';
    this.getJugadoresAll = function () {
        var deferred = $q.defer();
        $http.post(serviceBase + 'GetJugadoresAll').then(function (response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };


}]);