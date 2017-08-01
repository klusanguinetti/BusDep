app.controller('publicProfileController', ['$scope', '$routeParams', 'publicProfileService', 'toastr',
    function ($scope, $routeParams, publicProfileService, toastr) {

        angular.element(function () {

            var idJugador = $routeParams.id

            console.log(idJugador);

            //validar q sea un numero TODO

            $scope.myPromise = publicProfileService.getPublicProfile(idJugador).then(function (response) {

                $scope.datosPerfil = response.data;
                console.log($scope.datosPerfil);
                if (response.data.FechaNacimiento != null) {

                    var date = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");

                    $scope.datosPerfil.FechaNacimiento = date;

                }

            }).catch(function (err) {

                console.log(err);
                toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

            });

        });

    }])