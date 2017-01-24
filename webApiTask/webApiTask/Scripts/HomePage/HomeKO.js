var ToDoItem = function (name) {
    var self = this;
    var name = ko.observable(name);
}

var getItems = $.ajax({
    type: 'GET',
    contentType: 'application/json',
    url: 'GetAllItems',
    dataType: 'JSON',
    success: function (data) {

    },
    error: function () {
        console.log('shit');
    }
});