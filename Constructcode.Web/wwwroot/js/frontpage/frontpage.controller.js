﻿(function () {
    'use strict';

    angular.module('app')
        .controller('FrontPageController', FrontPageController);

    FrontPageController.$inject = ['postService', 'redirectService'];
    function FrontPageController(postService, redirectService) {
        var vm = this;

        vm.posts = [];
        vm.redirect = redirectService;

        init();
        function init() {
            postService.getAllPublishedPosts().then(function (response) {
                vm.posts = response.data;
            });
        }
    }
})();