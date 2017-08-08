app.controller('publicProfileController', ['$scope', '$routeParams', 'publicProfileService', 'toastr', '$location',
    function ($scope, $routeParams, publicProfileService, toastr, $location) {

        $scope.data = [];

        $scope.color = {
            "colours": [{ // default
                "fillColor": "rgba(224, 108, 112, 1)",
                "strokeColor": "rgba(207,100,103,1)",
                "pointColor": "rgba(220,220,220,1)",
                "pointStrokeColor": "#fff",
                "pointHighlightFill": "#fff",
                "pointHighlightStroke": "rgba(151,187,205,0.8)"
            }]
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

                for (var i = 0; i < $scope.datosPerfil.AutoEvaluacion.Cabeceras.length; i++) {
                    $scope.data.push({
                        labels: $scope.datosPerfil.AutoEvaluacion.Cabeceras[i].Labels, /*["Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running"],*/
                        datasets: [
                            {
                                fillColor: ["rgba(220,220,220,0.5)", "navy", "red", "orange"],
                                strokeColor: "rgba(220,220,220,0.8)",
                                highlightFill: "rgba(220,220,220,0.75)",
                                highlightStroke: "rgba(220,220,220,1)",
                                data: $scope.datosPerfil.AutoEvaluacion.Cabeceras[i].Values /* [65, 59, 90, 81, 56, 55, 40]*/
                            }
                        ]
                        //data: $scope.datosPerfil.AutoEvaluacion.Cabeceras[i].Values
                    });
                }

            }).catch(function (err) {
                 
                if (err.status == "404") {
                    $location.path("/Home/Index");
                } else {
                    toastr.error('¡Error desconocido!', 'Error');
                }

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