(function () {
    'use strict';

    var loginControllerId = 'loginController';
    angular.module('appBusDep').controller(loginControllerId, loginController);

    loginController.$inject = ['$scope', '$location'];

    function loginController($scope, $location) {
        var vm = this;
        //Login
        vm.Usuario = '';
        vm.Password = '';
        vm.Remember = false;
        //Registracion
        vm.Nombre = '';
        vm.Apellido = '';
        vm.email = '';
        vm.isLoading = true;


         vm.submitLogin = function () {
             
             if (vm.Usuario.length < 7) {
                vm.loginError("Usuario incorrecto, ingrese nuevamente");
                return;
            }

             if (vm.Password == '') {
                vm.loginError("Password incorrecta ingrese nuevamente");
                return;
            }

            vm.isLoading = true;
            //loginService.doLogin(vm.name, vm.password)
            //     .then(function (response) {
            //         var result = response.data;
            //         if (result == "OK")
            //        $window.location.href = '/';
            //    else {
            //        vm.loginError("Error al validar el usuario." + result);
            //    }
            //    //Resultado de la llamada.
            //}, function (error) {
            //         alert(error.data.ExceptionMessage);
            //     });

        }
        vm.Error = function (errorMessage) {
            var wrap = $('#login-wrapper');

            vm.message = errorMessage;

            vm.isLoading = false;

            $('input', wrap).blur();

            // hacemos esto para disparar de vuelta la animacion css
            wrap.removeClass('error');
            wrap.position(wrap.position());
            wrap.addClass('error');
        };
        vm.loginError = function (errorMessage) {
            vm.password = "";
            vm.Error(errorMessage);
            common.showError(errorMessage, null);
        };


    };
})();