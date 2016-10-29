(function () {
    'use strict';

    angular.module('app')
        .controller('EditPostController', EditPostController);

    function EditPostController(postService, urlService) {
        var vm = this;

        vm.post = {};

        function init() {
            vm.postId = urlService.getLastUrlParameter();

            postService.getPostOnId(vm.postId).then(function (response) {
                vm.post = response.data;
            });
        }

        init();
    }
})();