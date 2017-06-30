app.config(function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '/Home/Index',
            controller: 'indexController'
        })
        .when('/Account/Login', {
            templateUrl: '/Account/Index',
            controller: 'loginController'
        })
        .otherwise({
            redirectTo: '/'
        });
});