app.controller('searchController', ['$scope', '$window', '$routeParams', 'searchService', 'commonService', 'privateProfileService', '$http', 'toastr', '$rootScope', '$location',
    function ($scope, $window, $routeParams, searchService, commonService, privateProfileService, $http, toastr, $rootScope, $location) {

        /*Declaración de variables*/

        $scope.picFile = "https://allwiners.blob.core.windows.net/photos/default_avatar-thumb.jpg";

        $scope.pagina = 1;

        $scope.cantidad = 10;

        $scope.searchProfile = {
            Nombre: "",
            pagina: 1,
            cantidad: 10
        };

        $scope.principalSearch = "";

        $scope.fichajes = {};

        $scope.perfiles = {};

        $scope.puestos = {};

        $scope.pies = {};

        $scope.Busqueda = null;

        $scope.searchResultCount = null;
        $scope.itemSelect = {};

        $scope.recomenda = {
            Texto: "",
            EmisorId: 0,
            ReceptorId: 0
        };

        /*Declaración de funciones*/

        angular.element(function () {

            commonService.getMenu().then(function (response) {
                $rootScope.user.menu = response.data;

            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

            searchService.getBuscarJugadorViewModel().then(function (response) {

                $scope.Busqueda = response.data;

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

            privateProfileService.getPuestosBasicos().then(function (response) {
                $scope.puestos = response.data;
            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

            privateProfileService.getPies().then(function (response) {
                $scope.pies = response.data;
            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

            $scope.principalSearch = $routeParams.b;

            searchPlayer();

        });

        $scope.search = (function () {
            searchPlayer();
        });

        $scope.clearFilter = (function () {

            $scope.Busqueda.EdadHasta = null;

            for (var i = 0; i < $scope.fichajes.length; ++i) {
                $scope.fichajes[i].Selected = false;
            }
            for (var i = 0; i < $scope.perfiles.length; ++i) {
                $scope.perfiles[i].Selected = false;
            }
            for (var i = 0; i < $scope.puestos.length; ++i) {
                $scope.puestos[i].Selected = false;
            }
            for (var i = 0; i < $scope.pies.length; ++i) {
                $scope.pies[i].Selected = false;
            }

        });

        function searchPlayer() {

            $scope.searchProfile.Nombre = $scope.principalSearch;

            $scope.myPromise = searchService.searchPlayer($scope.searchProfile).then(function (response) {

                $scope.searchResult = response.data;

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda!', 'Error');

            });

            searchService.searchPlayerCount($scope.searchProfile).then(function (response) {
  
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

        function getFields(input, field) {

            var output = [];

            for (var i = 0; i < input.length; ++i) {
                if (input[i].Selected)
                    output.push(input[i][field]);
            }

            return output;

        }

        $scope.searchFilters = (function () {
            getSearchFilters();

        });

        $scope.clearSelect = (function (input) {
            for (var i = 0; i < input.length; ++i) {
                input[i].Selected = false;
            }
        });

        $scope.selectItem = (function (input, item) {
            for (var i = 0; i < input.length; ++i) {
                input[i].Selected = item.Id == input[i].Id;
            }
        });

        function getSearchFilters() {

            $scope.Busqueda.Nombre = $scope.principalSearch;

            $scope.Busqueda.Fichaje = getFields($scope.fichajes, 'Descripcion');

            $scope.Busqueda.Perfil = getFields($scope.perfiles, 'Descripcion');

            $scope.Busqueda.Puesto = getFields($scope.puestos, 'Descripcion');

            $scope.Busqueda.Pie = getFields($scope.pies, 'Descripcion');

            $scope.Busqueda.Cantidad = $scope.cantidad;

            $scope.myPromise = searchService.searchFiltersPlayer($scope.Busqueda).then(function (response) {

                $scope.searchResult = response.data;

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda del perfil! ' + err, 'Error');

            });

            searchService.searchFiltersPlayerCount($scope.Busqueda).then(function (response) {

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
        $scope.abrirlink = (function (item) {
            $window.open(item.Link, '_blank');
        });
        $scope.recomendarItem = (function (item) {
            $scope.recomenda.Texto = "";
            $scope.recomenda.ReceptorId = item.UsuarioId;
            $scope.itemSelect = item;
        }); 
        $scope.saveRecomendarItem = (function () {
            searchService.saveRecomendarItem($scope.recomenda).then(function () {

                toastr.success('¡Gracias por recomendar a ' +  $scope.itemSelect.Nombre + ', ' + $scope.itemSelect.Apellido, '¡Perfecto!');

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda del perfil! ' + err, 'Error');

            });
        });
    }]);