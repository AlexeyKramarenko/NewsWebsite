

(function () {
    'use strict';

    angular.module("admin.app")
           .factory("imagesService", imagesService);

    function imagesService($http) {

        var service = {
            uploadImage: uploadImage,
            saveImages: saveImages,
            getMainPhotos: getMainPhotos,
            deletePhotos: deletePhotos
        }
        return service;


        function uploadImage(file) {
            var url = "/webapi/main/UploadImage";
            var data = new FormData();
            data.append("image", file);

            var config = {
                withCredentials: true,
                headers: { "Content-Type": undefined, },
                transformRequest: angular.identity
            };

            return $http.post(url, data, config)
                        .then(onSuccess_uploadImage)
                        .catch(onError);
        }
        function saveImages(imageUrls) {
            var url = "/webapi/main/SaveImages";
            var data = JSON.stringify(imageUrls);
            return $http.post(url, data)
                        .then(onSuccess_saveImages)
                        .catch(onError);
        }

        function getMainPhotos() {
            var url = "/webapi/main/GetMainPhotos";
            return $http.get(url)
                        .then(onSuccess)
                        .catch(onError);

           
            function onError(error) {

            }
        }
        function deleteMainPhoto(id) {
            var url = "/webapi/main/DeleteMainPhoto";
            var data = { params: { id: id } };
            return $http.delete(url, data)
                        .then(onSuccess)
                        .catch(onError);
        }
        function deletePhotos(ids) {
             
            return $http({
                method: 'DELETE',
                url: "/webapi/main/DeletePhotos",
                data: {
                    jsonbody: ids
                },
                headers: {
                    'Content-type': 'application/json;charset=utf-8'
                }
            })
            .then(onSuccess)
            .catch(onError);
        }
        function onSuccess_saveImages(data) {

        }
        function onSuccess(data) {
            return data.data;
        }
        function onSuccess_uploadImage(data) {
            return data.data;
        }
        function onError(data) {

        }
    }

})()
