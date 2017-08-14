'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', '$rootScope', '$location',
    function ($http, $q, localStorageService, $rootScope, $location) {

        /*Declaración de variables*/

        var serviceBase = '/Account/';

        var authServiceFactory = {};

        /*Declaración de funciones*/

        var _saveRegistration = function (registration) {

            var deferred = $q.defer();

            _logOut();

            $http.post(serviceBase + 'RegisterPost', registration).then(function (response) {

                deferred.resolve(response);

            }).catch(function (err) {
                deferred.reject(err);
            });

            return deferred.promise;

        };

        var _login = function (loginData) {

            var logindataPost = {
                mail: loginData.mail,
                password: window.btoa(loginData.password)
            };

            var deferred = $q.defer();

            $http.post(serviceBase + 'LoginPost', logindataPost).then(function (response) {

                $rootScope.user.authenticated = true;
                $rootScope.user.UserName = logindataPost.mail;

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

                $rootScope.user.authenticated = false;
                $rootScope.user.UserName = '';

                deferred.resolve(response);

            }).catch(function (err) {

                deferred.reject(err);

            });

            return deferred.promise;

        };

        var _passwordRecovery = function (passwordRecoveryData) {

            var deferred = $q.defer();

            $http.post(serviceBase + 'PasswordRecoveryPost', passwordRecoveryData).then(function (response) {

                $rootScope.user.authenticated = false;
                $rootScope.user.UserName = '';

                deferred.resolve(response);

            }).catch(function (err) {

                deferred.reject(err);

            });

            return deferred.promise;

        };

        var _passwordRecoveryUpdate = function (passwordRecoveryData) {

            var deferred = $q.defer();

            $http.post(serviceBase + 'UpdatePasswordRecoveryPost', passwordRecoveryData).then(function (response) {

                $rootScope.user.authenticated = false;
                $rootScope.user.UserName = '';

                deferred.resolve(response);

            }).catch(function (err) {

                deferred.reject(err);

            });

            return deferred.promise;

        };

        var _isLogIn = function () {

            var iPermissionPassed = false;
            // we will return a promise .
            var deferred = $q.defer();

            if (!$rootScope.user.authenticated) {

                //If user does not have required access, 
                //we will route the user to unauthorized access page
                $location.path('/Account/Login');
                //As there could be some delay when location change event happens, 
                //we will keep a watch on $locationChangeSuccess event
                // and would resolve promise when this event occurs.
                $rootScope.$on('$locationChangeSuccess', function (next, current) {
                    deferred.resolve();
                });

            } else {
                deferred.resolve();
            }

        };

        /*Declaración de returns*/

        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.isLogIn = _isLogIn;
        authServiceFactory.passwordRecovery = _passwordRecovery;
        authServiceFactory.passwordRecoveryUpdate = _passwordRecoveryUpdate;

        return authServiceFactory;

    }]);