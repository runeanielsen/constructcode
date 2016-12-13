(function () {
    'use strict';

    angular.module('app')
        .component('sideMenu', sideMenuComponent())

    function sideMenuComponent() {
        return {
            bindings: {
                post: '='
            },
            templateUrl: '/js/post/components/side-menu.template.html',
            controllerAs: 'vm',
            controller: sideMenuController
        }

        sideMenuController.$inject = ['categoryService', 'ngDialog', 'redirectService'];
        function sideMenuController(categoryService, ngDialog, redirectService) {
            var vm = this;

            vm.categories = [];
            vm.post = {};

            vm.redirect = redirectService;

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

            vm.updatePostCategories = function () {
                vm.post.postCategories = [];
                angular.forEach(vm.categories.filter(c => c.selected), function (selectedCategory) {
                    vm.post.postCategories.push({ postId: vm.post.id, categoryId: selectedCategory.id });
                });              
            }

            function initSelectedCategories(){
                angular.forEach(vm.post.postCategories, function (postCategory) {
                    vm.categories.filter(c => c.id === postCategory.categoryId)[0].selected = true;
                });
            }

            function getAllCategories() {
                categoryService.getAllCategories().then(function (response) {
                    vm.categories = response.data;
                    initSelectedCategories();
                });
            }
        }
    }
})();