(function () {
    'use strict';

    angular.module('app')
        .controller('CreatePostController', CreatePostController);

    function CreatePostController(postService, redirectService, tinymceConfigService) {
        var vm = this;

        vm.tinymceOptions = tinymceConfigService.tinymceOptions;

        vm.post = {
            title: '',
            content: '',
            postCategories: []
        }

        vm.createPost = function () {
            postService.createPost(vm.post).then(function() {
                redirectService.admin(true);
            }, function(response) {
                alert(response.data);
            });
        }
    }
})();