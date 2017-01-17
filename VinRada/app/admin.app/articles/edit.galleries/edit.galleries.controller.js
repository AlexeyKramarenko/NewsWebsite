
(function () {
    'use strict';

    angular.module("admin.app")
           .controller("EditGalleriesController", EditGalleriesController);

    function EditGalleriesController(articleService, $window) {

        var vm = this;
        var allLinks = [];
        vm.links = [];
        vm.selectedCategory = 'Свята';
        vm.categories = ['Свята'];
        vm.deleteGalleryById = deleteGalleryById;
        vm.gelLinksByCategory = gelLinksByCategory;

        activate();

        function activate() {
            getGalleryLinks();
        }
        function getGalleryLinks() {
            articleService.getGalleryLinks()
                          .then(getGalleryLinksSucceded)
                          .catch(onError);
        }
        function deleteGalleryById(id, title) {
            var result = $window.confirm('Ви справдi хочете видалити галерею "' + title + '"?');
            if (result) {
                articleService.deleteArticleById(id)
                              .then(function (data) { deleteArticleByIdSucceded(data, title); })
                              .catch(onError);
            }
        }
        function gelLinksByCategory(category) {
            if (category !== 'Все') {
                vm.links = [];
                allLinks.forEach(function (link, index) {
                    if (link.Category === category)
                        vm.links.push(link);
                })
            }
            else
                vm.links = allLinks;
        }

        //#region ajax result 
        function getGalleryLinksSucceded(data, status, headers, config) {

            allLinks = [];
            for (var i = 0; i < data.length; i++)
                allLinks.push(data[i]);

            vm.links = allLinks;
        }
        function deleteArticleByIdSucceded(data, title) {
            for (var i = 0; i < vm.links.length; i++) {
                if (vm.links[i].ID === id)
                    vm.links.splice(i, 1);
            }
            alert('Галерея "' + title + '" видалена успiшно.');
        }
        function onError(data, status, headers, config) {
            alert('Сталася помилка. Спробуйте пiзнiше.');
        } 
        //#endregion
    }
})()