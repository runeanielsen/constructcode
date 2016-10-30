(function () {
    'use strict';

    angular.module('app')
        .service('categoryService', categoryService);

    function categoryService($http, apiConfigService) {
        var service = this;

        var serviceRoute = apiConfigService.getDefaultApiRoute + 'category/';

        service.createCategory = function() {
            return $http.post(serviceRoute + 'createPost/');
        }

        return service;
    }
})();