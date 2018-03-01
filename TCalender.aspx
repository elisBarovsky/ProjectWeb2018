<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TCalender.aspx.cs" Inherits="TCalender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align: center;vertical-align: middle;"> 
<iframe  src="https://calendar.google.com/calendar/embed?showTitle=0&amp;height=600&amp;wkst=1&amp;hl=iw&amp;bgcolor=%23ffffff&amp;src=iw.jewish%23holiday%40group.v.calendar.google.com&amp;color=%2329527A&amp;ctz=Asia%2FJerusalem" align="middle" style="border-width:0" width="800" height="600" frameborder="0" scrolling="no"  ; ></iframe>
</div>
</asp:Content>

