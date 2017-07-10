'use strict';
app.service('privateProfileService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/api/Profile/';

    this.saveUserDetails = function (userDetails) {

        return $http.post(serviceBase + 'Save', userDetails).then(function (response) {
            return response;
        });

    };

    this.getUserDetails = function (datosPersonaId) {

        var data = "datosPersonaId=" + datosPersonaId;

        var deferred = $q.defer();

        $http.post(serviceBase + 'Get', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {

            deferred.resolve(response);

        }), function errorCallback(response) {

            deferred.reject(err);
        }

        return deferred.promise;

    };


}]);