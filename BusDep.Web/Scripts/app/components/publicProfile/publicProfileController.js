app.controller('publicProfileController', ['$scope', '$routeParams', 'publicProfileService', 'toastr', '$location',
    function ($scope, $routeParams, publicProfileService, toastr, $location) {

        $scope.data = [];

        $scope.options = {
            legend: {
                position: 'bottom',
                display: true,
                labels: {
                    fontColor: 'rgb(206, 78, 39)',
                    fontSize: 10
                }
            }
        };
       
        angular.element(function () {

            var idJugador = $routeParams.id;

            console.log(idJugador);

            //validar q sea un numero TODO

            $scope.myPromise = publicProfileService.getPublicProfile(idJugador).then(function (response) {

                $scope.datosPerfil = response.data;

                if (response.data.FechaNacimiento != null) {

                    var date = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");

                    $scope.datosPerfil.FechaNacimiento = date;

                }
            }).catch(function (err) {
                 
                if (err.status == "404") {
                    $location.path("/Home/Index");
                } else {
                    toastr.error('¡Error desconocido!', 'Error');
                }

            });

        });
    }])