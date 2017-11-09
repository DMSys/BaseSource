<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddApartaments.aspx.cs" Inherits="AddApartaments" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style3 {
            width: 134px;
        }
        .auto-style4 {
            width: 143px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <center><h3>Добавете данни</h3> <center>
         <center><asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label> <center>
        <asp:Panel ID="pnlEdit" runat="server">

      <table border="1" cellspacing="1" cellpadding="1" >
      <tbody>
        
      </tbody>
          <caption>
              <p>
                  <tr>
                      <th>Статус:&nbsp;&nbsp;&nbsp;</th>
                      <th>
                          <asp:DropDownList ID="ddl_Status" runat="server" width="100%">
                          </asp:DropDownList>
                      </th>
                      <caption>
                          <p>
                          </p>
                      </caption>
                      <caption>
                          <p>
                          </p>
                      </caption>
                  </tr>
                  <caption>
                      <p>
                          <tr>
                              <th>Апарт.:&nbsp;&nbsp;&nbsp;</th>
                              <th>
                                  <asp:TextBox ID="txtHome" runat="server"></asp:TextBox>
                              </th>
                              <caption>
                                  <p>
                                  </p>
                              </caption>
                              <caption>
                                  <p>
                                  </p>
                              </caption>
                          </tr>
                          <caption>
                              <p>
                                  <tr>
                                      <th>Етаж:&nbsp;&nbsp;&nbsp;</th>
                                      <th>
                                          <asp:TextBox ID="txtFloor" runat="server"></asp:TextBox>
                                      </th>
                                      <caption>
                                          <p>
                                          </p>
                                      </caption>
                                      <caption>
                                          <p>
                                          </p>
                                      </caption>
                                  </tr>
                                  <caption>
                                      <p>
                                          <tr>
                                              <th>Брой:&nbsp;&nbsp;&nbsp;</th>
                                              <th>
                                                  <asp:TextBox ID="txtPeople" runat="server"></asp:TextBox>
                                              </th>
                                              <caption>
                                                  <p>
                                                  </p>
                                              </caption>
                                              <caption>
                                                  <p>
                                                  </p>
                                              </caption>
                                          </tr>
                                          <caption>
                                              <p>
                                                  <tr>
                                                      <th>Номер:&nbsp;&nbsp;&nbsp;</th>
                                                      <th>
                                                          <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                                                      </th>
                                                      <caption>
                                                          <p>
                                                          </p>
                                                      </caption>
                                                      <caption>
                                                          <p>
                                                          </p>
                                                      </caption>
                                                  </tr>
                                                  <caption>
                                                      <p>
                                                          <tr>
                                                              <th>Дял:&nbsp;&nbsp;&nbsp;</th>
                                                              <th>
                                                                  <asp:TextBox ID="txtPercent" runat="server"></asp:TextBox>
                                                              </th>
                                                              <caption>
                                                                  <p>
                                                                  </p>
                                                              </caption>
                                                              <caption>
                                                                  <p>
                                                                  </p>
                                                              </caption>
                                                          </tr>
                                                          <caption>
                                                              <p>
                                                                  <tr>
                                                                      <th>Контакт:&nbsp;&nbsp;&nbsp;</th>
                                                                      <th>
                                                                          
                                                                           <asp:DropDownList ID="ddlContact" runat="server" width="100%">
                                                                           </asp:DropDownList>
                                                                      </th>
                                                                      <caption>
                                                                          <p>
                                                                          </p>
                                                                      </caption>
                                                                      <caption>
                                                                          <p>
                                                                          </p>
                                                                      </caption>
                                                                  </tr>
                                                                  <caption>
                                                                      <p>
                                                                          <tr>
                                                                              <th>Телефон:&nbsp;&nbsp;&nbsp;</th>
                                                                              <th>
                                                                                  <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                                                              </th>
                                                                              <caption>
                                                                                  <p>
                                                                                  </p>
                                                                              </caption>
                                                                              <caption>
                                                                                  <p>
                                                                                  </p>
                                                                              </caption>
                                                                          </tr>
                                                                          <caption>
                                                                              <p>
                                                                                  <tr>
                                                                                      <th>E-mail:&nbsp;&nbsp;&nbsp;</th>
                                                                                      <th>
                                                                                          <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                                                      </th>
                                                                                      <caption>
                                                                                          <p>
                                                                                          </p>
                                                                                      </caption>
                                                                                      <caption>
                                                                                          <p>
                                                                                          </p>
                                                                                      </caption>
                                                                                  </tr>
                                                                                  </tbody>
                                                                                  <caption>
                                                                                      <p>
                                                                                      </p>
                                                                                      <caption>
                                                                                          <p>
                                                                                          </p>
                                                                                          <p>
                                                                                          </p>
                                                                                          <caption>
                                                                                              <p>
                                                                                              </p>
                                                                                              <p>
                                                                                              </p>
                                                                                          </caption>
                                                                                          <p>
                                                                                          </p>
                                                                                          <p>
                                                                                          </p>
                                                                                          <p>
                                                                                          </p>
                                                                                      </caption>
                                                                                      <p>
                                                                                      </p>
                                                                                      <p>
                                                                                      </p>
                                                                                      <p>
                                                                                      </p>
                                                                                  </caption>
                                                                                  <p>
                                                                                  </p>
                                                                                  <p>
                                                                                  </p>
                                                                                  <p>
                                                                                  </p>
                                                                              </p>
                                                                          </caption>
                                                                          <p>
                                                                          </p>
                                                                          <p>
                                                                          </p>
                                                                          <p>
                                                                          </p>
                                                                      </p>
                                                                  </caption>
                                                                  <p>
                                                                  </p>
                                                                  <p>
                                                                  </p>
                                                                  <p>
                                                                  </p>
                                                              </p>
                                                          </caption>
                                                          <p>
                                                          </p>
                                                          <p>
                                                          </p>
                                                          <p>
                                                          </p>
                                                      </p>
                                                  </caption>
                                                  <p>
                                                  </p>
                                                  <p>
                                                  </p>
                                              </p>
                                          </caption>
                                          <p>
                                          </p>
                                      </p>
                                  </caption>
                                  <p>
                                  </p>
                              </p>
                          </caption>
                      </p>
                  </caption>
              </p>
          </caption>
      </table>

       <table border="1" cellspacing="1" cellpadding="1" >
          <tbody>
         </tbody>
           <caption>
               <p>
                   <tr>
                       <th>Бележки:&nbsp;&nbsp;&nbsp;</th>
                       <th class="auto-style4">
                           <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" width="90%"></asp:TextBox>
                       </th>
                       <caption>
                           <p>
                           </p>
                       </caption>
                       <caption>
                           <p>
                           </p>
                       </caption>
                   </tr>
                   <caption>
                       <p>
                           <tr>
                               <th>Добави:&nbsp;&nbsp;&nbsp;</th>
                               <th class="auto-style4">
                                   <asp:ImageButton ID="btnSave" runat="server" onclick="btnSave_Click" src="Content/images/addButton.png" Text="Съхрани" ToolTip="Добави данните" />
                               </th>
                               <caption>
                                   <p>
                                   </p>
                               </caption>
                               <caption>
                                   <p>
                                   </p>
                               </caption>
                           </tr>
                           </tbody>
                           <caption>
                               <p>
                               </p>
                               <caption>
                                   <p>
                                   </p>
                                   <p>
                                   </p>
                                   <caption>
                                       <p>
                                       </p>
                                   </caption>
                                   <p>
                                   </p>
                               </caption>
                               <p>
                               </p>
                           </caption>
                       </p>
                   </caption>
               </p>
           </caption>
       </table>
 
    </asp:Panel>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
