app.controller('headerProfileController', ['$scope', 'headerProfileService', 'commonService', '$http', 'Flash', 'Upload', '$timeout',
function ($scope, headerProfileService, commonService, $http, Flash, Upload, $timeout) {

    $scope.picFile = "https://allwiners.blob.core.windows.net/photos/default_avatar-thumb.jpg";

    angular.element(function () {

        commonService.getPerfilJugadorShort().then(function (response) {

            if (response.data.FechaNacimiento != null) {
                response.data.FechaNacimiento = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");
            }

            $scope.perfilShort = response.data;

            if (response.data.FotoRostro != null) {
                $scope.picFile = response.data.FotoRostro;
            }

        }).catch(function (err) {
            console.log("Error: " + err)
        });

    });

    $scope.uploadFiles = function (file, errFiles) {

        $scope.f = file;

        $scope.errFile = errFiles && errFiles[0];
         
        if (file) {

            file.upload = Upload.upload({
                url: 'api/Files/AddFotoRostro/',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    $scope.headerResult = response.data;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total));
            });

        }
    }

    $scope.removePhoto = function () {

        return headerProfileService.removePhoto().then(function (response) {

            $scope.picFile = "https://allwiners.blob.core.windows.net/photos/default_avatar-thumb.jpg";

        }).catch(function (err) {

            console.log("Error: " + err);

        });

    };

}]);