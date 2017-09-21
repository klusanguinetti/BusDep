'use strict';
app.service('eventoPublicidadService', ['$http', '$q', function ($http, $q) {
    var serviceBase = '/api/EventoPublicidad/';
    this.getEventoPublicidadAll = function (item) {
        var deferred = $q.defer();
        $http.post(serviceBase + 'GetEventoPublicidadAll', item).then(function (response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    this.deleteEventoPublicidad = function (publicidad) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'DeleteEventoPublicidad?Id=' + publicidad.Id).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getEventoPublicidadById = function (item) {

        var deferred = $q.defer();
        $http.post(serviceBase + 'GetEventoPublicidadId?Id=' + item).then(function (response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };
    this.newEventoPublicidad = function (item) {
        $http.post(serviceBase + 'NewEventoPublicidad', item).then(function (response) {
            return response;
        });
    };

    this.saveEventoPublicidad = function (item) {
        var deferred = $q.defer();
        $http.post(serviceBase + 'SaveEventoPublicidad', item).then(function (response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    this.getEventoPublicidadActivaAll = function (item) {
        var deferred = $q.defer();
        $http.post(serviceBase + 'GetEventoPublicidadActivaAll', item).then(function (response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

    this.getEventoPublicidadActivaCount = function (item) {
        var deferred = $q.defer();
        $http.post(serviceBase + 'EventoPublicidadActivaCount', item).then(function (response) {
            deferred.resolve(response);
        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;
    };

}]);