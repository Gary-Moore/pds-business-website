(function () {
    "use strict";

    angular.module("app.business").service("businessService", businessService);

    businessService.$inject = ['$http', '$q'];

    function businessService($http, $q) {        

        var service = {
            get: get
        };

        return service;

        function get(searchParams) {
            var url = '/api/business';

            var deferred = $q.defer();

            $http({
                url: url,
                method: "GET",
                params: searchParams
            }).then(function (result) {
                 deferred.resolve(result.data);
            }, function (error) {
                showError(error.status);
                deferred.reject(error);
            });

            return deferred.promise;
        }
    }
})();
