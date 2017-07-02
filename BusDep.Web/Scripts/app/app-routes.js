app.config(function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '/Home/Index',
            controller: 'indexController'
        })
        .when('/Account/Login', {
            templateUrl: '/Account/Login',
            controller: 'loginController'
        })
        .when('/Account/Register', {
            templateUrl: '/Account/Register',
            controller: 'registerController'
        })
        .otherwise({
            redirectTo: '/'
        });
});