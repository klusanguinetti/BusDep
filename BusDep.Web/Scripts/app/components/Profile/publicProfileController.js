app.controller('publicProfileController', ['$scope', '$routeParams', 'commonService', 'publicProfileService', '$rootScope', 'toastr', '$location',
    function ($scope, $routeParams, commonService, publicProfileService, toastr, $location) {
        
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
        $scope.optionsradar = {
            scale: {
                ticks: {
                    beginAtZero: true,
                    max: 10
                }
            }
        }
        $scope.optionsBar = {
            legend: {
                display: false
            },
            scales: {
                xAxes: [{
                    stacked: true,
                    ticks: {
                        beginAtZero: true,
                        max: 10
                    }
                }],
                yAxes: [{
                    stacked: true,
                    ticks: {
                        beginAtZero: true,
                        max: 10
                    },
                    gridLines: {
                        offsetGridLines: true
                    }
                }]
            }
        };


        $scope.graficaTecnica = {};
        $scope.graficaCondicion = {};
        $scope.graficaTactica = {};
        $scope.graficaCualidades = {};
        $scope.graficaCoordinacion = {};
        $scope.graficaEntorno = {};
        $scope.AutoEvaluacion = {};
        $scope.Antecedentes = [];
        $scope.Recomendaciones=[];

        angular.element(function () {
            commonService.getMenu().then(function (response) {
                $rootScope.user.menu = response.data;

            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

            var idJugador = $routeParams.id;


            $scope.myPromise = publicProfileService.getPublicProfile(idJugador).then(function (response) {
                
                $scope.datosPerfil = response.data;

                if (response.data.FechaNacimiento != null) {

                    var date = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");

                    $scope.datosPerfil.FechaNacimiento = date;

                }

                publicProfileService.getAutoEvaluacion(idJugador).then(function (response) {
                    $scope.AutoEvaluacion = response.data;
                    angular.forEach($scope.AutoEvaluacion.Cabeceras, function (value, key) {
                        if (value.Descripcion == 'Técnica') {
                            $scope.graficaTecnica = value;
                        }
                        else if (value.Descripcion == 'Condición Fisica') {
                            $scope.graficaCondicion = value;
                        }
                        else if (value.Descripcion == 'Táctica (cualidades cognoscitivas)') {
                            $scope.graficaTactica = value;
                        }
                        else if (value.Descripcion == 'Cualidades mentales') {
                            $scope.graficaCualidades = value;
                        }
                        else if (value.Descripcion == 'Coordinación') {
                            $scope.graficaCoordinacion = value;
                        }
                        else if (value.Descripcion == 'Entorno social') {
                            $scope.graficaEntorno = value;
                        }
                    });

                }).catch(function (err) {
                    toastr.error('¡Ha ocurrido un error!', 'Error');
                });
                publicProfileService.getAntecedentes(idJugador).then(function (response) {
                    $scope.Antecedentes = response.data;
                }).catch(function (err) {
                    toastr.error('¡Ha ocurrido un error!', 'Error');
                });

                publicProfileService.getRecomendaciones(idJugador).then(function (response) {
                    $scope.Recomendaciones = response.data;
                }).catch(function (err) {
                    toastr.error('¡Ha ocurrido un error!', 'Error');
                });

            }).catch(function (err) {

                if (err.status == "404") {
                    $location.path("/Home/Index");
                } else {
                    toastr.error('¡Error desconocido!', 'Error');
                }

            });
        });

       

        $scope.options = function (evaluacion) {

            if (evaluacion == 'Coordinación' || evaluacion == 'Cualidades mentales') {
                return {
                    legend: {
                        display: false
                    },
                    scales: {
                        xAxes: [
                            {
                                stacked: true,
                                ticks: {
                                    beginAtZero: true,
                                    max: 10
                                }
                            }
                        ],
                        yAxes: [
                            {
                                stacked: true,
                                ticks: {
                                    beginAtZero: true,
                                    max: 10
                                },
                                gridLines: {
                                    offsetGridLines: true
                                }
                            }
                        ]
                    }
                };
            }
            else {
                return {
                    legend: {
                        position: 'bottom',
                        display: true,
                        labels: {
                            fontColor: 'rgb(206, 78, 39)',
                            fontSize: 10
                        }
                    }
                };
            }
        };

    }])