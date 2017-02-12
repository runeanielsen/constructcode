(function () {
    'use strict';

    angular.module('managePosts')
        .controller('EditPostController', EditPostController);

    EditPostController.$inject = ['postService', 'urlService', 'redirectService', 'tinymceConfigService'];
    function EditPostController(postService, urlService, redirectService, tinymceConfigService) {
        var vm = this;

        vm.post = null;
        vm.isLoading = false;
        vm.tinymceOptions = tinymceConfigService.tinymceOptions;

        init();
        function init() {
            retrievePost();
        }

        vm.savePost = function () {
            toggleLoading();
            postService.updatePost(vm.post).then(function () {
                toggleLoading();
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

        function toggleLoading() {
            vm.isLoading = !vm.isLoading;
        }
    }
})();