'use strict';
app.service('passwordChangeService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/api/Account/';


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