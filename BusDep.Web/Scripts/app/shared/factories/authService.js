'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

    var serviceBase = '/api/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: ""
    };

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'Account/Register', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {

        var data = "grant_type=password&mail=" + loginData.mail + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post(serviceBase + 'Account/Login', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {

            localStorageService.set('authorizationData', { token: response.data.access_token, userName: response.data.Mail });

            _authentication.isAuth = true;
            _authentication.userName = response.data.Mail;

            deferred.resolve(response);

        }), function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
            _logOut();
            deferred.reject(err);
        }

        return deferred.promise;

    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
        }

    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;

}]);