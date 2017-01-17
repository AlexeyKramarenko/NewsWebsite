
(function () {
    'use strict';

    angular.module("admin.app")
           .controller("ContactsController", ContactsController);

    function ContactsController(contactsService, $window) {

        var vm = this;
        vm.Contacts = null;
        vm.save = save;

        activate();

        function activate() {
            getContacts();
        }
        function getContacts() {

            contactsService.getContacts()
                                 .then(getContactsSucceded)
                                 .catch(onError);
        }
        function save(contactsObj, contactsForm) {

            if (contactsForm.$valid)
                contactsService.updateContacts(contactsObj)
                               .then(updateContactsSucceded)
                               .catch(onError);
        }

        //#region ajax result
        function getContactsSucceded(data) {
            if (data.data != null)
                vm.Contacts = data.data;
            else
                vm.Contacts = {
                    address: "",
                    email: "",
                    phoneNumber: ""
                };
        }
        function updateContactsSucceded(data) {
            return data;
        }
        function onError(error) {
            $window.alert("Виникла помилка.");
        }
        //#endregion

    }
})()