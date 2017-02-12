(function () {
    'use strict';

    angular.module('app')
        .directive('fileInput', fileInput);

    function fileInput() {
        return {
            scope: {
                file: '=fileInput'
            },
            link: function (scope, element) {
                element.bind('change',
                    function(e) {
                        scope.file = (e.srcElement || e.target).files[0];
                        scope.$apply();
                    });
            }
        }
    }
})();