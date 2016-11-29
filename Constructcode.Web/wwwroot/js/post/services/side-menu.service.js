(function () {
    'use strict';

    angular.module('app')
        .service('sideMenuService', sideMenuService);

    function sideMenuService(categoryService, ngDialog) {
        var service = this;

        service.categories = [];

        init();
        function init() {
            getAllCategories();
        }

        service.createCategory = function () {
            var categoryName = window.prompt('Insert category name', '');

            if ($.trim(categoryName) === '')
                return;

            var category = { title: categoryName };

            categoryService.createCategory(category).then(function (response) {
                insertSideMenuCategory(response.data);
            });
        }

        service.uploadImage = function () {
            ngDialog.open(
                {
                    template: '/templates/upload-image.template.html',
                    className: 'ngdialog-theme-default',
                    controller: 'UploadImageController as vm'
                });
        }

        service.editCategory = function(category) {
            var categoryName = window.prompt('Insert category name', '');

            if ($.trim(categoryName) === '')
                return;

            categoryService.editCategory({title: categoryName, id: category.id}).then(function() {
                category.title = categoryName;
            });
        }

        service.deleteCategory = function(category) {          
            categoryService.deleteCategory(category.id).then(function () {
                service.categories = service.categories.filter(item => item !== category);
            });
        }

        function getAllCategories() {
            categoryService.getAllCategories().then(function (response) {
                setupSideMenuCategory(response.data);
            });
        }

        function setupSideMenuCategory(categories) {
            angular.forEach(categories, function (category) {
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