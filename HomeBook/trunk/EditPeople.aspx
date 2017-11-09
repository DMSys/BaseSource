<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPeople.aspx.cs" Inherits="EditPeople" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <h3>Редакция на вашите данни</h3>
        <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
        <asp:Panel ID="pnlEdit" runat="server">

      <table border="1" cellspacing="1" cellpadding="1">
      <tbody>
        <tr>
             
            <p><th>ID:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtID" ReadOnly="true" runat="server"></asp:TextBox></th></p>
        </tr>
       
        <tr>
            <p><th>Статус:&nbsp;&nbsp;&nbsp;</th><th><asp:DropDownList ID="ddl_Status" runat="server"></asp:DropDownList></th></p> 
        </tr>
      
        <tr>
            <p><th>Име:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtFirstName"  runat="server"></asp:TextBox></th></p>
        </tr>
        
        <tr>
             <p><th>Фамилия:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtLastName"  runat="server"></asp:TextBox></th></p>
        </tr>
        <tr>
             <p><th>Телефон:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtPhone"  runat="server"></asp:TextBox></th></p>
        </tr>
          <tr>
             <p><th>Адрес:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtAddress"  runat="server"></asp:TextBox></th></p>
        </tr>
          <tr>
             <p><th>Град:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtCity"  runat="server"></asp:TextBox></th></p>
        </tr>
          <tr>
             <p><th>Контакт:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtContact"  runat="server"></asp:TextBox></th></p>
        </tr>
          <tr>
             <p><th>Апартамент:&nbsp;&nbsp;&nbsp;</th><th><asp:DropDownList ID="ddl_Home" runat="server"></asp:DropDownList></th></p>
        </tr>
          <tr>
             <p><th>E-mail:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtEmail"  runat="server"></asp:TextBox></th></p>
          </tr>

      </tbody>
      </table>

       <table border="1" cellspacing="1" cellpadding="1">
          <tbody>
           <tr>
               <p><th>Бележки:&nbsp;&nbsp;&nbsp;</th><th><asp:TextBox ID="txtNotes" TextMode="MultiLine" runat="server"></asp:TextBox></th></p>
          </tr>
          <tr>
               <p><th>Съхрани:&nbsp;&nbsp;&nbsp;</th><th> <asp:ImageButton ID="btnSave" runat="server" ToolTip="Съхрани данните" src="Content/images/addButton.png" Text="Съхрани" onclick="btnSave_Click" /></th></p>
          </tr>
         </tbody>
       </table>
 
    </asp:Panel>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

