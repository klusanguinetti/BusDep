(function () {
    'use strict';

    var publicControllerId = 'publicController';
    angular.module('appBusDep').controller(publicControllerId, publicController);

    publicController.$inject = ['$scope', '$location'];

    function publicController($scope, $location) {
        var vm = this;
       
        vm.submitLogin = function() {
            $location.path('/Login');
        }
    };
})();