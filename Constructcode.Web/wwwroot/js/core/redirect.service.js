(function () {
    'use strict';

    angular.module('app')
        .service('redirectService', redirectService);

    function redirectService() {
        var service = this;

        service.homePage = '/';
        service.adminPage = '/Admin';

        return service;
    }
})();