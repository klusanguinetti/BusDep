'use strict';
app.service('privateProfileService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Profile/';

    this.saveUserDetails = function (userDetails) {

        return $http.post(serviceBase + 'Save', userDetails).then(function (response) {
            return response;
        });

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


}]);