
(function () {
    'use strict';
    angular.module("admin.app")
           .controller("CreateNewsController", CreateNewsController);


    function CreateNewsController(newsService, $window) {

        var vm = this;
        vm.newsObj = null;
        vm.create = create;
        
        function create(newsObj, form) {
            if (form.$valid)
                newsService.addNewsEvent(newsObj)
                           .then(onSuccess)
                           .catch(onError);
            else
                $window.alert('Перевiрте чи Ви не забули заповнити усi поля.')
        }
        function onSuccess() {
            $window.alert('Стаття збережена успiшно.')
            vm.newsObj = null;
        }
        function onError(error) {
            $window.alert('Виникли деякi помилки. Спробуйте пiзнiше.');
        } 
    }
})()