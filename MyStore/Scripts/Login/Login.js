var ViewModel = function () {

    var self = this;

    self.emailId = ko.observable();
    self.password = ko.observable();

    self.submit = function () {        
        
        var model = {
              'EmailId': self.emailId(),
             'Password' : self.password() 
        }
        console.log(model);
        $.ajax
         ({
             type: "POST",
             url: "/api/Authentication",
             dataType: "json",
             contentType: "application/json",
             async: false,
             data: JSON.stringify(model),
             success: function (result) {
                 debugger;
                 token = result;
             }
         });
    }

};

$(document).ready(function () {
   
    var model = ko.applyBindings(new ViewModel());
});