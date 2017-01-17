
(function () {
    'use strict';

    angular.module("admin.app")
           .controller("CreateArticleController", CreateArticleController);


    function CreateArticleController(articleService, $window) {

        var vm = this;
        vm.article = null;
        vm.createArticle = createArticle;

        activate();

        function activate() {
            vm.article = new Article('Дiяльнiсть', null, null, null);
        }

        function createArticle(article, articleForm) {
            if (articleForm.$valid)
                articleService.createArticle(article)
                              .then(onSuccess)
                              .catch(onError);
            else
                $window.alert('Перевiрте чи Ви не забули заповнити усi поля.')
        }

        function onSuccess(data, status, headers, config) {
            $window.alert('Стаття збережена успiшно.')
            activate();
        }
        function onError(data, status, headers, config) {
            $window.alert('Виникли деякi помилки. Спробуйте пiзнiше.');
        }
    }


    function Article(SelectedCategory, Title, TextContent, ImagesContent) {
        this.SelectedCategory = SelectedCategory;
        this.Title = Title;
        this.TextContent = TextContent;
        this.ImagesContent = ImagesContent;
    }
})();