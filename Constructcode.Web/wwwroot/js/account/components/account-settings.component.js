(function () {
    'use strict';

    angular.module('app')
        .component('accountSettings', accountSettingsComponent())

    function accountSettingsComponent() {
        return {
            templateUrl: '/js/account/components/account-settings.template.html',
            controllerAs: 'vm',
            controller: ['redirectService', 'accountService', accountSettingsController]
        }

        function accountSettingsController(redirectService, accountService) {
            var vm = this;

            vm.settings = {
                username: '',
                password: '',
                repeatedPassword: '',
            }

            init();
            function init() {
                accountService.getUsername().then(function (response) {
                    vm.settings.username = response.data;
                });
            }

            vm.save = function() {
            
            }
        }
    }
})();