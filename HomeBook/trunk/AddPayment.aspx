<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPayment.aspx.cs" Inherits="AddPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
 <script type="text/javascript" src="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/jquery-ui.min.js"></script>
 <script type="text/javascript" src="Scripts/jquery.ui.datepicker-bg"></script>
<script type="text/javascript">
    var $d = jQuery.noConflict();
    $d(document).ready(function () {

        $d('#txtDatePayment').datepicker({
            duration: '',
            showTime: true,
            constrainInput: false,
            dateFormat: "dd.mm.yy"
           
        });

    });
    </script>

<style type = "text/css">
.ui-datepicker { font-size:9pt !important}
</style>

 <link type="text/css" rel="Stylesheet" href="http://ajax.microsoft.com/ajax/jquery.ui/1.8.6/themes/smoothness/jquery-ui.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style2 {
            width: 151px;
        }
        .auto-style3 {
            width: 157px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <h3>Въведете вашите данни</h3>
        <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
        <asp:Panel ID="pnlEdit" runat="server">

      <table border="1" cellspacing="1" cellpadding="1" >
      <tbody>
        

      </tbody>
          <caption>
              <p>
                   
                  <caption>
                      <p> 
                     <tr>
                      <th>Относно:&nbsp;&nbsp;&nbsp;</th>
                      <th>
                          <asp:TextBox ID="txtNamePayment" runat="server" ></asp:TextBox>
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
                                  
                                  <caption>
                                      <p>
                                          <tr>
                                              <th>Семейство:&nbsp;&nbsp;&nbsp;</th>
                                              <th>
                                                  <asp:DropDownList ID="ddl_Home"  width="100%" runat="server" style="margin-left: 0px"></asp:DropDownList>
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
                                                      <th>Сума:&nbsp;&nbsp;&nbsp;</th>
                                                      <th>
                                                          <asp:TextBox ID="txtIncome" runat="server"></asp:TextBox>
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
                                                              <th>Дата:&nbsp;&nbsp;&nbsp;</th>
                                                              <th>
                                                                  <div id="ui-datepicker"><asp:TextBox ID="txtDatePayment" runat="server"></asp:TextBox></div>
                                                                  
                                                              </th>
                                                              <caption>
                                                                  <p>
                                                                  </p>
                                                              </caption>
                                                           
                                                          </tr>
                                                          <caption>
                                                              <p>
                                                                  <tr>
                                                                      <th>Тип:&nbsp;&nbsp;&nbsp;</th>
                                                                      <th>
                                                                          <asp:DropDownList ID="ddlTypePayment"  width="100%" runat="server">
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
                                                                              <th>Контакт:&nbsp;&nbsp;&nbsp;</th>
                                                                              <th>
                                                                                  <asp:DropDownList ID="ddlContactor"  width="100%" runat="server">
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
                                                                          </tbody>
                                                                          <caption>
                                                                              <p>
                                                                              </p>
                                                                          </caption>
                                                                          <caption>
                                                                              <p>
                                                                              </p>
                                                                              <p>
                                                                              </p>
                                                                          </caption>
                                                                          <caption>
                                                                              <p>
                                                                              </p>
                                                                              <p>
                                                                              </p>
                                                                              <p>
                                                                              </p>
                                                                              <caption>
                                                                                  <p>
                                                                                  </p>
                                                                                  <p>
                                                                                  </p>
                                                                                  <p>
                                                                                  </p>
                                                                                  <p>
                                                                                  </p>
                                                                                  <caption>
                                                                                      <p>
                                                                                      </p>
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

       <table border="1" cellspacing="1" cellpadding="1">
          <tbody>
         </tbody>
           <caption>
               <p>
                   <tr>
                       <th>Бележки:&nbsp;&nbsp;&nbsp;</th>
                       <th class="auto-style3">
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
                               <th>Съхрани:&nbsp;&nbsp;&nbsp;</th>
                               <th class="auto-style3">
                                   <asp:ImageButton ID="btnSave" runat="server" src="Content/images/addButton.png" style="" Text="Съхрани" ToolTip="Съхрани данните" Width="" OnClick="btnSave_Click" />
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
                           </caption>
                           <caption>
                               <p>
                               </p>
                               <p>
                               </p>
                           </caption>
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

