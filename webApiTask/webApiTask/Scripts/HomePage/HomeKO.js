function viewModel() {
    var self = this;

    self.bindTagsEditor = function () {

    }

    var itemMapping = {
        'ignore': ["Created", "Modified", "IsNotify", "Priority", "NextNotifyTime", "ToDoList_Id"]
    }

    var tagMapping = {
        'ignore': ["Created", "Modified"]
    }


    var listMapping = {
        'ignore': ["Created", "Modified", "User", "User_Id"],

        "Items": {
            create: function (options) {
                var m = newItem(options.data);
                return m;
            }
        },
        'Name': {
            create: function (options) {

                var m = ko.mapping.fromJS(options.data);

                m.subscribe(function (newValue) {
                    self.SendListName(options.parent.Id(), newValue);
                });

                return m;
            }
        },
        "Tags": {
            create: function (options) {
                var m = newTag(options.data);
                return m;
            }
        }

    }

    self.SendStatus = function (id, value) {
        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/ChangeStatusOfItem'),
            dataType: "json",
            data: { "id": id, "IsCompleted": value },
            success: function (data) {

            }
        });
    }
    self.SendItemText = function (id, value) {
        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/ChangeItemText'),
            dataType: "json",
            data: { "id": id, "text": value },
            success: function (data) {

            }
        });
    }
    self.SendListName = function (id, value) {
        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/ChangeListName'),
            dataType: "json",
            data: { "id": id, "name": value },
            success: function (data) {

            },
            error: function (data) {
                alert('ouuuu');
            }
        });
    }


    self.loadLists = function () {
        $.ajax({
            type: 'GET',
            contentType: 'application/json',
            url: appContext.buildUrl('/Home/GetAllToDoLists'),
            dataType: 'JSON',
            success: function (data) {

                if (data.message != null) {
                    alert(data.message);
                    return;
                }

                self.toDoLists.removeAll();

                $.each(data, function (index, element) {

                    var listModel = newList(element);

                    self.toDoLists.push(listModel);

                });
            },
            error: function () {
                console.log('ouuu');
            }
        });

    }
    self.removeItem = function (data, item) {
        data.Items.remove(item);

        var id = item.Id();
        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/DeleteItem'),
            dataType: "json",
            data: { "id": id },
            success: function (data) {

            },
            error: function (data) {
                alert('ouuu');
            }
        });
    };

    self.removeList = function (list) {
        self.toDoLists.remove(list);
        var id = list.Id();
        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/DeleteList'),
            dataType: "json",
            data: { "id": id },
            success: function (data) {

            },
            error: function (data) {
                alert('ooou');
            }
        });

    };


    var newItem = function (data) {
        var m = ko.mapping.fromJS(data, itemMapping);

        m.Text.subscribe(function (newValue) {
            //send ajax
            self.SendItemText(m.Id(), newValue);
        });
        m.IsCompleted.subscribe(function (newValue) {
            //send ajax
            self.SendStatus(m.Id(), newValue);
        });
        return m;
    };

    var newList = function (data) {
        var m = ko.mapping.fromJS(data, listMapping);

        var tags = [];
        $.each(m.Tags(), function (index, element) {
            tags.push(element.Name());
        });

        m.bindTagsEditor = function (elements) {

            $.each(elements, function (index, elem) {
                if (elem.nodeName == "INPUT") {
                    $(elem).tagEditor({
                        initialTags: tags,
                        placeholder: 'Enter tags ...',

                        beforeTagDelete: function (field, editor, tags, val) {
                            self.removeTag(val, m.Id());
                        },
                        beforeTagSave: function (field, editor, tags, tag, val) {

                            self.addTag(val, m.Id());
                        },

                    });
                }
            });
        }
        m.findTag = function () {

            $('.tag-editor-tag').each(function () {
                $(this).click(function () {
                    tagName = $(this).html();

                    $.ajax({
                        type: 'GET',
                        url: appContext.buildUrl('/Home/GetAllToDoLists'),
                        dataType: "json",
                        data: { 'tagName': tagName },
                        success: function (data) {

                            self.toDoLists.removeAll();

                            $.each(data, function (index, element) {

                                var listModel = newList(element);

                                self.toDoLists.push(listModel);

                                $('.tagName').empty();
                                $('.tagName').append("#" + tagName + "<span onclick = 'vm.RefreshLists();' style='cursor:pointer; font-size=20px;'><i></i></span>");
                            });

                        },
                        error: function (data) {
                            alert('oops');
                        }
                    });

                });
            });

        }
        return m;
    };

    self.RefreshLists = function () {
        self.loadLists();
        $('.tagName').empty();
    }

    self.removeTag = function (value, listId) {

        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/DeleteTag'),
            dataType: "json",
            data: { 'tag': value, 'listId': listId },
            success: function (data) {

            },
            error: function (data) {
                alert('oops');
            }
        });
    };

    self.addTag = function (value, listId) {
        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/AddTag'),
            dataType: "json",
            data: { 'tag': value, 'listId': listId },
            success: function (data) {

            },
            error: function (data) {
                alert('oops');
            }
        });
    };


    var newTag = function (data) {
        var m = ko.mapping.fromJS(data, tagMapping);

        return m;
    };


    self.AddItem = function (data) {
        var listId = data.Id();

        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/AddItem'),
            dataType: "json",
            data: { "ToDoList_Id": listId, "Text": "newItem", "IsCompleted": false },

            success: function (item) {
                var m = newItem(item);
                data.Items.push(m);
            },
            error: function (data) {
                alert('oops');
            }
        });
        return data;
    };


    self.AddList = function () {

        var data =
           {
               'Name': "newList",
               'Items': [
                   {
                       'Text': 'newItem',
                       'IsCompleted': false
                   }
               ]
           };

        $.ajax({
            type: 'POST',
            url: appContext.buildUrl('/Home/AddList'),
            dataType: "json",
            data: data,
            success: function (list) {

                var model = newList(list);

                self.toDoLists.push(model);
            }

        });

    };

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


    self.toDoLists = ko.observableArray();
}


var vm = new viewModel();

$(function () {

    vm.loadLists();
    ko.applyBindings(vm);
})

