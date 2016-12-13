(function () {
    'use strict';

    angular.module('app')
        .controller('PostOnCategoryController', PostOnCategoryController);

    PostOnCategoryController.$inject = ['postService', 'redirectService', 'urlService'];
    function PostOnCategoryController(postService, redirectService, urlService) {
        var vm = this;

        vm.posts = [];
        vm.redirect = redirectService;

        init();
        function init() {
            var lastUrlParameter = urlService.getLastUrlParameter();

            postService.getAllPostsOnCategory(lastUrlParameter).then(function (response) {
                vm.posts = response.data;
            });
        }
    }
})();