(function () {
    'use strict';

    angular.module('app').controller('AdminController', AdminController);

    function AdminController(redirectService, postService) {
        var vm = this;

        vm.posts = [];
        vm.redirect = redirectService;

        function init() {
            postService.getAllPosts().then(function(response) {
                vm.posts = response.data;
            });
        }

        init();
    }
})();