app.controller('indexController', function ($scope, $location) {


    $scope.search = function () {

        $location.path("/Search");

    }

    $(function () {
        $('.row-featured .f-category').matchHeight();
        $.fn.matchHeight._apply('.row-featured .f-category');
    });

})