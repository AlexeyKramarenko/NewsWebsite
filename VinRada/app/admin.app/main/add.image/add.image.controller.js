
(function () {
    angular.module('admin.app')
           .controller('AddImageController', AddImageController);


    function AddImageController(imagesService, $window) {

        var vm = this;
        vm.imageUrls = [];
        vm.uploadImage = uploadImage;
        vm.saveImages = saveImages;
        

        function uploadImage() {

            var file = document.getElementById('file').files[0];

            if (file == null)
                $window.alert('Виберiть зображення');

            else {
                imagesService.uploadImage(file)
                             .then(uploadImageSucceded)
                             .catch(uploadImageFailed); 
            }
        }
        function saveImages() {
          
            if (vm.imageUrls.length > 0) {

                imagesService.saveImages(vm.imageUrls)
                             .then(clearForm)
                             .catch(saveImagesFailed); 
            }
        }
        //#region ajax result
        function uploadImageSucceded(imageUrl) {
            vm.imageUrls.push(imageUrl);
        }
        function uploadImageFailed(data) {
            $window.alert('Виникли помилки при спробi завантажити зображення. Спробуйте пiзнiше.')
        } 
        function clearForm() {
            clearFileInput();
            vm.imageUrls = [];

            function clearFileInput() {
                document.getElementById('inputPlaceholder').innerHTML = "<input type='file' id='file' accept='image/*' />";
            }
        }
        function saveImagesFailed(data) {
            $window.alert('Виникли помилки при спробi збереження форми. Спробуйте пiзнiше.');
        }
        //#endregion
    }
})()