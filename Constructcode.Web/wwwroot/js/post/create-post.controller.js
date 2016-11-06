(function () {
    'use strict';

    angular.module('app')
        .controller('CreatePostController', CreatePostController);

    function CreatePostController(postService, categoryService, sideMenuService) {
        var vm = this;

        vm.sideMenu = sideMenuService;
        vm.categories = vm.sideMenu.categories;

        vm.post = {
            title: '',
            content: ''
        }

        vm.createPost = function () {
            postService.createPost(vm.post);
        }
    }
})();