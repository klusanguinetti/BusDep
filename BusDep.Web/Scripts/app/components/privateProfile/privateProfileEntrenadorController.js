app.controller('privateProfileEntrenadorController', ['$scope', 'privateProfileService', 'commonService', '$http', '$rootScope', 'toastr',
function ($scope, privateProfileService, commonService, $http, $rootScope, toastr) {


    $scope.Mail = $rootScope.user.UserName;
    $scope.paises = {};

    $scope.datosPersonales = {};

    $scope.sosVisible = false;

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
        }).catch(function (err) {

            toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

        });
    });

    

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
}]);