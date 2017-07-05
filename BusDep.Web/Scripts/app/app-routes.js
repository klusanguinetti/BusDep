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
        .when('/Search', {
            templateUrl: '/Search/Search',
            controller: 'searchController'
        })
        .when('/Profile/:type/:id', {
            templateUrl: '/Profile/Index',
            controller: 'publicProfileController'
        })
        .otherwise({
            redirectTo: '/'
        });
});