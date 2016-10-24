(function () {
    angular.module("app")
        .controller("CreatePostController", CreatePostController);

    function CreatePostController(postService) {
        var vm = this;

        vm.post = {
            title: "",
            content: ""
        }

        vm.createPost = function() {
            postService.createPost(vm.post);
        }
    }
})();