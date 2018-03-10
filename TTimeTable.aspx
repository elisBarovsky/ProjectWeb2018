<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TTimeTable.aspx.cs" Inherits="TTimeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <br /><br /><br />
    <asp:Label ID="className" runat="server" Text=""></asp:Label>
    <asp:table id = "TimeTable" runat="server" align="center">
        </asp:table>
</asp:Content>

