(function () {
    'use strict';

    angular.module('app')
        .controller('UploadImageController', UploadImageController);

    function UploadImageController(imageService) {
        var vm = this;

        vm.uploadedImagePath = '';

        vm.uploadImage = function () {
            var formData = new FormData();
            formData.append('file', vm.file);

            imageService.uploadImage(formData).then(function(response) {
                vm.uploadedImagePath = response.data;
            });
        }
    }
})();