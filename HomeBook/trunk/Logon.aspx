<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Logon.aspx.cs" Inherits="Login_Logon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
</head>
<body>
    <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div>
    
  <asp:Panel ID="pnlLogon" runat="server">
  <h3><font face="Verdana">Моля,въведете данни за вход!</font></h3>
<table border="1" cellspacing="1" cellpadding="1">
   <tr>
      <td>Име:</td>
      <td><input id="txtUserName" type="text" runat="server"></td>
      <td><ASP:RequiredFieldValidator ControlToValidate="txtUserName"
           Display="Static" ErrorMessage="*" runat="server" 
           ID="vUserName" /></td>
   </tr>
   <tr>
      <td>Парола:</td>
      <td><input id="txtUserPass" type="password" runat="server"></td>
      <td><ASP:RequiredFieldValidator ControlToValidate="txtUserPass"
          Display="Static" ErrorMessage="*" runat="server" 
          ID="vUserPass" />
      </td>
   </tr>
   <tr>
      <td>Използвай кокита:</td>
      <td><ASP:CheckBox id="chkPersistCookie" runat="server" autopostback="false" /></td>
      <td><input type="submit" Value="Влез" runat="server" ID="cmdLogin"></td>
   </tr>
</table>
  </asp:Panel>
<p></p>
<asp:Label id="lblMsg" ForeColor="red" Font-Name="Verdana" Font-Size="10" runat="server" />
    </div>

    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

