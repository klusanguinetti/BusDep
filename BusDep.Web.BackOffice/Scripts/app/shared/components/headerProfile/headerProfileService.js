﻿'use strict';
app.service('headerProfileService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/api/Files/';

    this.removePhoto = function () {

        var deferred = $q.defer();

        return $http.delete(serviceBase + 'Delete').then(function (response) {
   
            deferred.resolve(response.data);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

    this.removePhotoCuerpoCompleto = function () {

        var deferred = $q.defer();

        return $http.delete(serviceBase + 'DeleteCuerpoCompleto').then(function (response) {

            deferred.resolve(response.data);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

    this.removeVideo = function () {

        var deferred = $q.defer();

        return $http.delete(serviceBase + 'RemoveVideo').then(function (response) {

            deferred.resolve(response.data);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

}]);