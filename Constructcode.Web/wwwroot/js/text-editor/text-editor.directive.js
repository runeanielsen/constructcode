(function () {
    'use strict';

    angular.module('app')
        .directive('textEditor', textEditor);

    function textEditor($sce) {
        var link = function (scope) {
            var vm = scope;

            scope.$watch('content', function () {
                console.log('i was here!');
            });

            vm.insertBoldText = function () {
                vm.content = '<h3>Hello World!</h3>';
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