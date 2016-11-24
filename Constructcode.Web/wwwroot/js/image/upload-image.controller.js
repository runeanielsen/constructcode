(function () {
    'use strict';

    angular.module('app')
        .controller('UploadImageController', UploadImageController);

    function UploadImageController(imageService, $scope) {
        var vm = this;

        vm.uploadImage = function () {
            var formData = new FormData();
            formData.append('file', $scope.file);
            imageService.uploadImage(formData);
        }
    }
})();