/// <reference path="../Knockout/knockout-3.4.2.js" />
var ViewModel = function () {

    var self = this;

    self.Stores = ko.observableArray();

    self.GetAllStores = function () {
        $.ajax
         ({
             type: "GET",
             url: "/api/GetAllStore",
             dataType: 'json',
             async: false,
             beforeSend: function (xhr) {
                 xhr.setRequestHeader("Authorization", sessionStorage.getItem("token"));
             },
             success: function (result) {
                 self.Stores(result);
             },
             error: function (exception, error, response) {
                
                 console.log(exception);
                 console.log(error);
                 console.log(response);
             }
         });
    };

};

$(document).ready(function () {
    var model = new ViewModel();
    ko.applyBindings(model, document.getElementById("divStore"));
});