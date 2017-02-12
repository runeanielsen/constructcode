(function () {
    'use strict';

    angular.module('managePosts')
        .controller('CreatePostController', CreatePostController);

    CreatePostController.$inject = ['postService', 'redirectService', 'tinymceConfigService'];
    function CreatePostController(postService, redirectService, tinymceConfigService) {
        var vm = this;

        vm.tinymceOptions = tinymceConfigService.tinymceOptions;

        vm.post = {
            title: '',
            content: '',
            postCategories: [],
            created: moment(new Date()).format('DD MMMM YYYY')
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