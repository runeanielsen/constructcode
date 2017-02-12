(function () {
    'use strict';

    angular.module('app')
        .component('adminSideMenu', adminSideMenu());

    function adminSideMenu() {
        return {
            templateUrl: '/js/admin/components/admin-side-menu.template.html',
            controllerAs: 'vm',
            controller: ['redirectService', 'accountService', adminSideMenuController]
        };

        function adminSideMenuController(redirectService, accountService) {
            var vm = this;

            vm.redirect = redirectService;

            vm.submitLogin = function () {
                accountService.logout().then(function () {
                    redirectService.home(true);
                });
            };
        }
    }
})();