(function () {
    'use strict';

    angular.module('app')
        .directive('fileInput', fileInput);

    function fileInput() {
        return {
            link: function($scope, el) {
                el.bind('change',
                    function(e) {
                        $scope.file = (e.srcElement || e.target).files[0];
                    });
            }
        }
    }
})();