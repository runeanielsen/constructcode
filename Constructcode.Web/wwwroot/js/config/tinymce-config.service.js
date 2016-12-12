(function() {
    'use strict';

    angular.module('app').service('tinymceConfigService', tinymceConfigService);

    function tinymceConfigService() {
        var service = this;

        service.tinymceOptions = {
            inline: false,
            plugins: 'advlist autolink lists link image charmap preview hr anchor pagebreak searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking save table contextmenu directionality template paste textcolor colorpicker textpattern imagetools codesample toc',
            toolbar1: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent',
            toolbar2: 'link image preview media | forecolor backcolor | codesample',
            image_advtab: true,
            height: 'calc(100vh - 275px)'
        };

        return service;
    }
})();