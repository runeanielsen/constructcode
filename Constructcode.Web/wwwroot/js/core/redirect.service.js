(function () {
    'use strict';

    angular.module('app')
        .service('redirectService', redirectService);

    function redirectService() {
        var service = this;

        service.home = function (shouldRedirect) {
            var url = '/';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        service.admin = function (shouldRedirect) {
            var url = '/Admin';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        service.createPost = function (shouldRedirect) {
            var url = '/Admin/Post/CreatePost';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        service.editPost = function (id, shouldRedirect) {
            var url = '/Admin/Post/EditPost/' + id;

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        service.manageUsers= function (shouldRedirect) {
            var url = '/Admin/ManageUsers';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        function redirect(url) {
            window.location.href = url;
        }

        return service;
    }
})();