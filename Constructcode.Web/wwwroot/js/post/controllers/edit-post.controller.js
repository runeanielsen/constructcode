(function () {
    'use strict';

    angular.module('app')
        .controller('EditPostController', EditPostController);

    function EditPostController(postService, categoryService, urlService, sideMenuService, redirectService, tinymceConfigService) {
        var vm = this;

        vm.post = {};
        vm.sideMenu = sideMenuService;
        vm.tinymceOptions = tinymceConfigService.tinymceOptions;

        init();
        function init() {
            retrievePost();
        }

        vm.savePost = function() {
            insertSelectedCategoriesOnPost();
            postService.updatePost(vm.post).then(function() {
                redirectService.admin(true);
            });
        }

        vm.deletePost = function() {
            postService.deletePost(vm.post.id).then(function () {
                redirectService.admin(true);
            });
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

        function insertSelectedCategoriesOnPost() {
            vm.post.postCategories = [];
            updatePostCategories(vm.sideMenu.categories.filter(c => c.selected));
        }

        function updatePostCategories(selectedCategories) {
            $.each(selectedCategories, function (index, category) {
                vm.post.postCategories.push({ categoryId: category.id, postId: vm.post.id});
            });
        }
    }
})();