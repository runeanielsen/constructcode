(function () {
    'use strict';

    angular.module('app')
        .component('sideMenu', sideMenuComponent())

    function sideMenuComponent() {
        return {
            bindings: {
                post: '='
            },
            templateUrl: '/js/post/components/side-menu.template.html',
            controllerAs: 'vm',
            controller: sideMenuController
        }

        function sideMenuController() {
            var vm = this;
        }
    }
})();