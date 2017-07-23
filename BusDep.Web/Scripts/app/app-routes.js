app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '/Home/HomeContent',
            controller: 'indexController',
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
        .when('/Profile/PrivateProfile', {
            templateUrl: '/Profile/PrivateProfile',
            controller: 'privateProfileController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
        })
        .otherwise({
            redirectTo: '/'
        });
}]);
