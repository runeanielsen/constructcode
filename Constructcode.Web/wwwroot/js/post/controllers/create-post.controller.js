(function () {
    'use strict';

    angular.module('app')
        .controller('CreatePostController', CreatePostController);

    function CreatePostController(postService, categoryService, sideMenuService, redirectService, tinymceConfigService) {
        var vm = this;

        vm.sideMenu = sideMenuService;
        vm.tinymceOptions = tinymceConfigService.tinymceOptions;

        vm.post = {
            title: '',
            content: '',
            postCategories: []
        }

        vm.createPost = function () {
            insertSelectedCategoriesOnPost();
            postService.createPost(vm.post).then(function() {
                redirectService.admin(true);
            }, function(response) {
                alert(response.data);
            });

        }

        function insertSelectedCategoriesOnPost() {
            createPostCategories(vm.sideMenu.categories.filter(c => c.selected));
        }

        function createPostCategories(selectedCategories) {
            $.each(selectedCategories, function(index, category) {
                vm.post.postCategories.push({ categoryId: category.id });
            });
        }
    }
})();