(function () {
    'use strict';

    angular.module('app')
        .component('sideMenu', sideMenuComponent())

    function sideMenuComponent() {
        return {
            bindings: {
                post: '=',
                categories: '='
            },
            templateUrl: '/js/post/components/side-menu.template.html',
            controllerAs: 'vm',
            controller: sideMenuController
        }

        function sideMenuController(categoryService) {
            var vm = this;

            vm.categories = [];

            init();
            function init() {
                getAllCategories();
            };

            vm.createCategory = function () {
                var categoryName = window.prompt('Insert category name', '');

                if ($.trim(categoryName) === '')
                    return;

                var category = { title: categoryName };

                categoryService.createCategory(category).then(function (response) {
                    vm.categories.push(response.data);
                }, function (response) {
                    alert(response.data);
                });
            }

            vm.uploadImage = function () {
                ngDialog.open(
                    {
                        template: '/templates/upload-image.template.html',
                        className: 'ngdialog-theme-default',
                        controller: 'UploadImageController as vm'
                    });
            }

            vm.editCategory = function (category) {
                var categoryName = window.prompt('Insert category name', '');

                if ($.trim(categoryName) === '')
                    return;

                categoryService.editCategory({ title: categoryName, id: category.id }).then(function () {
                    category.title = categoryName;
                }, function (response) {
                    alert(response.data);
                });
            }

            vm.deleteCategory = function (category) {
                categoryService.deleteCategory(category.id).then(function () {
                    vm.categories = vm.categories.filter(item => item !== category);
                });
            }

            function getAllCategories() {
                categoryService.getAllCategories().then(function (response) {
                    vm.categories = response.data;
                });
            }
        }
    }
})();