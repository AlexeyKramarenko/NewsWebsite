
(function () {

    'use strict';

    angular.module("admin.app")
           .factory("newsService", newsService);


    function newsService($http) {

        var service = {
            addNewsEvent: addNewsEvent,
            getAllLinks: getAllLinks,
            getLastNewsEvent: getLastNewsEvent,
            getNewsEventById: getNewsEventById,
            deleteNewsEvent: deleteNewsEvent,
            updateNewsEvent: updateNewsEvent
        }
        return service;

        function getAllLinks() {
            var url = "/webapi/news/GetAllLinks";
            return $http.get(url)
                        .then(onSuccess)
                        .catch(onError);
        }
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
        function addNewsEvent(newsEvent) {
            var url = "/webapi/news/AddNewsEvent";
            var data = JSON.stringify(newsEvent);
            return $http.post(url, data)
                        .then(onSuccess)
                        .catch(onError);
        }
        function updateNewsEvent(id, newsEvent) {
            var url = "/webapi/news/UpdateNewsEvent";
            var data = JSON.stringify(newsEvent);
            return $http.put(url, data)
                        .then(onSuccess)
                        .catch(onError);
        }
        function deleteNewsEvent(newsId) {
            var url = "/webapi/news/DeleteNewsEventById";
            var data = { params: { newsId: newsId } };
            return $http.delete(url, data)
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