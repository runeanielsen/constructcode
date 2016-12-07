(function () {
    'use strict';

    angular
        .module('app')
        .directive('myExample', myExample)
        .controller('ExampleController', ExampleController);

    function myExample() {
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