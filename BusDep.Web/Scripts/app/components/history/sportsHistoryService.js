﻿'use strict';
app.service('sportsHistoryService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/History/';

    this.getJugador = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetJugador').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

    this.getAntecedentes = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetAntecedentes').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getNewAntecedente = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetNewAntecedente').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });
        return deferred.promise;
    };
    this.getClubes = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetClubes').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });
        return deferred.promise;
    };
    
    this.saveAntecedente = function (item) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'SaveAntecedente', item).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

}]);