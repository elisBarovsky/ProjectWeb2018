<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="ATimeTable.aspx.cs" Inherits="timeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/Style.css" rel="stylesheet" />
    <style>
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
  <h2 style="text-align: center">מערכת שעות</h2>
  <div class="btn-group" style=" position: relative;  left: 40%;">
    <asp:button runat="server" ID="updateB" class="btn btn-primary" text="עדכן מערכת" onclick="PreparePageToUpdate"></asp:button>
    <asp:button runat="server" ID="addB" class="btn btn-primary active" text="צור מערכת חדשה" onclick="PreparePageToAddNew"></asp:button>
  </div>
        <br /><br />
            <table>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddl_clasesAdd" runat="server" ondatabound="FillFirstItem" DataSourceID="DSclassesForAdd" DataTextField="TotalName" DataValueField="ClassCode" OnSelectedIndexChanged="ddl_clases_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        <asp:SqlDataSource ID="DSclassesForAdd" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT ClassCode, TotalName FROM Class WHERE (ClassCode NOT IN (SELECT Class_1.ClassCode FROM Class AS Class_1 INNER JOIN Timetable ON Class_1.ClassCode = Timetable.ClassCode))"></asp:SqlDataSource>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_clasesEdit" runat="server" ondatabound="FillFirstItem" DataSourceID="DSclassesForEdit" DataTextField="TotalName" DataValueField="ClassCode" OnSelectedIndexChanged="ddl_clases_SelectedIndexChanged" AutoPostBack="True" Visible="false"></asp:DropDownList>
                        <asp:SqlDataSource ID="DSclassesForEdit" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT Class.ClassCode, Class.TotalName FROM Class INNER JOIN Timetable ON Class.ClassCode = Timetable.ClassCode AND Class.ClassCode = Timetable.ClassCode
                                                order by Class.TotalName">
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>

        <div runat="server" id="AlertBox" class="alertBox" Visible="false">
            <div runat="server" id="AlertBoxMessage"></div>
            <button onclick="closeAlert.call(this, event)">Ok</button>
        </div>
        <asp:table id = "TimeTable" runat="server" align="center">
        </asp:table>
        <br /><br />
        <asp:Button ID="ButtonSave" CssClass="form-btn"  runat="server" Text="שמור" visible="true" OnClick="ButtonSave_Click" />
        <asp:Button ID="ButtonUpdate" CssClass="form-btn"  runat="server" Text="עדכן" Visible="false" OnClick="ButtonUpdate_Click"/>
        </div>
</asp:Content>

