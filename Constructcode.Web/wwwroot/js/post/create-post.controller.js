(function () {
    angular.module('app')
        .controller('CreatePostController', CreatePostController);

    function CreatePostController(postService, categoryService) {
        var vm = this;

        vm.categories = {};
        vm.post = {
            title: '',
            content: ''
        }

        function init() {
            categoryService.getAllCategories().then(function (response) {
                vm.categories = response.data;
            });
        }

        vm.createPost = function () {
            postService.createPost(vm.post);
        }

        vm.createCategory = function () {
            var categoryName = window.prompt('Insert category name', '');

            if ($.trim(categoryName) === '')
                return;

            var category = { title: categoryName };

            categoryService.createCategory(category).then(function () {

            });
        }

        init();
    }
})();