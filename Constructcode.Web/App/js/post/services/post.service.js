﻿(function () {
    'use strict';

    angular.module('app')
        .service('postService', postService);

    postService.$inject = ['$http', 'apiConfigService'];
    function postService($http, apiConfigService) {
        var service = this;

        var serviceRoute = apiConfigService.getDefaultApiRoute + 'post/';

        service.getAllPosts = function () {
            return $http.get(serviceRoute + 'getAllPosts');
        }

        service.getAllPublishedPosts = function () {
            return $http.get(serviceRoute + 'getAllPublishedPosts');
        }

        service.getAllPostsOnCategory = function (categoryName) {
            return $http.get(serviceRoute + 'getAllPostsOnCategory/' + categoryName);
        }

        service.getPostOnId = function (id) {
            return $http.get(serviceRoute + 'getPost/' + id);
        }

        service.getPostOnUrl = function (url) {
            return $http.get(serviceRoute + 'getPostOnUrl/' + url);
        }

        service.deletePost = function (id) {
            return $http.delete(serviceRoute + 'deletePost/' + id);
        }

        service.createPost = function(post) {
            return $http.post(serviceRoute + 'createPost', post);
        }

        service.updatePost = function (post) {
            return $http.post(serviceRoute + 'updatePost', post);
        }

        return service;
    }
})();