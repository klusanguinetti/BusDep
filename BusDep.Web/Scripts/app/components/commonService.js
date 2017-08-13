'use strict';
app.service('commonService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Base/';

    this.getPerfilJugadorShort = function () {

        return $http.post(serviceBase + 'GetPerfilJugadorShort').then(function (response) {
            return response;
        });

    };
}]);