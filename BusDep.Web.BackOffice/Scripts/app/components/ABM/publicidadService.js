'use strict';
app.service('publicidadService', ['$http', '$q', function ($http, $q) {
    var serviceBase = '/api/ABM/';
    this.getPublicidadAll = function (item) {
        var deferred = $q.defer();
        $http.post(serviceBase + 'GetPublicidadAll', item).then(function (response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    this.deletePublicidad = function (id) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'DeletePublicidad?Id=' + id).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getPublicidadById = function (item) {

        var deferred = $q.defer();
        $http.post(serviceBase + 'GetPublicidadId?Id=' +item).then(function(response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };
    this.newPublicidad = function (item) {
        $http.post(serviceBase + 'NewPublicidad', item).then(function (response) {
            return response;
        });
    };

    this.savePublicidad = function (item) {
        var deferred = $q.defer();
        $http.post(serviceBase + 'SavePublicidad', item).then(function (response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };
}]);