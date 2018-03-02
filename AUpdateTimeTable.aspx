<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AUpdateTimeTable.aspx.cs" Inherits="UpdateTimeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="container">
  <h2 style="text-align: right">מערכת שעות</h2>
  <div class="btn-group" style=" position: relative;  left: 40%;">
    <button type="button" class="btn btn-primary active" onclick="location.href = 'AUpdateTimeTable.aspx';" >עדכון מערכת שעות</button>
    <button type="button" class="btn btn-primary "  onclick="location.href = 'ANewTimeTable.aspx';">יצירת מערכת שעות</button>
  </div>
</div>
</asp:Content>

