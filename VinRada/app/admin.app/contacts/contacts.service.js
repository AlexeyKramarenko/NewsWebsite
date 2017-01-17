
(function () {
    'use strict';

    angular.module("admin.app")
           .factory("contactsService", contactsService);

    function contactsService($http) {

        var service = {
            updateContacts: updateContacts,
            getContacts: getContacts
        }

        return service;

        function updateContacts(contactsViewModel) {
            var url = "/webapi/contacts/UpdateContacts";
            var data = JSON.stringify(contactsViewModel);
            return $http.put(url, data)
                        .then(onSuccess)
                        .catch(onError);
        }
        function getContacts() {
            var url = "/webapi/contacts/GetContacts";
            return $http.get(url)
                        .then(onSuccess)
                        .catch(onError);
        }

        function onSuccess(data, status, headers, config) {
            return data;
        }
        function onError(data, status, headers, config) {
            return data;
        }
    }

})();
