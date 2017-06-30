app.controller('loginController', function ($scope) {


    var vm = this;

    vm.Usuario = '';
    vm.Password = '';
    vm.Remember = false;

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

})