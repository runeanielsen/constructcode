(function () {
    'use strict';

    angular.module('app')
        .component('createPost', createPostComponent());

    function createPostComponent() {
        return {
            templateUrl: '/templates/create-post.template.html',
            controllerAs: 'vm',
            controller: ['postService', 'redirectService', 'tinymceConfigService', CreatePostController]
        }

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
                postService.createPost(vm.post).then(function () {
                    redirectService.admin(true);
                }, function (response) {
                    alert(response.data);
                });
            }
        }
    }
})();