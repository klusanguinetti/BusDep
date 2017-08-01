'use strict';
app.service('publicProfileService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Profile/';

    this.getPublicProfile = function (jugadorId) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetPublicProfile?jugadorId=' + jugadorId).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

}]);