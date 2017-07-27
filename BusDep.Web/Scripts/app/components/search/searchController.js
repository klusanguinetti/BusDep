app.controller('searchController', ['$scope', '$routeParams', 'searchService', 'privateProfileService', '$http', 'toastr', '$location',
    function ($scope, $routeParams, searchService, privateProfileService, $http, toastr, $location) {

        /*Declaración de variables*/

        $scope.searchValue = "";

        $scope.searchProfile = {
            Id: "",
            Nombre: "",
            PaisIso: "",
            Perfil: "",
            Fichaje: "",
            Edad: 0
        };
        $scope.Busqueda = null;
        $scope.fichajes = {};
        $scope.perfiles = {};
        $scope.puestos = {};

        /*Declaración de funciones*/

        angular.element(function () {

            $scope.searchValue = $routeParams.b;

            $scope.searchProfile.Nombre = $scope.searchValue;

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
            searchService.getPuestosBasicos().then(function (response) {
                $scope.Busqueda = response.data;
            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });
            

            searchPlayer();



        });

        $scope.search = (function () {

            $scope.searchValue = $scope.searchProfile.Nombre;

            searchPlayer();

        });

        function searchPlayer(searchValue) {

            $scope.myPromise = searchService.searchPlayer($scope.searchProfile).then(function (response) {

                console.log(response.data);

                $scope.searchResult = response.data;

            }).catch(function (err) {

                //toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

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

            //$scope.searchProfile.Edad = parseInt($scope.searchProfile.Edad, 10);
            $scope.Busqueda.EdadDesde = parseInt($scope.searchProfile.Edad, 10);
            $scope.Busqueda.Fichaje = getFields($scope.fichajes, 'Descripcion');
            $scope.Busqueda.Perfil = getFields($scope.perfiles, 'Descripcion');
            $scope.Busqueda.Puesto = getFields($scope.puestos, 'Descripcion');
            
            //$scope.fichajes

            console.log($scope.Busqueda);

            $scope.myPromise = searchService.SearchFiltersPlayer($scope.Busqueda).then(function (response) {

                console.log(response.data);
                $scope.searchResult = response.data;

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda del perfil! ' + err, 'Error');

            });

        });
       
       

    }]);