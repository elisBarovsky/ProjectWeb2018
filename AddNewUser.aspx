<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AddNewUser.aspx.cs" Inherits="AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="container">
  <h2>ניהול משתמשים</h2>
  <%--<p>The .btn-group class creates a button group:</p>--%>
  <div class="btn-group">
    <button type="button" class="btn btn-primary active" onclick="location.href = 'AddNewUser.aspx';" >הוספה  </button>
    <button type="button" class="btn btn-primary "  onclick="location.href = 'UpdateUser.aspx';">עדכון</button>
  </div>


</div>
</asp:Content>

