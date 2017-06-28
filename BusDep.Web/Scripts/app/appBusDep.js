var appBusDep = angular.module('appBusDep', ['ngRoute', 'ngMaterial']);// 'dataGrid', 'pagination', 'ngMaterial', 'ngMessages', 'blockUI', "ngAnimate", "ngAria", "mdPickers", "moment-picker"



var configFunction = function ($routeProvider, $locationProvider) {
    $locationProvider.html5Mode(
        {
        enabled: false,
        requireBase: false
    });

    $routeProvider
        .when('/',
        {
            templateUrl: '/Home/Login'
        });
}

configFunction.$inject = ['$routeProvider', '$locationProvider', '$mdDateLocaleProvider'];

//angular.module('appBusDep').config(function ($mdDateLocaleProvider) {
//    $mdDateLocaleProvider.formatDate = function (date) {
//        return moment(date).format('DD-MM-YYYY');
//    };
//});

appBusDep.config(configFunction);

