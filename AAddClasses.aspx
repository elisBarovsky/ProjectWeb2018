<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AAddClasses.aspx.cs" Inherits="AAddClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .auto-style1 {
            width: 240px;
            height: 94px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="container">
        <h2 style="text-align: right">ניהול כיתות</h2>
        <br />
        <br />

        <table class="auto-style1" align="center">
         
            <tr>
           <td style="text-align: right">
               <asp:DropDownList ID="OtClassDDL" runat="server"></asp:DropDownList>
           </td>
                <td style="text-align: right">
                   בחר כיתה
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                     <asp:DropDownList ID="NumClassDDL" runat="server"></asp:DropDownList>
                </td>
                <td style="text-align: right">בחר מספר כיתה</td>
            </tr>
      
        </table>
           <br /><br /><br />
            <asp:button id="AddClassBTN" runat="server" cssclass="form-btn" text="הוסף כיתה" OnClick="AddClassBTN_Click"/>
       
      

    </div>
</asp:Content>

