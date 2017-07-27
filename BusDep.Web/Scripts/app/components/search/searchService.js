﻿'use strict';
app.service('searchService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Search/';

    this.searchPlayer = function (searchValue) {
        console.log(searchValue);
        var data = $http({
            url: serviceBase + 'SearchPost',
            method: 'get',
            params: {
                searchValues: searchValue.Nombre,
                pagina: searchValue.pagina,
                cantidad: searchValue.cantidad
            }
        });

        return $q.when(data);
    };

    this.searchPlayerCount = function (searchValue) {
        console.log(searchValue);
        var data = $http({
            url: serviceBase + 'SearchPostCount',
            method: 'get',
            params: { searchValues: searchValue.Nombre }
        });

        return $q.when(data);
    };


    this.searchFiltersPlayer = function (searchValue) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'SearchFiltersPostNew', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getBuscarJugadorViewModel = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetBuscarJugadorViewModel').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

}]);