(function() {
    'use strict';

    angular.module('app')
        .controller('DisplayPostController', DisplayPostController);

    DisplayPostController.$inject = ['redirectService'];
    function DisplayPostController(redirectService) {
        var vm = this;

        vm.redirect = redirectService;

        init();
        function init() {
            Prism.highlightAll();
        }
    }
})();