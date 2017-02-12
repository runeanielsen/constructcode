(function() {
    'use strict';

    angular.module('app')
        .service('apiConfigService', apiConfigService);

    function apiConfigService() {
        var service = this;

        service.getDefaultApiRoute = '/api/';

        return service;
    }
})();