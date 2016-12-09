(function () {
    'use strict';

    angular
        .module('app')
        .directive('sideMenu', sideMenu)
        .controller('ExampleController', ExampleController);

    function sideMenu() {
        var directive = {
            restrict: 'EA',
            templateUrl: '/js/post/directives/side-menu.template.html',
            scope: {
                max: '='
            },
            controllerAs: 'vm',
            controller: ExampleController,
            bindToController: true
        };

        return directive;
    }

    function ExampleController($timeout) {
        var vm = this;


        vm.min = 3;

    }
})();