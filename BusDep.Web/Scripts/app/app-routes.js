app.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: '/Home/HomeContent',
            controller: 'indexController'
        })
        .when('/Terms', {
            templateUrl: '/Home/Terms'
        })
        .when('/AboutUs', {
            templateUrl: '/Home/AboutUs'
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
        .when('/ProfilePublic/JugadorPublic/:jugadorId?', {
            templateUrl: '/ProfilePublic/JugadorPublic'
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
        .when('/SearchCoach/', {
            templateUrl: '/Search/SearchCoach',
            controller: 'searchCoachController',
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
        .when('/Coach/PrivateProfileEntrenador', {
            templateUrl: '/Coach/PrivateProfileEntrenador',
            controller: 'privateProfileCoachController',
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
     .when('/Coach/SelfAppraisal', {
         templateUrl: '/Coach/SelfAppraisal',
            controller: 'selfAppraisalController',
            resolve: {
                permission: function (authService) {
                    return authService.isLogIn();
                }
            }
     })
     .when('/Profile/SportData', {
         templateUrl: '/Profile/SportDataProfile',
         controller: 'sportDataController',
         resolve: {
             permission: function (authService) {
                 return authService.isLogIn();
             }
         }
     })
      .when('/Coach/SportsHistory/List/:action?/:result?', {
          templateUrl: '/Coach/SportsHistory',
          controller: 'sportsCoachHistoryListController',
          resolve: {
              permission: function (authService) {
                  return authService.isLogIn();
              }
          }
      })
        .when('/Coach/SportsHistory/:id?', {
            templateUrl: '/Coach/Antecedente',
            controller: 'sportsCoachHistoryController',
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
