
(function () {
    'use strict';

    angular.module("admin.app")
           .controller("CreateGalleryController", CreateGalleryController);

    function CreateGalleryController(articleService, $window) {

        var vm = this;
        vm.gallery = null;
        vm.fileUploadForm = null;
        vm.uploadImage = uploadImage;
        vm.createGallery = createGallery;
        vm.clearCreateGalleryForm = clearCreateGalleryForm;

        activate();

        function activate() {
            vm.gallery = new Gallery(['Свята'], 'Свята', null, [], null);
        }
        function uploadImage() {
            var file = document.getElementById('file').files[0];
            articleService.uploadImage(file)
                          .then(uploadImageSucceded)
                          .catch(uploadImageFailed); 
        }
        function createGallery(gallery, galleryForm) {

            var array = gallery.ImagesContent;
            gallery.ImagesContent = [];
            for (var i = 0; i < array.length; i++) {
                var obj = array[i];
                gallery.ImagesContent.push(new ImagesContent(obj.Description, obj.ImageSource));
            } 
            if (galleryForm.$valid)
                articleService.createArticle(gallery)
                              .then(clearCreateGalleryForm)
                              .catch(createGalleryFailed);
            else
                $window.alert("Перевiрте чи Ви не забули заповнити усi поля."); 
        }

        //#region ajax result
        function uploadImageSucceded(imageUrl) {
            vm.gallery.ImagesContent.push(new ImagesContent(null, imageUrl));
        }
        function uploadImageFailed(data, status, headers, config) {
            $window.alert('Виникли помилки при спробi завантажити зображення. Спробуйте пiзнiше.')
        }
        function clearCreateGalleryForm() {
            clearFileInput();
            vm.gallery.ImagesContent = [];
            vm.gallery.Title = null;
        }
        function clearFileInput() {
            document.getElementById('inputPlaceholder').innerHTML = "<input type='file' id='file' accept='image/*' />";
        }
        function createGalleryFailed(data, status, headers, config) {
            $window.alert('Виникли помилки при спробi збереження форми. Спробуйте пiзнiше.');
        }
        //#endregion
    }

    function Gallery(Categories, SelectedCategory, Title, ImagesContent, TextContent) {
        this.Categories = Categories;
        this.SelectedCategory = SelectedCategory;
        this.Title = Title;
        this.ImagesContent = ImagesContent;
        this.TextContent = TextContent;
    }

    function ImagesContent(Description, ImageSource) {
        this.Description = Description;
        this.ImageSource = ImageSource;
    }
})()