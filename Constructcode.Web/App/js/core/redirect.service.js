﻿(function () {
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
        };

        service.admin = function (shouldRedirect) {
            var url = '/admin';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        };

        service.createPost = function (shouldRedirect) {
            var url = '/admin/post/createpost';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        };

        service.editPost = function (id, shouldRedirect) {
            var url = '/admin/post/editpost/' + id;

            if (!shouldRedirect)
                return url;

            return redirect(url);
        };

        service.previewPost = function (id, shouldRedirect) {
            var url = '/post/preview/' + id;

            if (!shouldRedirect)
                return url;

            return redirect(url);
        };

        service.manageAccount = function (shouldRedirect) {
            var url = '/admin/account/manage';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        };

        service.displayPost = function (urlParameter, shouldRedirect) {
            var url = '/post/' + urlParameter;

            if (!shouldRedirect)
                return url;

            return redirect(url);
        };

        service.displayPostOnCategory = function (urlParameter, shouldRedirect) {
            var url = '/post/category/' + urlParameter.toLowerCase();

            if (!shouldRedirect)
                return url;

            return redirect(url);
        };

        service.accountSettings = function (shouldRedirect) {
            var url = '/admin/account/settings/';

            if (!shouldRedirect)
                return url;

            return redirect(url);
        };

        function redirect(url) {
            window.location.href = url;
        }

        return service;
    }
})();