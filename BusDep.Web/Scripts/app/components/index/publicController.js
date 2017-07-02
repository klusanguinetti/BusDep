app.controller('indexController', function ($scope) {

    $(function () {
        $('.row-featured .f-category').matchHeight();
        $.fn.matchHeight._apply('.row-featured .f-category');
    });

})