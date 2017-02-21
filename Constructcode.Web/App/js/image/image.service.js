(function () {
    'use strict';

    angular.module('app')
        .service('imageService', imageService);

    imageService.$inject = ['$http', 'apiConfigService'];
    function imageService($http, apiConfigService) {
        var service = this;

        var serviceRoute = apiConfigService.getDefaultApiRoute + 'post/';

        service.uploadImage = function (imageFile) {
            return $http({
                method: 'POST',
                url: serviceRoute + 'UploadPostImage',
                data: imageFile,
                headers: { 'Content-Type': undefined }
            });
        }

        return service;
    }
})();