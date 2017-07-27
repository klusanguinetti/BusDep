'use strict';
app.service('searchService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Search/';

    this.searchPlayer = function (searchValue) {
        console.log(searchValue);
        var deferred = $q.defer();

        $http.post(serviceBase + 'SearchPost', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

    this.SearchFiltersPlayer = function (searchValue) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'SearchFiltersPostNew', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getPuestosBasicos = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetBuscarJugadorViewModel').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

}]);