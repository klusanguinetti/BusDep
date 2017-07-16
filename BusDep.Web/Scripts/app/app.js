var app;
(function () {
    app = angular.module("appBusDep", ['ngRoute','LocalStorageModule','angular-loading-bar','ngMessages','ui.carousel']);
})();

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);
