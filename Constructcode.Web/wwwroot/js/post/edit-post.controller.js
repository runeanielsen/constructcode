(function () {
    'use strict';

    angular.module('app')
        .controller('EditPostController', EditPostController);

    function EditPostController(postService, categoryService, urlService, sideMenuService) {
        var vm = this;

        vm.post = {};
        vm.sideMenu = sideMenuService;

        init();
        function init() {
            retrievePost();
        }

        function retrievePost() {
            postService.getPostOnId(urlService.getLastUrlParameter()).then(function (response) {
                vm.post = response.data;
                mapSelectedCategories();
            });
        }      

        function mapSelectedCategories() {
            angular.forEach(vm.sideMenu.categories, function(sideMenuCategory) {
                if (vm.post.postCategories.filter(pc => pc.categoryId === sideMenuCategory.id).length > 0) {
                    sideMenuCategory.selected = true;
                }
            });
        }
    }
})();