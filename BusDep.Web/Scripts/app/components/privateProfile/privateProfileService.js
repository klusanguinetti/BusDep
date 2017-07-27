'use strict';
app.service('privateProfileService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Profile/';

    this.saveUserDetails = function (userDetails) {

        return $http.post(serviceBase + 'Save', userDetails).then(function (response) {
            return response;
        });

    };
    
    this.jugadorUpdate = function (jugador) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'SaveJugador', jugador).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

    this.passwordUpdate = function (loginDetails) {

        var deferred = $q.defer();

        $http.post(serviceBase + 'PasswordSave', loginDetails).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

    this.getUserDetails = function () {

        var deferred = $q.defer();

        $http.post(serviceBase + 'GetDatosPersona').then(function (response) {

            deferred.resolve(response);

        }).catch(function(err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

    this.getJugador = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetJugador').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

    this.getFichajes = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetFichajes').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getPerfiles = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetPerfiles').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getPuestos = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetPuestos').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getPies = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetPies').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.getPuestosBasicos = function () {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetPuestosBasicos').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };

}]);