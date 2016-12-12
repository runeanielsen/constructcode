(function () {
    'use strict';

    angular.module('app').component('sideMenu', {
        bindings: {
            post: '='
        },
        templateUrl: '/js/post/components/side-menu.template.html',
        controllerAs: 'vm',

        controller: function () {
            var vm = this;

        }
    });
})();