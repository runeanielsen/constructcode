(function () {
    angular.module('app').controller('AdminController', AdminController);

    function AdminController(postService) {
        var vm = this;

        vm.posts = [];

        function init() {
            postService.getAllPosts().then(function(response) {
                vm.posts = response.data;
            });
        }

        init();
    }
})();