(function() {
    'use strict';

    angular.module('app').service('tinymceConfigService', tinymceConfigService);

    function tinymceConfigService() {
        var service = this;

        service.tinymceOptions = {
            inline: false,
            plugins: 'advlist autolink lists link image charmap preview hr anchor pagebreak searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking save table contextmenu directionality emoticons template paste textcolor colorpicker textpattern imagetools codesample toc',
            toolbar1: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
            toolbar2: 'preview media | forecolor backcolor emoticons | codesample',
            image_advtab: true,
            skin: 'lightgray',
            theme: 'modern',
            autoresize_max_height: 600
        };

        return service;
    }
})();