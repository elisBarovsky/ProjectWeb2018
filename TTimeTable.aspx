<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TTimeTable.aspx.cs" Inherits="TTimeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        .table tr th {
            width: 30PX !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="container">
        <h2 style="text-align: center">מערכת שעות</h2>
          <br />
         <div style="text-align:center;color:palevioletred;font-size:20px" dir="rtl">
              <asp:Label ID="className" runat="server" Text="" CssClass="glyphicon-text-color:red"></asp:Label>
             <br /><br />
         </div>
           
    <asp:table id = "TimeTable" runat="server" align="center" BorderStyle="Dashed" HeaderStyle-HorizontalAlign="Right" CellPadding="3" CellSpacing="3" GridLines="Both" HorizontalAlign="Center">
  
        </asp:table>
    </div>      
</asp:Content>

