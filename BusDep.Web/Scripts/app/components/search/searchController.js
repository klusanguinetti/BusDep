app.controller('searchController', ['$scope', '$routeParams', 'searchService', '$http', 'toastr', '$location',
    function ($scope, $routeParams, searchService, $http, toastr, $location) {

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

        /*Declaración de funciones*/

        angular.element(function () {

            $scope.searchValue = $routeParams.b;

            $scope.searchProfile.Nombre = $scope.searchValue;

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

        $scope.searchFilters = (function () {

            $scope.searchProfile.Edad = parseInt($scope.searchProfile.Edad, 10);

            console.log($scope.searchProfile);

            $scope.myPromise = searchService.SearchFiltersPlayer($scope.searchProfile).then(function (response) {

                console.log(response.data);
                $scope.searchResult = response.data;

            }).catch(function (err) {

                toastr.error('¡Ha ocurrido un error en la busqueda del perfil! ' + err, 'Error');

            });

        });


    }]);