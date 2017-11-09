<%@ Page Title="Вход" Language="C#" MasterPageFile="~/design/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Public_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContentPlaceHolder" runat="Server">
    Вход
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptIncludePlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SheetContentPlaceHolder" runat="Server">
    <div style="padding-left: 30%; padding-top:30px; padding-bottom: 30px;">
        <asp:Login ID="logInHBook" runat="server">
            <LayoutTemplate>
                <table>
                    <tr>
                        <td align="center"><h3>Вход</h3></td>
                    </tr>
                    <tr>
                        <td>Въведете потребителското име и парола!</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>Потребителското име:</td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" Text="demo"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" Text="* Потребителското име е задължително"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Парола:</td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Text=""></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" Text="* Паролата е задължителна"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Запомни ме"></asp:CheckBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="Login" CommandName="Login" runat="server" Text="Вход" OnClick="Login_Click"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>
    </div>
</asp:Content>

