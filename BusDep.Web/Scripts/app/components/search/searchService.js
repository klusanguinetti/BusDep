'use strict';
app.service('searchService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/api/Search/';

    this.searchPlayer = function (searchValue) {
        console.log(searchValue);
        //var data = $http({
        //    url: serviceBase + 'SearchPost',
        //    method: 'get',
        //    params: {
        //        searchValues: searchValue.Nombre,
        //        pagina: searchValue.pagina,
        //        cantidad: searchValue.cantidad
        //    }
        //});

        //return $q.when(data);
        var deferred = $q.defer();

        $http.post(serviceBase + 'SearchPost', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    this.searchPlayerCount = function (searchValue) {
        console.log(searchValue);
        var deferred = $q.defer();
        $http.post(serviceBase + 'SearchPostCount', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
       
    };
    this.searchFiltersPlayerCount = function (searchValue) {
        var deferred = $q.defer();

        $http.post(serviceBase + 'SearchFiltersPostNewCount', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
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
    this.saveRecomendarItem = function (recomenda) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'SaveRecomendar', recomenda).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };
}]);