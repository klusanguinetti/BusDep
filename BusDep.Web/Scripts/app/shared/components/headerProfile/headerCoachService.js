'use strict';
app.service('headerCoachService', ['$http', '$q', function ($http, $q) {

    var serviceFiles = '/api/Files/';
    var serviceBase = '/api/Coach/';

    this.removePhoto = function () {

        var deferred = $q.defer();

        return $http.delete(serviceFiles + 'Delete').then(function (response) {
   
            deferred.resolve(response.data);

        }).catch(function (err) {

            deferred.reject(err);

        });
        return deferred.promise;
    };

    this.getPerfilEntrenador = function () {
        return $http.post(serviceBase + 'GetPerfilEntrenador').then(function (response) {
            return response;
        });
    };
   

}]);