(function () {
    'use strict';

    angular.module('app')
        .controller('EditPostController', EditPostController);

    function EditPostController(postService, categoryService, urlService) {
        var vm = this;

        vm.post = {};
        vm.categories = {};

        init();
        function init() {
            retrievePost();
            getAllCategories();
        }

        function retrievePost() {
            vm.postId = urlService.getLastUrlParameter();
            postService.getPostOnId(vm.postId).then(function (response) {
                vm.post = response.data;
            });
        }      

        function getAllCategories() {
            categoryService.getAllCategories().then(function (response) {
                vm.categories = response.data;
            });
        }
    }
})();