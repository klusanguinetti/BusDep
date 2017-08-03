'use strict';
app.service('selfAppraisalService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Evaluation/';

    this.getJugador = function () {

        var deferred = $q.defer();

        $http.post(serviceBase + 'GetJugador').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

    this.getAutoEvaluacion = function () {

        var deferred = $q.defer();

        $http.post(serviceBase + 'GetAutoEvaluacion').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    
    
    this.save = function (item) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'SaveEvaluacion', item).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

}]);