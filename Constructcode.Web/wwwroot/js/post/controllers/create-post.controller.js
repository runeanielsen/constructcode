(function () {
    'use strict';

    angular.module('app')
        .controller('CreatePostController', CreatePostController);

    CreatePostController.$inject = ['postService', 'redirectService', 'tinymceConfigService'];
    function CreatePostController(postService, redirectService, tinymceConfigService) {
        var vm = this;

        vm.tinymceOptions = tinymceConfigService.tinymceOptions;

        vm.post = {
            title: '',
            content: '',
            postCategories: [],
            
        }

        vm.setDefaultDate = function() {
            vm.post.created = "17 September 2016"
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