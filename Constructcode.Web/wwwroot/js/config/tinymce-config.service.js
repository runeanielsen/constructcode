(function() {
    'use strict';

    angular.module('app').service('tinymceConfigService', tinymceConfigService);

    function tinymceConfigService() {
        var service = this;

        service.tinymceOptions = {
            inline: false,
            plugins: 'advlist autolink link image lists charmap print preview autoresize imagetools',
            skin: 'lightgray',
            theme: 'modern',
            autoresize_max_height: 600
        };

        return service;
    }
})();