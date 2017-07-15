'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {

    var serviceBase = '/Account/';
    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        userName: "",
        datosPersonaId: ""
    };

    var _saveRegistration = function (registration) {

        _logOut();

        return $http.post(serviceBase + 'RegisterPost', registration).then(function (response) {
            return response;
        });

    };

    var _login = function (loginData) {

        var data = "grant_type=password&mail=" + loginData.mail + "&password=" + window.btoa(loginData.password);

        var deferred = $q.defer();

        $http.post(serviceBase + 'LoginPost', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {

            localStorageService.set('authorizationData', { token: response.data.access_token, userName: response.data.Mail, id: response.data.Id });

            _authentication.isAuth = true;
            _authentication.userName = response.data.Mail;
            _authentication.datosPersonaId = response.data.Id;

            deferred.resolve(response);

        }).catch(function(err) {
            _logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    var _logOut = function () {

        localStorageService.remove('authorizationData');

        _authentication.isAuth = false;
        _authentication.userName = "";
        _authentication.datosPersonaId = "";

    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');

        if (authData) {
            _authentication.isAuth = true;
            _authentication.userName = authData.userName;
            _authentication.datosPersonaId = authData.id;
        }

    }

    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;

    return authServiceFactory;

}]);