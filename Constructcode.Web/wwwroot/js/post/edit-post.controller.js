(function () {
    'use strict';

    angular.module('app')
        .controller('EditPostController', EditPostController);

    function EditPostController(postService) {
        var vm = this;

        vm.postId = '';
        vm.post = {};

        init();
        function init() {
            postService.getPostOnId(vm.PostId).then(function(response) {
                vm.post = response.data;
            })();
        }
    }
})();