app.controller('searchCoachController', ['$scope', '$window', '$routeParams', 'searchCoachService', 'commonService', '$http', 'toastr', '$rootScope', '$location',
    function ($scope, $window, $routeParams, searchCoachService, commonService, $http, toastr, $rootScope, $location) {

        /*Declaración de variables*/

        $scope.picFile = "https://allwiners.blob.core.windows.net/photos/default_avatar-thumb.jpg";

        $scope.pagina = 1;

        $scope.cantidad = 10;

        $scope.searchProfile = {
            Nombre: "",
            Pagina: 1,
            Cantidad: 10
        };

        $scope.Busqueda = null;

        $scope.searchResultCount = null;
        $scope.itemSelect = {};

        $scope.recomenda = {
            Texto: "",
            EmisorId: 0,
            ReceptorId: 0
        };
        $scope.modulo = 'Buscar Entrenadores';
        $scope.moduloicono = 'fa fa-user-secret';
        $scope.moduloChange = 'Buscar Judadores';
        $scope.linkSearchChange = '#!/Search';
        $scope.moduloiconoChange = 'fa fa-search';
        
        /*Declaración de funciones*/

        angular.element(function () {

            commonService.getMenu().then(function (response) {
                $rootScope.user.menu = response.data;

            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

            searchCoachService.getBuscarEntrenadorViewModel().then(function (response) {
                $scope.Busqueda = response.data;
                $scope.Busqueda.Pagina = 1;
                $scope.Busqueda.Cantidad= 10
                searchCoach();

            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

            

        });

        $scope.searchCoach = (function () {
            searchCoach();
        });

        

        function searchCoach() {

            $scope.Busqueda.Nombre = $scope.principalSearch;

            $scope.myPromise = searchCoachService.searchCoach($scope.Busqueda).then(function (response) {

                $scope.searchResult = response.data;

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda!', 'Error');

            });

            searchCoachService.searchCoachCount($scope.Busqueda).then(function (response) {

                $scope.searchResultCount = response.data;

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda!', 'Error');

            });

            $http.get('json/paises.json').then(function (data) {

                $scope.paises = data.data;

            }).catch(function (err) {

                //toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

            });

        }

        function getSearchFilters() {

            $scope.Busqueda.Nombre = $scope.principalSearch;


            $scope.Busqueda.Cantidad = $scope.cantidad;

            $scope.myPromise = searchCoachService.searchFiltersCoach($scope.Busqueda).then(function (response) {

                $scope.searchResult = response.data;

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda del perfil! ' + err, 'Error');

            });
            searchCoachService.searchFiltersCoachCount($scope.Busqueda).then(function (response) {

                $scope.searchResultCount = response.data;

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda!', 'Error');

            });

        }

        $scope.paginacion = (function (pag) {

            if ($scope.Busqueda.Pagina == undefined)

                $scope.Busqueda.Pagina = 1;

            var pagNew = $scope.Busqueda.Pagina + pag;

            if (pagNew != 0) {

                if (pag > 0) {

                    var cantrest = ((pagNew - 1) * $scope.cantidad);

                    if (($scope.searchResultCount - cantrest) < 0) {
                        toastr.info('No hay mas registro', 'Info');
                        return;
                    }

                }

                $scope.Busqueda.Pagina = pagNew;

                getSearchFilters();

            } else {
                toastr.info('estas en la primera pagina', 'Info');
            }

        });
        //$scope.abrirlink = (function (item) {
        //    $window.open(item.Link, '_blank');
        //});
        //$scope.recomendarItem = (function (item) {
        //    $scope.recomenda.Texto = "";
        //    $scope.recomenda.ReceptorId = item.UsuarioId;
        //    $scope.itemSelect = item;
        //});
        //$scope.saveRecomendarItem = (function () {
        //    if ($scope.recomenda.Texto != '') {
        //        searchService.saveRecomendarItem($scope.recomenda).then(function () {
        //            toastr.success('¡Gracias por recomendar a ' + $scope.itemSelect.Nombre + ', ' + $scope.itemSelect.Apellido, '¡Perfecto!');

        //        }).catch(function (err) {
        //            toastr.error('¡Ha ocurrido un error en la busqueda del perfil! ' + err, 'Error');
        //        });
        //    }
        //});
    }]);