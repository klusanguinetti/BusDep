app.controller('publicProfileController', ['$scope', '$routeParams', 'publicProfileService', 'toastr',
    function ($scope, $routeParams, publicProfileService, toastr) {
        $scope.data = [];

        //$scope.colours = [
        //    {
        //        fillColor: 'rgba(47, 132, 71, 0.8)',
        //        strokeColor: 'rgba(47, 132, 71, 0.8)',
        //        highlightFill: 'rgba(47, 132, 71, 0.8)',
        //        highlightStroke: 'rgba(47, 132, 71, 0.8)'
        //    }
        //];
        $scope.colours = ['#72C02C', '#3498DB', '#717984', '#F1C40F'];
        angular.element(function () {

            var idJugador = $routeParams.id;

            console.log(idJugador);

            //validar q sea un numero TODO

            $scope.myPromise = publicProfileService.getPublicProfile(idJugador).then(function (response) {

                $scope.datosPerfil = response.data;
                console.log($scope.datosPerfil);
                if (response.data.FechaNacimiento != null) {

                    var date = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");

                    $scope.datosPerfil.FechaNacimiento = date;

                }

                for (var i = 0; i < $scope.datosPerfil.AutoEvaluacion.Cabeceras.length; i++) {
                    $scope.data.push({
                        labels: $scope.datosPerfil.AutoEvaluacion.Cabeceras[i].Labels, /*["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],*/
                        //datasets: [
                        //    {
                        //        fillColor: "rgba(220,220,220,0.2)",
                        //        strokeColor: "rgba(220,220,220,1)",
                        //        pointColor: "rgba(220,220,220,1)",
                        //        data: $scope.datosPerfil.AutoEvaluacion.Cabeceras[i].Values /* [65, 59, 90, 81, 56, 55, 40]*/
                        //    }
                        //]
                        data: $scope.datosPerfil.AutoEvaluacion.Cabeceras[i].Values
                    });
                }

            }).catch(function (err) {

                console.log(err);
                toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

            });

        });

        function RadarCtrl(id) {
            this.data = {
                labels: $scope.datosPerfil.AutoEvaluacion.Cabeceras[id].Labels,/*["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],*/
                datasets: [
                    {
                        fillColor: "rgba(220,220,220,0.2)",
                        strokeColor: "rgba(220,220,220,1)",
                        pointColor: "rgba(220,220,220,1)",
                        data: $scope.datosPerfil.AutoEvaluacion.Cabeceras[id].Values /* [65, 59, 90, 81, 56, 55, 40]*/
                    }
                ]
            };
        }

    }])