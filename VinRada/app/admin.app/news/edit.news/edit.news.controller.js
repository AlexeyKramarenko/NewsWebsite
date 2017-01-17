
(function () {
    'use strict';
    angular.module("admin.app")
           .controller("EditNewsController", EditNewsController);


    function EditNewsController(newsService, $window) {

        var vm = this;
        vm.LinksViewModel = [];
        vm.NewsPageViewModel = null;
        vm.getNewsById = getNewsById;
        vm.updateNews = updateNews;
        vm.deleteNewsById = deleteNewsById;

        activate();

        function activate() {
            getAllLinks();
        }
        function getAllLinks() {
            newsService.getAllLinks()
                       .then(getAllLinksSucceded)
                       .catch(onError);
        }
        function getNewsById(newsID) {
            newsService.getNewsEventById(newsID)
                       .then(getNewsByIdSucceded)
                       .catch(onError);
        }
        function deleteNewsById(id) {
            newsService.deleteNewsEvent(id)
                       .then(function (data) { deleteNewsByIdSucceded(data, id); })
                       .catch(onError);
        }
        function updateNews(newsPageViewModel) {
            newsService.updateNewsEvent(newsPageViewModel.NewsID, newsPageViewModel)
                       .then(function (data) { updateNewsSucceded(data, newsPageViewModel); })
                       .catch(onError);
        }

        //#region ajax result
        function updateNewsSucceded(data, newsPageViewModel) {
            for (var i = 0; i < vm.LinksViewModel.length; i++) {
                if (vm.LinksViewModel[i].ID === newsPageViewModel.NewsID) {
                    vm.LinksViewModel[i].Title = newsPageViewModel.Title;
                    vm.NewsPageViewModel = null;
                    $window.alert('Стаття оновлена успiшно.');
                    return;
                }
            }
        }
        function deleteNewsByIdSucceded(data, id) {
            for (var i = 0; i < vm.LinksViewModel.length; i++) {
                if (vm.LinksViewModel[i].ID === id) {
                    var title = vm.LinksViewModel[i].Title;
                    vm.LinksViewModel.splice(i, 1);
                    vm.NewsPageViewModel = null;
                    $window.alert('Стаття "' + title + '" видалена успiшно.');
                    return;
                }
            }
        }
        function getNewsByIdSucceded(data) {
            vm.NewsPageViewModel = data;
        }
        function getAllLinksSucceded(data) {
            for (var i = 0; i < data.length; i++)
                vm.LinksViewModel.push(data[i]);
        }
        function onError(error) {
            $window.alert('Виникли деякi помилки. Спробуйте пiзнiше.');
        } 
        //#endregion
    }

})()