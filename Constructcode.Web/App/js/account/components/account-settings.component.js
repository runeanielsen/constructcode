(function () {
    'use strict';

    angular.module('app')
        .component('accountSettings', accountSettingsComponent())

    function accountSettingsComponent() {
        return {
            templateUrl: '/templates/account-settings.template.html',
            controllerAs: 'vm',
            controller: ['redirectService', 'accountService', accountSettingsController]
        }

        function accountSettingsController(redirectService, accountService) {
            var vm = this;

            vm.settings = {
                password: '',
                repeatedPassword: ''
            }

            vm.save = function () {
                accountService.updateAccount(vm.settings).then(function (response) {
                    alert(response.data);
                    resetFields();
                }, function (response) {
                    alert(response.data);
                });
            }

            function resetFields() {
                vm.settings.password = '';
                vm.settings.repeatedPassword = '';
            }
        }
    }
})();