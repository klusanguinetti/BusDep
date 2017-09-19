'use strict';
app.service('searchCoachService', ['$http', '$q', function ($http, $q) {

    //var serviceBase = '/api/Search/';
    var serviceBase = '/api/SearchCoach/';

    this.searchCoach = function (searchValue) {
        
        var deferred = $q.defer();

        $http.post(serviceBase + 'SearchPost', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    this.searchCoachCount = function (searchValue) {
        
        var deferred = $q.defer();
        $http.post(serviceBase + 'SearchPostCount', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
       
    };
    this.searchFiltersCoachCount = function (searchValue) {
        var deferred = $q.defer();

        $http.post(serviceBase + 'SearchFiltersPostNewCount', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };
    

    this.searchFiltersCoach = function (searchValue) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'SearchFiltersPostNew', searchValue).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getBuscarEntrenadorViewModel = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetBuscarEntrenadorViewModel').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
}]);