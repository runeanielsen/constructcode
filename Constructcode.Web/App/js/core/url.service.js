(function () {
    'use strict';

    angular.module('app')
        .service('urlService', urlService);

    function urlService() {
        var service = this;
        
        service.getLastUrlParameter = function() {
            return window.location.href.substr(window.location.href.lastIndexOf('/') + 1);
        }

        return service;
    }
})();