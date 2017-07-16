'use strict';
app.service('privateProfileService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Profile/';

    this.saveUserDetails = function (userDetails) {

        return $http.post(serviceBase + 'Save', userDetails).then(function (response) {
            return response;
        });

    };

    this.passwordUpdate = function (loginDetails) {

        var data = "Id=" + loginDetails.Id + "&Mail=" + loginDetails.Mail + "&OldPassword=" + loginDetails.OldPassword + "&NewPassword=" + loginDetails.Password;

        var deferred = $q.defer();

        $http.post(serviceBase + 'PasswordSave', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

    this.getUserDetails = function (datosPersonaId) {

        var data = "datosPersonaId=" + datosPersonaId;

        var deferred = $q.defer();

        $http.post(serviceBase + 'GetDatosPersona', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {

            deferred.resolve(response);

        }).catch(function(err) {
            deferred.reject(err);
        });

        return deferred.promise;

    };


}]);