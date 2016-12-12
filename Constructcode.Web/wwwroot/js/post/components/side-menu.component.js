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

            function getAllCategories() {
                categoryService.getAllCategories().then(function (response) {
                    vm.categories = response.data;
                });
            }
        }
    }
})();