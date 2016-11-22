﻿(function () {
    'use strict';

    angular.module('app')
        .service('sideMenuService', sideMenuService);

    function sideMenuService(categoryService) {
        var service = this;

        service.categories = [];

        init();
        function init() {
            getAllCategories();
        }

        service.createCategory = function() {
            var categoryName = window.prompt('Insert category name', '');

            if ($.trim(categoryName) === '')
                return;

            var category = { title: categoryName };

            categoryService.createCategory(category).then(function (response) {
                insertSideMenuCategory(response.data);
            });
        }

        service.uploadImage = function() {
            var x = document.createElement('input');
            x.setAttribute('type', 'file');
            x.setAttribute('ng-change', 'vm.service.readUrl(this)');
            x.click();
        }




        function getAllCategories() {
            categoryService.getAllCategories().then(function (response) {
                setupSideMenuCategory(response.data);
            });
        }

        function setupSideMenuCategory(categories) {
            angular.forEach(categories, function(category) {
                insertSideMenuCategory(category);
            });
        }

        function insertSideMenuCategory(category) {
            service.categories.push({
                title: category.title,
                id: category.id,
                selected: false
            });
        }
    }
})();