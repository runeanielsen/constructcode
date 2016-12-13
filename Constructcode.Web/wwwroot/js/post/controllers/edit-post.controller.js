﻿(function () {
    'use strict';

    angular.module('app')
        .controller('EditPostController', EditPostController);

    EditPostController.$inject = ['postService', 'urlService', 'redirectService', 'tinymceConfigService'];
    function EditPostController(postService, urlService, redirectService, tinymceConfigService) {
        var vm = this;

        vm.post = null;
        vm.tinymceOptions = tinymceConfigService.tinymceOptions;

        init();
        function init() {
            retrievePost();
        }

        vm.savePost = function () {
            postService.updatePost(vm.post).then(function () {
                redirectService.admin(true);
            }, function (response) {
                alert(response.data);
            });
        }

        vm.deletePost = function () {
            postService.deletePost(vm.post.id).then(function () {
                redirectService.admin(true);
            });
        }

        function retrievePost() {
            postService.getPostOnId(urlService.getLastUrlParameter()).then(function (response) {
                vm.post = response.data;
            });
        }
    }
})();