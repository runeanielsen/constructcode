(function () {
    'use strict';

    angular.module('app')
        .controller('CreatePostController', CreatePostController);

    function CreatePostController(postService, categoryService, sideMenuService) {
        var vm = this;

        vm.sideMenu = sideMenuService;

        vm.post = {
            title: '',
            content: '',
            categories: []
        }

        vm.createPost = function () {
            insertSelectedCategoriesOnPost();
            console.log(vm.post);
            postService.createPost(vm.post).then(function() {

            });
        }

        function insertSelectedCategoriesOnPost() {
            vm.post.categories = vm.sideMenu.categories.filter(c => c.selected);
        }
    }
})();