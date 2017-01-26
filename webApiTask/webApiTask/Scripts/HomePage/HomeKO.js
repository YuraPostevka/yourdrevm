var ToDoList = function (data) {
    var self = this;

    self.Lists = ko.observableArray(data);
}

function viewModel() {
    var self = this;

    var itemMapping = {
        'ignore': ["Created", "Modified", "IsNotify", "Priority", "NextNotifyTime", "ToDoList_Id"]
    }

    var mapping = {
        'ignore': ["Created", "Modified", "User", "User_Id"],
        "Items": {
            create: function (options) {
                var m = ko.mapping.fromJS(options.data, itemMapping);

                m.Text.subscribe(function (newValue) {
                    //send ajax
                    self.SendItemText(m.Id(), newValue);
                });
                m.IsCompleted.subscribe(function (newValue) {
                    //send ajax
                    self.SendStatus(m.Id(), newValue);
                });
                return m;
            }
        },
        "Name": {
            create: function (options) {
                var m = ko.mapping.fromJS(options.data);

                m.subscribe(function (newValue) {
                    self.SendListName(options.parent.Id(), newValue);
                });

                return m;
            }
        }
    }
    self.SendStatus = function (id, value) {
        $.ajax({
            type: 'POST',
            url: '/Home/ChangeStatusOfItem',
            dataType: "json",
            data: { "id": id, "IsCompleted": value },
            success: function (data) {

            }
        });
    }
    self.SendItemText = function (id, value) {
        $.ajax({
            type: 'POST',
            url: '/Home/ChangeItemText',
            dataType: "json",
            data: { "id": id, "text": value },
            success: function (data) {

            }
        });
    }
    self.SendListName = function (id, value) {
        $.ajax({
            type: 'POST',
            url: '/Home/ChangeListName',
            dataType: "json",
            data: { "id": id, "name": value },
            success: function (data) {
                
            },
            error:function(data){
                alert('pizda');
            }
        });
    }

    self.loadLists = function () {
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            url: '/Home/GetAllToDoLists',
            dataType: 'JSON',
            success: function (data) {

                if (data.IsRedirect) {
                    window.location.href = data.redirectUrl;
                }

                self.toDoLists.removeAll();

                $.each(data, function (index, element) {

                    var model = ko.mapping.fromJS(element, mapping);

                    self.toDoLists.push(model);

                });
            },
            error: function () {
                console.log('shit');
            }
        });

        ko.bindingHandlers.inline = {
            init: function (element, valueAccessor) {
                var span = $(element);
                var input = $('<input />', { 'type': 'text', 'style': 'display:none' });
                span.after(input);

                ko.applyBindingsToNode(input.get(0), { value: valueAccessor() });
                ko.applyBindingsToNode(span.get(0), { text: valueAccessor() });

                span.click(function () {
                    input.width(span.width());
                    span.hide();
                    input.show();
                    input.focus();
                });

                input.blur(function () {
                    span.show();
                    input.hide();
                });

                input.keypress(function (e) {
                    if (e.keyCode == 13) {
                        span.show();
                        input.hide();
                    };
                });
            }
        };

    }

    self.toDoLists = ko.observableArray();
}
var vm = new viewModel();
$(function () {
    vm.loadLists();
    ko.applyBindings(vm);
})

