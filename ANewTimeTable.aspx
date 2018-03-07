<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="ANewTimeTable.aspx.cs" Inherits="timeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/Style.css" rel="stylesheet" />




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
  <h2 style="text-align: right">מערכת שעות</h2>
  <div class="btn-group" style=" position: relative;  left: 40%;">
    <asp:button runat="server" ID="updateB" class="btn btn-primary" text="עדכן מערכת" onclick="PreparePageToUpdate"></asp:button>
    <asp:button runat="server" ID="addB" class="btn btn-primary active" text="צור מערכת חדשה" onclick="PreparePageToAddNew"></asp:button>
  </div>
        <br /><br />
            <table>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddl_clases" runat="server" ondatabound="FillFirstItem" DataSourceID="DSclasses" DataTextField="TotalName" DataValueField="ClassCode"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Class" runat="server" ControlToValidate="ddl_clases" ErrorMessage="עליך לבחור כיתה" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="DSclasses" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT DISTINCT [ClassCode], [TotalName] FROM [Class] ORDER BY [TotalName]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        <div runat="server" id="AlertBox" class="alertBox" Visible="false">
            <div runat="server" id="AlertBoxMessage"></div>
            <button onclick="closeAlert.call(this, event)">Ok</button>
        </div>
        <asp:table id = "TimeTable" runat="server">
            <asp:TableRow>
                <asp:tableCell>שיעור</asp:tableCell>
                <asp:tableCell>ראשון</asp:tableCell>
                <asp:tableCell>שני</asp:tableCell>
                <asp:tableCell>שלישי</asp:tableCell>
                <asp:tableCell>רביעי</asp:tableCell>
                <asp:tableCell>חמישי</asp:tableCell>
                <asp:tableCell>שישי</asp:tableCell>
            </asp:TableRow>
        </asp:table>
        <br /><br />
        <asp:Button ID="ButtonSave" CssClass="form-btn"  runat="server" Text="שמור" visible="true" OnClick="ButtonSave_Click" />
        <asp:Button ID="ButtonUpdate" CssClass="form-btn"  runat="server" Text="עדכן" Visible="false"/>
        </div>
</asp:Content>

