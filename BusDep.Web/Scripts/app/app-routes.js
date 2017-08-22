app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '/Home/HomeContent',
            controller: 'indexController',
        })
        .when('/Account/Login/:lastAction?', {
            templateUrl: '/Account/Login',
            controller: 'loginController'
        })
        .when('/Account/Register', {
            templateUrl: '/Account/Register',
            controller: 'registerController'
        })
        .when('/Account/PasswordRecovery', {
            templateUrl: '/Account/PasswordRecovery',
            controller: 'passwordRecoveryController'
        })
        .when('/Account/PasswordRecoveryChange/:token?', {
            templateUrl: '/Account/UpdatePasswordRecovery',
            controller: 'passwordRecoveryController'
        })
        .when('/Account/PasswordChange', {
            templateUrl: '/Account/PasswordChange',
            controller: 'passwordChangeController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
        })
        .when('/Search/:b?/:message?', {
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
        .when('/Profile/PrivateProfileEntrenador', {
            templateUrl: '/Profile/PrivateProfileEntrenador',
            controller: 'privateProfileEntrenadorController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
        })
        .when('/History/SportsHistory/List/:action?/:result?', {
            templateUrl: '/History/SportsHistory',
            controller: 'sportsHistoryListController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
        })
        .when('/History/SportsHistory/:id?', {
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
