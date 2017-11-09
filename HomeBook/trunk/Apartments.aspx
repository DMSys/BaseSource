
<%@ Page Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="Apartments.aspx.cs" CodeFileBaseClass="System.Web.UI.Page" Inherits="Apartments" Title="Untitled Page" %>
<%@ Import Namespace="NachoContent" %>
<%@ Register TagPrefix="nachoContent" Namespace="NachoContent" %>
<%@ Register TagPrefix="art" TagName="DefaultMenu" Src="DefaultMenu.ascx" %> 
<%@ Register TagPrefix="art" TagName="DefaultHeader" Src="DefaultHeader.ascx" %> 
  

<asp:Content ID="PageTitle" ContentPlaceHolderID="TitleContentPlaceHolder" Runat="Server">
   Домова книга
</asp:Content>

<asp:Content ID="MenuContent" ContentPlaceHolderID="MenuContentPlaceHolder" Runat="Server">
    <art:DefaultMenu ID="DefaultMenuContent" runat="server" />
</asp:Content>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeaderContentPlaceHolder" Runat="Server">
    <art:DefaultHeader ID="DefaultHeader" runat="server" />
</asp:Content>

<asp:Content ID="SheetContent" ContentPlaceHolderID="SheetContentPlaceHolder" Runat="Server">
    
  <nachoContent:Article ID="Article1" Caption="Апартаменти" runat="server"><ContentTemplate>
    <img src="Content/images/preview.jpg" alt="an image" style="float:left;" />
    
    <p>В този раздел са указани апартаментите във вашата кооперация. Тук можете да добавяте и редактирате данни. Логнете се в системата за да започнете работа.</p>
    <div class="cleared"></div>
        
 </ContentTemplate>
      
</nachoContent:Article>

 <nachoContent:Article ID="Article3" Caption="Действия" runat="server">

   <ContentTemplate>    
     <br> 
    
     <table id="tb_action" class="nacho-article" border="0" cellspacing="0" cellpadding="0">
      <tbody>
        <tr> 
          <th><a id="addPopup" href='AddApartaments.aspx?id=<%# Eval("ID") %>' title="Добавяне">Добави апартамент</a></th>
           <th><a id="a1" href='Other/Export.aspx?ID=<%= this.ImportString %>' title="Експорт">Експорт в XLS</a></th>    
        </tr>
      </tbody>
     </table>    

    </ContentTemplate>
  
 </nachoContent:Article>
   
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ui.datepicker-bg.js"></script>
    <link type="text/css" rel="Stylesheet" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/themes/smoothness/jquery-ui.css">
     
     <script type="text/javascript">
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
   </script>
   <script type="text/javascript">
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
  </script>
       
     <table id="tb_Filter" runat="server" class="nacho-article" width="100%" border="0" cellspacing="0" cellpadding="0">
      <tbody>
        <tr> 
         <th><asp:Label ID="Label1" runat="server" Text="Контакт: "><asp:DropDownList ID="ddlContactor" runat="server"></asp:DropDownList></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_Status" runat="server" Text="Статус: "><asp:DropDownList ID="ddl_Status" runat="server"></asp:DropDownList></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_Apartament" runat="server" Text="Семейство: "><asp:DropDownList ID="ddl_Home" runat="server"></asp:DropDownList></asp:Label>
          &nbsp;&nbsp;&nbsp;&nbsp<asp:Button ID="btn_applyFilter" runat="server" Text="Приложи" OnClick="btn_applyFilter_Click" />

         </th>
        </tr>
      </tbody>
     </table>

    <asp:ImageButton ID="btnRefresh"  title="обнови грида" ImageUrl="Content/images/Otmetka.png" Text="refresh" runat="server" style="visibility: hidden; display: none;" onclick="btnRefresh_Click" />
          
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>

     <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
           <img src="Content/images/progress_bar.gif" alt="" />
        </ProgressTemplate>
     </asp:UpdateProgress>
 
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional" >
   <ContentTemplate>
        
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"   GridLines="None"  
       AllowPaging="true"  CssClass="mGrid" PagerStyle-CssClass="pgr"  AlternatingRowStyle-CssClass="alt" OnRowDataBound="GridView1_RowDataBound">

       <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ID" />
            <asp:TemplateField HeaderText="">
           <ItemTemplate >
                <a id="popup" title="Редакция" href='EditApartaments.aspx?id=<%# Eval("ID") %>' ><img src="Content/images/edit.png" alt="Редакция" /></a>           
           </ItemTemplate>         
           </asp:TemplateField>
            <asp:TemplateField HeaderText="">
           <ItemTemplate > 
                <asp:ImageButton  ID="lnkdelete" runat="server" ImageUrl="Content/images/DeleteRow.png" OnClick="lnkdelete_Click" ToolTip="Изтриване" />           
           </ItemTemplate>               
           </asp:TemplateField>
           <asp:TemplateField HeaderText="Статус" >
                <ItemTemplate >            
                         <asp:Image ID="Image" runat="server" ToolTip='<%# Eval("StatusName").ToString().Trim() %>' ImageUrl='<%# "~/Content/images/status" + Eval("Status") + ".png" %>'/>    
                </ItemTemplate>
           </asp:TemplateField>
     
                <asp:BoundField DataField="Home" HeaderText="Семейство"
                    SortExpression="Home" />
                <asp:BoundField DataField="Floor" HeaderText="Етаж"
                    SortExpression="Floor" />
                <asp:BoundField DataField="Number" HeaderText="Номер"
                    SortExpression="Number" />
                <asp:BoundField DataField="People" HeaderText="Живущи"
                    SortExpression="People" />              
                 <asp:BoundField DataField="Percent1" HeaderText="Дял %"
                    SortExpression="Percent1" />
                <asp:BoundField DataField="Contact" HeaderText="Контакт"
                    SortExpression="Contact" />
                 <asp:BoundField DataField="Phone" HeaderText="Телефон"
                    SortExpression="Phone" />
                 <asp:BoundField DataField="Email" HeaderText="Email"
                    SortExpression="Email" />
                <asp:BoundField DataField="Notes" HeaderText="Бележки"
                    SortExpression="Notes" />

          </Columns>
       </asp:GridView>
                   
   </ContentTemplate>
</asp:UpdatePanel>
       
</asp:Content>

    