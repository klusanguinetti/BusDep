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
                locale: 'es',
                widgetPositioning: {
                    horizontal: 'auto',
                    vertical: 'bottom'
                    }
            }).on('dp.change', function (e) {
                ngModelCtrl.$setViewValue(e.target.value);
            });
        }
    };
});
app.directive('opendialog',
   function() {
       var openDialog = {
           link :   function(scope, element, attrs) {
               function openDialog() {
                   var element = angular.element('#myModal');
                   var ctrl = element.controller();
                   ctrl.setModel(scope.blub);
                   element.modal('show');
               }
               element.bind('click', openDialog);
           }
       }
       return openDialog;
   });   