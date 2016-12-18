(function () {
    'use strict';

    angular.module('app')
        .service('accountService', accountService);

    accountService.$inject = ['$http', 'apiConfigService'];
    function accountService($http, apiConfigService) {
        var service = this;

        var serviceRoute = apiConfigService.getDefaultApiRoute + 'account/';

        service.submitLogin = function (loginInformation) {
            return $http.post(serviceRoute + 'login', loginInformation);
        }

        service.logout = function (loginInformation) {
            return $http.get(serviceRoute + 'logout');
        }

        service.getAccountName = function () {
            return $http.get(serviceRoute + 'getAccountName')
        }
    }
})();