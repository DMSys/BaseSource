<%@ Page Language="C#" MasterPageFile="~/design/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

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
  
    <nachoContent:Article ID="Article1" Caption="Какво представлява софтуера домова книга" runat="server"><ContentTemplate>
    <img src="Content/images/preview.jpg" alt="an image" style="float:left;" />
    
    <p>
      <p> Домова книга многофункционална е онлайн базирана безплатна система, която може да се достъпва отвсякъде и не изисква инсталация.
        Нашата цел е да подпомогнем домоуправителите и касиерите на големи жилищни сгради ,като им предоставим възможност да изградят електронен вариант на хартиената домова книга,
        като това не изисква никакви професионални умения.<p>
      <p>   	
    </p>
            <span class="nacho-button-wrapper">
    		<span class="nacho-button-l"> </span>
    		<span class="nacho-button-r"> </span>
    	
    	</span>
    <div class="cleared"></div>
   
 </ContentTemplate>

</nachoContent:Article>
    <nachoContent:Article ID="Article2" Caption="Какво предлагаме" runat="server"><ContentTemplate>
    
 <p>
     <p>Програмата ви предлага следните възможности: </p> 
              <p>    • да следите приходите и разходите на сградата </p>
              <p>    • баланс на касата и бюджета </p>
              <p>    • справка кой за какво кога и колко пари е внесъл в касата </p>
              <p>    • възможност и други хора да следят книгата без да могат да я променят </p>
              <p>    • удобен за принтиране списък с въведените апартаменти</p>
     
     </p>
   
 
   </ContentTemplate>

     </nachoContent:Article>
    <nachoContent:Article ID="Article3" Caption="За нас" runat="server"><ContentTemplate>
           <div class="nacho-content-layout overview-table">
    	<div class="nacho-content-layout-row">
    		<div class="nacho-layout-cell">
          <div class="overview-table-inner">
    	      <h4>Поддръжка</h4>
    						  <img src="Content/images/01.png" width="55" height="55" alt="an image" class="image" />
    						  <p>
                                  Предлагаме ви качествена поддръжка на софтуерa 
                                  и съхранение на вашите данни.</p>
           
           </div>
    		</div><!-- end cell -->
    		<div class="nacho-layout-cell">
        <div class="overview-table-inner">
    		  <h4>Въпроси</h4>
    						  <img src="Content/images/02.png" width="55" height="55" alt="an image" class="image" />
    						  <p>Очакваме Вашите въпроси и сме готови винаги да Ви отговорим за да получите максимален отговор. 
                                Пишете на онлайн формата в таб "За нас".</p>
    				</div>
    		</div><!-- end cell -->
    		<div class="nacho-layout-cell">
        <div class="overview-table-inner">
    		  <h4>Стратегия</h4>
    
    						  <img src="Content/images/03.png" width="55" height="55" alt="an image" class="image" />
    						  <p>Онлайн базираният софтуер Домова книга е част от стратегия за попълване на празнините в ИТ 
                                  сектора за създаване на качествен и лесен за употреба софтуер.</p>
                  </div>
    		</div><!-- end cell -->
    	</div><!-- end row -->
    </div><!-- end table -->
          </ContentTemplate>
    </nachoContent:Article>
  
</asp:Content>
