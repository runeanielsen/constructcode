(function () {
    'use strict';

    angular.module('app')
        .service('redirectService', redirectService);

    function redirectService() {
        var service = this;

        service.homePage = function() {
            window.location.href = '/';
        }

        service.adminPage = function() {
            window.location.href = '/Admin';
        }

        return service;
    }
})();