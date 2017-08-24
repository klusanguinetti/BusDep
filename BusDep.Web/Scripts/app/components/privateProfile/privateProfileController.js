app.controller('privateProfileController', ['$scope', 'privateProfileService', 'commonService', '$http', '$rootScope', 'toastr', 'Upload', '$timeout',
function ($scope, privateProfileService, commonService, $http, $rootScope, toastr, Upload, $timeout) {


    $scope.Mail = $rootScope.user.UserName;
    $scope.autoEvaluacion = {};
    $scope.paises = {};

    $scope.datosPersonales = {};

    $scope.jugador = {};

    $scope.fichajes = {};
    $scope.perfiles = {};
    $scope.puestos = {};
    $scope.pies = {};
    $scope.sosVisible = true;
    $scope.fechaNacimiento = null;
    $scope.picFile = "Uploads/defaultavatar.jpg";

    $scope.loginData = {
        Id: "",
        Mail: "",
        OldPassword: "",
        NewPassword: ""
    };

    $scope.modulo = 'Mis Datos';
    $scope.moduloicono = '';

    angular.element(function () {

        commonService.getMenu().then(function (response) {

            $rootScope.user.menu = response.data;

            angular.forEach($rootScope.user.menu, function (value, key) {

                if (value.Descripcion == $scope.modulo) {
                    $scope.moduloicono = value.Icono;
                }

            });

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

        privateProfileService.getUserDetails().then(function (response) {

            $http.get('json/paises.json').then(function (data) {
                $scope.paises = data.data;
            });

            $scope.datosPersonales = response.data;

            if (response.data.FechaNacimiento != null) {


                var date = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");
                $scope.fechaNacimiento = date;

            }
            commonService.getPerfilJugadorShort().then(function (response) {
                if (response.data.FechaNacimiento != null) {
                    response.data.FechaNacimiento = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");
                }
                $scope.perfilShort = response.data;

                if (response.data.FotoRostro != "") {
                    $scope.picFile = response.data.FotoRostro;
                }

            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

        }).catch(function (err) {

            toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

        });

        privateProfileService.getJugador().then(function (response) {
            $scope.jugador = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        privateProfileService.getFichajes().then(function (response) {
            $scope.fichajes = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        privateProfileService.getPerfiles().then(function (response) {
            $scope.perfiles = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        privateProfileService.getPuestos().then(function (response) {
            $scope.puestos = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        privateProfileService.getPies().then(function (response) {
            $scope.pies = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });


    });

    $scope.passwordUpdate = function () {

        var loginDataPost = {
            Id: $scope.loginData.Id,
            Mail: $scope.loginData.Mail,
            OldPassword: window.btoa($scope.loginData.OldPassword),
            NewPassword: window.btoa($scope.loginData.NewPassword)
        };

        if ($scope.passwordForm.$valid) {

            return privateProfileService.passwordUpdate(loginDataPost).then(function (response) {

                toastr.success('¡Contraseña actualizada con éxito!', '¡Perfecto!');

                $scope.loginData.NewPassword = "";
                $scope.loginData.OldPassword = "";

                clearErrors();

            }).catch(function (err) {

                if (err.status == "404") {
                    toastr.error('¡La contraseña actual es incorrecta!', 'Error');
                } else {
                    toastr.error('¡Error desconocido!', 'Error');
                }

            });

        }

    };

    $scope.jugadorUpdate = function () {


        return privateProfileService.jugadorUpdate($scope.jugador).then(function (response) {

            toastr.success('¡Informacion guardada con éxito!', '¡Perfecto!');

            clearErrors();

        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');
        });


    };

    $scope.UpdateProfile = function () {
        if ($scope.datosPersonales.PaisIso != '') {

            angular.forEach($scope.paises, function (value, key) {
                if (value.CodigoIso == $scope.datosPersonales.PaisIso) {
                    $scope.datosPersonales.Pais = value.Nombre;
                }
            });
        }
        if ($scope.datosPersonales.NacionalidadIso != '') {

            angular.forEach($scope.paises, function (value, key) {
                if (value.CodigoIso == $scope.datosPersonales.NacionalidadIso) {
                    $scope.datosPersonales.Nacionalidad = value.Nombre;
                }
            });
        }
        if ($scope.datosPersonales.NacionalidadIso1 != '') {

            angular.forEach($scope.paises, function (value, key) {
                if (value.CodigoIso == $scope.datosPersonales.NacionalidadIso1) {
                    $scope.datosPersonales.Nacionalidad1 = value.Nombre;
                }
            });
        }
        $scope.datosPersonales.FechaNacimiento = $scope.fechaNacimiento;

        return privateProfileService.saveUserDetails($scope.datosPersonales).then(function (response) {

            toastr.success('¡Perfil actualizado con éxito!', '¡Perfecto!');

        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');

        });

    };

    function clearErrors() {
        $scope.passwordForm.$setPristine();
        $scope.passwordForm.$setValidity();
        $scope.passwordForm.$setUntouched();
    }

    $scope.uploadFiles = function (file, errFiles) {

        $scope.f = file;

        $scope.errFile = errFiles && errFiles[0];

        if (file) {

            file.upload = Upload.upload({
                url: 'api/Files/Add/',
                data: { file: file }
            });

            file.upload.then(function (response) {

            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total));
            });
        }
    }

}]);