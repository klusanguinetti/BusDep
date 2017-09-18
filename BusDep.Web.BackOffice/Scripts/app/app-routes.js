app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '/Home/HomeContent',
            controller: 'indexController'
        })
        .when('/Login/:lastAction?', {
            templateUrl: '/Home/Login',
            controller: 'loginController'
        })
        .when('/PublicidadList/:action?/:result?', {
            templateUrl: '/ABM/PublicidadList',
            controller: 'publicidadController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
        })
        .when('/PublicidadABM/:id?', {
            templateUrl: '/ABM/PublicidadABM',
            controller: 'publicidadABMController',
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
