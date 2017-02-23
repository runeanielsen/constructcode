(function () {
    'use strict';

    angular.module('app')
        .controller('IntroductionDialogController', IntroductionDialogController);

    IntroductionDialogController.$inject = ['$scope'];
    function IntroductionDialogController($scope) {
        var vm = this;

        init();
        function init() {
            setIntroduction();
        }

        vm.save = function () {
            $scope.closeThisDialog(vm.introduction);
        }

        function setIntroduction() {
            if ($scope.ngDialogData.introduction !== '$document')
                vm.introduction = $scope.ngDialogData.introduction;
        }
    }
})();