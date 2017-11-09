// за раздел плащания от тук
$.fx.speeds._default = 2000;
$(document).ready(function () {
    $('a#popup').live('click', function (e) {

        var page = $(this).attr("href")  //get url of link

        var $dialog = $('<div></div>')
        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
        .dialog({
            autoOpen: false,
            modal: true,
            height: 600,
            width: 'auto',
            title: "Редакция на запис",

            buttons: {
                "Затвори": function () { $dialog.dialog('close'); }
            },
            close: function (event, ui) {

                var btnlogout = document.getElementById("<%=btnRefresh.ClientID%>");
                btnlogout.click();
            }
        });
        $dialog.dialog('open');
        e.preventDefault();
    });
});

$(document).ready(function () {
    $('a#addPopup').live('click', function (e) {

        var page = $(this).attr("href")  //get url of link

        var $dialog = $('<div></div>')
        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
        .dialog({
            autoOpen: false,
            modal: true,
            height: 600,
            width: 'auto',
            title: "Добавяне на запис",

            buttons: {
                "Затвори": function () { $dialog.dialog('close'); }
            },
            close: function (event, ui) {

                var btnlogout = document.getElementById("<%=btnRefresh.ClientID%>");
                btnlogout.click();
            }
        });
        $dialog.dialog('open');
        e.preventDefault();
    });
});

// До тук раздел плащания