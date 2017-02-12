(function () {
    "use strict";

    angular.module('app')
        .directive('loading', loadingDirective);

    function loadingDirective() {
        return {
            scope: {
                loading: '='
            },
            template: '<div ng-show="loading" class="loading"><i class="fa fa-circle-o-notch fa-spin spin-normal"></i></div>',
        }
    }
})();