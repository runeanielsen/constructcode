(function () {
    'use strict';

    angular.module('app')
        .directive('textEditor', textEditor);

    function textEditor() {
        var link = function (scope) {
            var vm = scope;

            vm.insertBoldText = function () {
                scope.content = "Hello World!";
            }
        }

        return {
            scope: {
                content: '=ngModel'
            },
            templateUrl: '/templates/text-editor.template.html',
            link: link
        }
    }
})();