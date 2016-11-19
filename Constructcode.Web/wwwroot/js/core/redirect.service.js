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
            var url = '/admin';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        service.createPost = function (shouldRedirect) {
            var url = '/admin/post/createPost';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        service.editPost = function (id, shouldRedirect) {
            var url = '/admin/post/editPost/' + id;

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        service.manageUsers = function (shouldRedirect) {
            var url = '/admin/manageUsers';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        }

        service.displayPost = function (urlParameter, shouldRedirect) {
            var url = '/post/' + urlParameter;

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