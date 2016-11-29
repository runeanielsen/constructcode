(function () {
    'use strict';

    angular.module('app')
        .controller('PostOnCategoryController', PostOnCategoryController);

    function PostOnCategoryController(postService, redirectService, urlService) {
        var vm = this;

        vm.posts = [];
        vm.redirect = redirectService;

        init();
        function init() {
            postService.getAllPostsOnCategory(urlService.getLastUrlParameter()).then(function (response) {
                vm.posts = response.data;
            });
        }
    }
})();