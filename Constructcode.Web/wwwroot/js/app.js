(function () {
    'use strict';

    angular.module('app', ['ngSanitize']);

    angular.module('managePosts', ['app', 'ngSanitize', 'ngDialog', 'ui.tinymce', 'pikaday']);
})();