<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TGradesInsert.aspx.cs" Inherits="TGrades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
          .auto-style1 {
              width:100%;
              position: center;
          }

        table{
       align-self :center;
    width: 80%;
    border-collapse:collapse;
    table-layout: fixed;
}
.DDL_TD{
    border: 2px solid #92a8d1;
}
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <h2 style="text-align: center">ציונים</h2>
        <div class="btn-group" style=" position: relative;  left: 40%;">
            <button type="button" class="btn btn-primary active" onclick="location.href = 'TGradesInsert.aspx';">הוספה  </button>
<%--            <button type="button" class="btn btn-primary " onclick="location.href = 'TGradesUpdate.aspx';">עדכון</button>--%>
        </div>
        <br />
        <br />
          <table class="auto-style1">
            <tr>
                <td>
                    <asp:DropDownList ID="ChooseClassDLL" style="direction:rtl;" runat="server" AutoPostBack="True" Visible="false" ondatabound="FillFirstItem" OnSelectedIndexChanged="FillPupils" DataSourceID="DSclasses" DataTextField="TotalName" DataValueField="ClassCode"></asp:DropDownList>
                    <asp:SqlDataSource ID="DSclasses" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [ClassCode], [TotalName] FROM [Class]"></asp:SqlDataSource>
                </td>
                

                <td><asp:DropDownList ID="ChooseLessonsDLL"  style="direction:rtl;" runat="server" AutoPostBack="true" DataSourceID="DSsubjects" ondatabound="FillFirstItem" Visible="true" DataTextField="LessonName" DataValueField="CodeLesson" OnSelectedIndexChanged="ChooseLessonsDLL_SelectedIndexChanged" ></asp:DropDownList>
                    <asp:SqlDataSource ID="DSsubjects" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [CodeLesson], [LessonName] FROM [Lessons]"></asp:SqlDataSource>
                </td>
                
            </tr>
            <tr>
                <td>
                </td>
                <td></td>
                <td align="center" style="margin:auto">
                     <asp:calendar id="Calendar1" runat="server" autopostback="false" />
                </td>
                <td>תאריך בחינה</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <br />
                    <br />
                    <asp:Table ID="tableGrades" runat="server" ></asp:Table>
                    <br />
                </td>
            </tr>
        </table>
        <br />
        <asp:button id="AddGrades" runat="server" cssclass="form-btn" text="הוסף ציונים" OnClick="AddGrades_Click"  />
        <asp:label id="MessegaeLBL" runat="server" text="" style="text-align: right"></asp:label>
         </div>
</asp:Content>

