(function() {
    'use strict';

    angular.module('app')
        .controller('DisplayPostController', DisplayPostController);

    DisplayPostController.$inject = ['$sce', 'urlService', 'redirectService', 'postService'];
    function DisplayPostController($sce, urlService, redirectService , postService) {
        var vm = this;

        vm.post = {};
        vm.redirect = redirectService;

        init();
        function init() {
            postService.getPostOnUrl(urlService.getLastUrlParameter()).then(function (response) {
                vm.post = response.data;            
            });
        }

        vm.trustAsHtml = function () {
            Prism.highlightAll();
            return $sce.trustAsHtml(vm.post.content);
        };
    }
})();