﻿(function () {
    'use strict';

    angular.module('app')
        .service('categoryService', categoryService);

    categoryService.$inject = ['$http', 'apiConfigService'];
    function categoryService($http, apiConfigService) {
        var service = this;

        var serviceRoute = apiConfigService.getDefaultApiRoute + 'category/';

        service.createCategory = function(category) {
            return $http.post(serviceRoute + 'create', category);
        }

        service.getAllCategories = function () {
            return $http.get(serviceRoute + 'getAll');
        }

        service.editCategory = function (category) {
            return $http.post(serviceRoute + 'edit', category);
        }

        service.deleteCategory = function (categoryId) {
            return $http.delete(serviceRoute + 'delete/' + categoryId);
        }

        return service;
    }
})();