
(function () {
    'use strict';

    angular.module("admin.app")
           .controller("EditArticlesController", EditArticlesController);



    function EditArticlesController(articleService, $window) {

        var vm = this;

        vm.category = 'Дiяльнiсть';
        vm.links = [];
        vm.article = null;

        vm.getArticleById = getArticleById;
        vm.getArticleLinks = getArticleLinks;
        vm.updateArticle = updateArticle;
        vm.deleteArticleById = deleteArticleById;
        vm.inputFieldDisabled = true;

        activate();

        function activate() {
            getArticleLinks();
        }
        function getArticleById(Id) {
            articleService.getArticleById(Id)
                          .then(getArticleByIdSucceded)
                          .catch(onError);
        }

        function getArticleLinks() {
            articleService.getArticleLinksByCategory(vm.category)
                          .then(getArticleLinksByCategorySucceded)
                          .catch(onError);
        }
        function updateArticle(article) {
            articleService.updateArticle(article)
                          .then(updateArticleSucceded)
                          .catch(onError);
        }

        function deleteArticleById(Id, title) {
            var result = $window.confirm('Ви справдi хочете видалити статтю "' + title + '"?');
            if (result) {
                articleService.deleteArticleById(Id)
                              .then(deleteArticleByIdSucceded)
                              .catch(onError);
            }
        }

        //#region ajax result
        function getArticleLinksByCategorySucceded(data, status, headers, config) {
            vm.links = [];
            for (var i = 0; i < data.length; i++)
                vm.links.push(data[i]);
        }
        function onError(data, status, headers, config) {
            alert('Сталася помилка. Спробуйте пiзнiше.');
        }
        function getArticleByIdSucceded(article) {
            hideFormInputField(false);
            vm.article = article;
        }
        function updateArticleSucceded() {
            $window.alert('Статтю збережено.')
            clearEditingForm();
            activate();
            hideFormInputField(true);
        }
        function deleteArticleByIdSucceded(id) {
            removeUnexistedLink(id);
            clearEditingForm();
            var currentEditedArticleId = vm.article.ID;
            if (currentEditedArticleId === id)
                hideFormInputField(true);
        }
        function removeUnexistedLink(id) {
            var liElement = document.querySelector("#articleLink_" + id);
            angular.element(liElement).remove();
        }
        function clearEditingForm() {
            var form = document.getElementById('articleForm');
            form.reset();
        }
        function hideFormInputField(flag) {
            vm.inputFieldDisabled = flag;
        }
        //#endregion


    }
})()