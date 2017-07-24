app.controller('searchController', ['$scope', '$routeParams', 'searchService', '$http', function ($scope, $routeParams, searchService, $http) {

    /*Declaración de variables*/

    $scope.searchValue = "";

    $scope.searchProfile = {
        Id: "",
        Nombre: ""
    };

    /*Declaración de funciones*/

    angular.element(function () {

        var searchValue = $routeParams.b;

        $scope.searchProfile.Nombre = searchValue;

        $http.get('json/paises.json').then(function (data) {

            $scope.paises = data.data;

            searchService.searchPlayer($scope.searchProfile).then(function (response) {

                console.log(response.data);

                $scope.searchResult = response.data;

                $scope.searchValue = searchValue;

            }).catch(function (err) {

                //toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

            });

        }).catch(function (err) {

            //toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

        });

    });

}]);