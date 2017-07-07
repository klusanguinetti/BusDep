var app;
(function () {
    app = angular.module("appBusDep", ['ngRoute','LocalStorageModule','angular-loading-bar']);
})();

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
