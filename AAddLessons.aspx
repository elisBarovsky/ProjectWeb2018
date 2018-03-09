<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AAddLessons.aspx.cs" Inherits="AAddLessons" %>

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
        <h2 style="text-align: right">ניהול מקצועות לימוד</h2>
        <br />
        <br />

        <table class="auto-style1" align="center">
         
            <tr>
           <td style="text-align: right">
               <asp:TextBox ID="LessonsNameTB" runat="server"></asp:TextBox>
           </td>
                <td style="text-align: right">
                  הזן שם מקצוע
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                     <asp:DropDownList ID="DDLlessons" runat="server" DataSourceID="subjects" DataTextField="LessonName" DataValueField="CodeLesson" AutoPostBack="True"></asp:DropDownList>
                     <asp:SqlDataSource ID="subjects" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [CodeLesson], [LessonName] FROM [Lessons] ORDER BY [LessonName]"></asp:SqlDataSource>
                </td>
                <td style="text-align: right">מקצועות קיימים</td>
            </tr>
      
        </table>
           <br /><br /><br />
            <asp:button id="AddLessonsBTN" runat="server" cssclass="form-btn" text="הוסף מקצוע" OnClick="AddLessonsBTN_Click"/>
</asp:Content>

