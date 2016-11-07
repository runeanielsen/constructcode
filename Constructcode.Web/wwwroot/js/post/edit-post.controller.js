(function () {
    'use strict';

    angular.module('app')
        .controller('EditPostController', EditPostController);

    function EditPostController(postService, categoryService, urlService, sideMenuService) {
        var vm = this;

        vm.post = {};
        vm.categories = {};
        vm.sideMenu = sideMenuService;

        init();
        function init() {
            retrievePost();
        }

        function retrievePost() {
            vm.postId = urlService.getLastUrlParameter();
            postService.getPostOnId(vm.postId).then(function (response) {
                vm.post = response.data;
            });
        }      
    }
})();