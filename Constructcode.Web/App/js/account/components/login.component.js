(function () {
    'use strict';

    angular.module('app')
        .component('login', loginComponent());

    function loginComponent() {
        return {
            templateUrl: '/js/account/components/login.template.html',
            controllerAs: 'vm',
            controller: ['redirectService', 'accountService', loginController]
        };

        function loginController(redirectService, accountService) {
            var vm = this;

            vm.redirect = redirectService;

            vm.errorText = '';
            vm.loginInformation = {
                username: '',
                password: ''
            };

            vm.submitLogin = function () {
                accountService.submitLogin(vm.loginInformation).then(function () {
                    redirectService.admin(true);
                }, function (response) {
                    vm.errorText = response.data;
                });
            };
        }
    }
})();