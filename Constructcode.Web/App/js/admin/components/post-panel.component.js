(function () {
    'use strict';

    angular.module('app')
        .component('postPanel', postPanel());

    function postPanel() {
        return {
            templateUrl: '/templates/post-panel.template.html',
            controllerAs: 'vm',
            controller: ['redirectService', 'postService', postPanelController]
        };

        function postPanelController(redirectService, postService) {
            var vm = this;

            vm.posts = [];
            vm.redirect = redirectService;

            init();
            function init() {
                postService.getAllPosts().then(function (response) {
                    vm.posts = response.data;
                });
            }
        }
    }
})();