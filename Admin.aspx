<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Image ID="AdminIMG" runat="server"  Width="151px" Style="position: relative; left: 7%" />
    <asp:Label ID="AdminNameLBL" runat="server" Text=""  Style="position: relative; left: 10%;font-size:25px;font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;color:lightseagreen"></asp:Label>

    <br /> <br /> <br /> <br /> <br />
    <asp:Label ID="Label1" runat="server" Text="הודעות" Style="position: relative; left: 87%;"></asp:Label>
    <asp:Table ID="Table1" runat="server"></asp:Table>


</asp:Content>

