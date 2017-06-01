(function () {
    'use strict';

    angular.module('app')
        .component('adminSideMenu', adminSideMenu());

    function adminSideMenu() {
        return {
            templateUrl: '/templates/admin-side-menu.template.html',
            controllerAs: 'vm',
            controller: ['redirectService', 'accountService', adminSideMenuController]
        };

        function adminSideMenuController(redirectService, accountService) {
            var vm = this;

            vm.redirect = redirectService;

            vm.logout = function () {
                accountService.logout().then(() => {
                    redirectService.home(true);
                });
            };
        }
    }
})();