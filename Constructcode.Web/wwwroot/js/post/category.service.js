(function () {
    'use strict';

    angular.module('app')
        .service('categoryService', categoryService);

    function categoryService($http, apiConfigService) {
        var service = this;

        var serviceRoute = apiConfigService.getDefaultApiRoute + 'category/';

        service.createCategory = function(category) {
            return $http.post(serviceRoute + 'create', category);
        }

        service.getAllCategories = function (category) {
            return $http.get(serviceRoute + 'getAll');
        }

        return service;
    }
})();