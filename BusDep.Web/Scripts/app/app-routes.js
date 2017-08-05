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
            controller: 'searchController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
        })
        .when('/Profile/:type/:id', {
            templateUrl: '/Profile/Index',
            controller: 'publicProfileController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
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
        .when('/History/SportsHistory/List', {
            templateUrl: '/History/SportsHistory',
            controller: 'sportsHistoryListController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
        })
        .when('/History/SportsHistory', {
            templateUrl: '/History/Antecedente',
            controller: 'sportsHistoryController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
        })
     .when('/Evaluation/SelfAppraisal', {
         templateUrl: '/Evaluation/SelfAppraisal',
         controller: 'selfAppraisalController',
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
