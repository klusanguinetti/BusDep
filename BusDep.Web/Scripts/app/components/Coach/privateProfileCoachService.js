'use strict';
app.service('privateProfileCoachService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/api/Coach/';
    this.getUserDetails = function () {

        var deferred = $q.defer();

        $http.post(serviceBase + 'GetDatosPersona').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };
    this.saveUserDetails = function (userDetails) {

        return $http.post(serviceBase + 'Save', userDetails).then(function (response) {
            return response;
        });

    };
}]);