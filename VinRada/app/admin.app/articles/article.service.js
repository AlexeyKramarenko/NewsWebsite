

(function () {
    'use strict';

    angular.module("admin.app")
           .factory("articleService", articleService);

    function articleService($http) {

        return {
            getArticleById: getArticleById,
            getArticleLinks: getArticleLinks,
            getArticleLinksByCategory: getArticleLinksByCategory,
            getArticlesByCategory: getArticlesByCategory,
            createArticle: createArticle,
            updateArticle: updateArticle,
            deleteArticleById: deleteArticleById,
            uploadImage: uploadImage,
            getGalleryLinks: getGalleryLinks
        }

        function getGalleryLinks() { 
            var url = "/webapi/articles/GetGalleryLinks";
            return $http.get(url)
                        .then(onSuccess)
                        .catch(onError);
        }

        function getArticleById(Id) {
            var url = "/webapi/articles/GetArticleById";
            var config = {
                params: { Id: Id }
            };
            function onSuccess_getArticleById(response) {
                var article = response.data;
                return article;
            }
            return $http.get(url, config)
                        .then(onSuccess_getArticleById)
                        .catch(onError);
        }
        function getArticleLinks() {
            var url = "/webapi/articles/GetArticleLinks";
            return $http.get(url)
                        .then(onSuccess)
                        .catch(onError); 
        }
        function getArticleLinksByCategory(category) {
            var url = "/webapi/articles/GetArticleLinksByCategory";
            var config = {
                params: { category: category }
            }
            function onSuccess_getArticleLinksByCategory(response) {
                return response.data;
            }
            return $http.get(url, config)
                       .then(onSuccess_getArticleLinksByCategory)
                       .catch(onError);
        }
        function getArticlesByCategory(category) {
            var url = "/webapi/articles/GetArticlesByCategory";
            var config = {
                params: { category: category }
            };
            return $http.get(url, config)
                       .then(onSuccess)
                       .catch(onError);
        }
        function createArticle(createArticleViewModel) {
             
            var url = "/webapi/articles/CreateArticle";
            var data = JSON.stringify(createArticleViewModel);
            return $http.post(url, data)
                        .then(onSuccess)
                        .catch(onError);

        }
        function updateArticle(articleViewModel) {
            var url = "/webapi/articles/UpdateArticle";
            var data = JSON.stringify(articleViewModel);
            return $http.put(url, data)
                        .then(onSuccess)
                        .catch(onError);
        }
        function deleteArticleById(id) {
            var url = "/webapi/articles/DeleteArticleById";
            var data = { params: { id: id } };
            return $http.delete(url, data)
                        .then(onSuccess_deleteArticleById)
                        .catch(onError);
        }
        function uploadImage(image) {
            var url = "/webapi/articles/UploadImage";
            var data = new FormData();
            data.append("image", image);
            var config = {
                withCredentials: true,
                headers: { "Content-Type": undefined, },
                transformRequest: angular.identity
            }
            return $http.post(url, data, config)
                        .then(onSuccess_uploadImage)
                        .catch(onError);
        }
        function onSuccess_uploadImage(response) {
            return response.data;
        }
        function onSuccess(response) {
            return response.data;
        }
        function onSuccess_deleteArticleById(response) {
            return response.config.params.id;
        }
        function onError(response) {
            return response.data;
        }
    }
})()
