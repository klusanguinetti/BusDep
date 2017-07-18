'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', '$rootScope', function ($http, $q, localStorageService, $rootScope) {

    /*Declaración de variables*/

    var serviceBase = '/Account/';

    var authServiceFactory = {};

    /*Declaración de funciones*/

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'RegisterPost', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {

        loginData.password = window.btoa(loginData.password)

        var deferred = $q.defer();

        $http.post(serviceBase + 'LoginPost', loginData).then(function (response) {
 
            $rootScope.user.authenticated = true;
            $rootScope.user.UserName = loginData.mail;

            deferred.resolve(response);

        }).catch(function (err) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {

        var deferred = $q.defer();

        $http.post(serviceBase + 'SignOut').then(function (response) {

            $rootScope.user.authenticated = null;
            $rootScope.user.UserName = null;

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

    /*Declaración de returns*/

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;

    return authServiceFactory;

}]);