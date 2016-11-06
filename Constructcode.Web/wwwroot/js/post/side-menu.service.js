(function () {
    'use strict';

    angular.module('app').service('sideMenuService', sideMenuService);

    function sideMenuService(categoryService) {
        var service = this;

        service.categories = {};

        init();
        function init() {
            getAllCategories();
        }

        service.createCategory = function() {
            var categoryName = window.prompt('Insert category name', '');

            if ($.trim(categoryName) === '')
                return;

            var category = { title: categoryName };

            categoryService.createCategory(category).then(function () {
                getAllCategories();
            });
        }

        function getAllCategories() {
            categoryService.getAllCategories().then(function (response) {
                service.categories = response.data;
            });
        }
    }
})();