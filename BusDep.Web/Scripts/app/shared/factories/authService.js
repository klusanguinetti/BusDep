'use strict';
app.factory('authService', ['$http', '$q', 'localStorageService', '$rootScope', '$location',
    function ($http, $q, localStorageService, $rootScope, $location) {

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

            $rootScope.user.authenticated = false;
            $rootScope.user.UserName = '';

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };


    var _isLogIn= function () {

        console.log($rootScope.user.authenticated);
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

    return authServiceFactory;

}]);