<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="ANewTimeTable.aspx.cs" Inherits="timeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/Style.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
  <h2>מערכת שעות</h2>
  <%--<p>The .btn-group class creates a button group:</p>--%>
  <div class="btn-group" style=" position: fixed;  left: 40%;">
    <button type="button" class="btn btn-primary" onclick="location.href = 'AUpdateTimeTable.aspx';" >עדכון מערכת שעות</button>
    <button type="button" class="btn btn-primary active"  onclick="location.href = 'ANewTimeTable.aspx';">יצירת מערכת שעות</button>
  </div>
            <table>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddl_clases" runat="server" ondatabound="FillFirstItem" DataSourceID="DSclasses" DataTextField="TotalName" DataValueField="ClassCode"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Class" runat="server" ControlToValidate="ddl_clases" ErrorMessage="עליך לבחור כיתה" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="DSclasses" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT DISTINCT [ClassCode], [TotalName] FROM [Class] ORDER BY [TotalName]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
           
        <asp:table id = "TimeTable" runat="server">
            <asp:TableRow>
                <asp:tableCell>שישי</asp:tableCell>
                <asp:tableCell>חמישי</asp:tableCell>
                <asp:tableCell>רביעי</asp:tableCell>
                <asp:tableCell>שלישי</asp:tableCell>
                <asp:tableCell>שני</asp:tableCell>
                <asp:tableCell>ראשון</asp:tableCell>
                <asp:tableCell>שיעור</asp:tableCell>
            </asp:TableRow>
        </asp:table>
        <br /><br />
        <asp:Button ID="ButtonSave" CssClass="form-btn"  runat="server" Text="שמור" OnClick="ButtonSave_Click" />
</div>
</asp:Content>

