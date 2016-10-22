(function() {
    angular.module("app")
        .controller("CreatePostController", CreatePostController);

    function CreatePostController() {
        var vm = this;

        vm.DisplayText = "Hello World!";

    }
})();