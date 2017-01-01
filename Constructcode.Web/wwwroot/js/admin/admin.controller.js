(function () {
    'use strict';

    angular.module('app')
        .controller('AdminController', AdminController);

    AdminController.$inject = ['redirectService', 'postService'];
    function AdminController(redirectService, postService) {
        var vm = this;

        vm.posts = [];
        vm.redirect = redirectService;

        init();
        function init() {
            postService.getAllPosts().then(function(response) {
                vm.posts = response.data;
            });
        }
    }
})();
