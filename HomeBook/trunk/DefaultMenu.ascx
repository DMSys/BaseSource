<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DefaultMenu.ascx.cs" Inherits="Menu" %>
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <link type="text/css" rel="Stylesheet" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/themes/smoothness/jquery-ui.css">
    <script type="text/javascript">
        $.fx.speeds._default = 2000;
        $(document).ready(function () {
            $('a#login').live('click', function (e) {

                var page = $(this).attr("href")  //get url of link

                var $dialog = $('<div></div>')
                .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                .dialog({
                    autoOpen: false,
                    modal: true,
                    height: 330,
                    width: 410,
                    title: "Форма за вход",

                    buttons: {
                        "Затвори": function () { $dialog.dialog('close'); }
                    },
                    close: function (event, ui) {

                        window.location.href = "Default.aspx";
                    }
                });
                $dialog.dialog('open');
                e.preventDefault();
            });
        });
    </script>
    <script type="text/javascript">
       function fnDemo() {
           var btnlogin = document.getElementById("<%=btnRefresh.ClientID%>");
           btnlogin.click();
           return true;
       }
     </script>
<html>
<body>
    
<ul class="nacho-hmenu">
    <li><a href="Default.aspx" class=" active"><span class="l"></span><span class="r"></span><span class="t">Home</span></a></li>
    <li><a href="#"><span class="l"></span><span class="r"></span><span class="t">Финанси</span></a>
        <ul>
            <li><a href="Payments.aspx">Приходи и Разходи</a></li>
            <li><a href="#">Плащания</a></li>
            <li><a href="#">Протоколи</a></li>
        </ul>
    </li>
    <li><a href="Apartments.aspx"><span class="l"></span><span class="r"></span><span class="t">Апартаменти</span></a></li>
    <li><a href="People.aspx"><span class="l"></span><span class="r"></span><span class="t">Живущи</span></a></li>
   
    <li><a href="Notes.aspx"><span class="l"></span><span class="r"></span><span class="t">Бележки</span></a></li>
    <li><a href="#"><span class="l"></span><span class="r"></span><span class="t">Настройки</span></a></li>
    <li><a href="#"><span class="l"></span><span class="r"></span><span class="t">Поддръжка</span></a></li>
    
    <li><a href="#"><span class="l"></span><span class="r"></span><span class="t">Справки</span></a></li>
    <li><a href="#"><span class="l"></span><span class="r"></span><span class="t">За нас</span></a></li>
    <li><a href="javascript:void(0)" onclick="fnDemo();">Демо режим</a></li>
    <li><a id="login" href='Logon.aspx'><%= this.InputValue %></a></li>
    
</ul>   
     <asp:ImageButton ID="btnRefresh"  Text="refresh" runat="server" style="visibility: hidden; display: none;" onclick="btnRefresh_Click" />  
</body>
</html>
