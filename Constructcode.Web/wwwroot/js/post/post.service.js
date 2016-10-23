(function () {
    angular.module("app")
        .service("postService", postService);

    function postService($http, apiConfigService) {
        var service = this;

        var serviceRoute = apiConfigService.defaultApiRoute + "post/";

        service.getAllPosts = function () {
            return $http.get(serviceRoute + "getAllPosts");
        }

        service.getPostOnId = function (id) {
            return $http.get(serviceRoute + "getPost/" + id);
        }
    }
})();