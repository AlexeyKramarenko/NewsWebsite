

(function () {
    'use strict';
    angular.module("news.app")
           .controller("NewsController", NewsController);
            
    function NewsController(newsService, $window) {

        var vm = this;
        vm.NewsPageViewModel = null;

        vm.getNewsById = getNewsById;

        activate();

        function activate() {
            getLastNewsEvent();
        }
        function getLastNewsEvent() {
            newsService.getLastNewsEvent()
                       .then(onSuccess)
                       .catch(onError); 
        }
        function getNewsById(newsID) {

            newsService.getNewsEventById(newsID)
                       .then(onSuccess)
                       .catch(onError); 
        }
        function onSuccess(data) {
                vm.NewsPageViewModel = data;
            }
        function onError(error) {
            $window.alert('Виникли деякi помилки. Спробуйте пiзнiше.');
        }
    }
})()