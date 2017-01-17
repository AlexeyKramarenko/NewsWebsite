
(function () {

    'use strict';

    angular.module("news.app")
           .factory("newsService", newsService);

    function newsService($http) {

        var service = {
            getLastNewsEvent: getLastNewsEvent,
            getNewsEventById: getNewsEventById
        }
        return service;

        function getNewsEventById(Id) {
            var url = "/webapi/news/GetNewsEventById";
            var config = { params: { newsId: Id } };
            return $http.get(url, config)
                        .then(onSuccess)
                        .catch(onError);
        }
        function getLastNewsEvent() {
            var url = "/webapi/news/GetLastNewsEvent";
            return $http.get(url)
                        .then(onSuccess)
                        .catch(onError);
        }

        function onSuccess(data, status, headers, config) {
            return data.data;
        }
        function onError(data, status, headers, config) {
            return data.MessageDetail;
        }
    }

})()