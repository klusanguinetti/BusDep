app.directive('datetimepicker', function () {
    return {
        restrict: 'AE',
        require: '?ngModel',
        scope: {
            onChange: '&'
        },
        link: function (scope, element, attrs, ngModelCtrl) {
            element.datetimepicker({
                viewMode: 'days',
                format: 'DD/MM/YYYY',
                locale: 'es'
            }).on('dp.change', function (e) {
                ngModelCtrl.$setViewValue(e.target.value);
            });
        }
    };
});