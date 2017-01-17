
(function () {
    angular.module('admin.app')
           .controller('DeleteImagesController', DeleteImagesController);


    function DeleteImagesController(imagesService, $window) {

        var vm = this;
        vm.images = [];
        vm.deleteImages = deleteImages;

        activate();

        function activate() {
            getImages();
        }

        function deleteImages() {

            var photoIDs = [];

            var arrayOfIdsToDeleteOnPage = [];

            for (var i = 0; i < vm.images.length; i++) {
                if (vm.images[i].checked === true) {
                    photoIDs.push(vm.images[i].id);
                    arrayOfIdsToDeleteOnPage.push(i);
                }
            }
            if (photoIDs.length > 0) {

                imagesService.deletePhotos(photoIDs)
                             .then(function(data){ deletePhotosSucceded(photoIDs,arrayOfIdsToDeleteOnPage);})
                             .catch(onError); 
            }
            else
                $window.alert('Ви не вибрали жодної фотографiї.');
        } 
        function getImages() {

            imagesService.getMainPhotos()
                        .then(getImagesSucceded)
                        .catch(onError); 
        }

        //#region ajax result
        function deletePhotosSucceded(photoIDs, arrayOfIdsToDeleteOnPage) {
            $window.alert('Видалено ' + photoIDs.length + ' фотографiй.'); 
            for (var i = arrayOfIdsToDeleteOnPage.length - 1; i >= 0; i--) {
                var index = arrayOfIdsToDeleteOnPage[i];
                vm.images.splice(index, 1);
            }
        }
        function getImagesSucceded(data) {

            for (var i = 0; i < data.length; i++) {
                var obj = {
                    checked: false,
                    id: data[i].ID,
                    url: data[i].Image
                }; 
                vm.images.push(obj);
            }
        }
        function onError(error) {

        }

        //#endregion
    }
})()