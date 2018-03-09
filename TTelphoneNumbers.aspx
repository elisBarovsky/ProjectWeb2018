<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TTelphoneNumbers.aspx.cs" Inherits="TTelphoneNumbers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2 style="text-align: center">דף קשר</h2>
        <table class="auto-style2" align="right">
            <tr>
                <td>
                    <asp:Button ID="TLBTN" runat="server" Text="צפה" CssClass="form-btn" OnClick="TLBTN_Click" /></td>
                <td align="left" class="auto-style1">
                    <asp:RadioButtonList ID="FilterNotes" runat="server" RepeatDirection="Horizontal" Width="349px">
                        <asp:ListItem Text="הורים" Value="3" />
                        <asp:ListItem Text="תלמידים" Value="4" />
                    </asp:RadioButtonList></td>
                <td class="auto-style1" align="left">
                    <asp:Label ID="Label1" runat="server" Text="בחר קבוצה"></asp:Label>
                </td>
                <td></td>
                <td align="right" class="auto-style1">
                    <asp:DropDownList ID="ChooseClassDLL" runat="server"></asp:DropDownList></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Class" runat="server" ControlToValidate="ChooseClassDLL" ErrorMessage="עליך לבחור כיתה" InitialValue="0"></asp:RequiredFieldValidator>
                <td align="right" class="auto-style1">בחר כיתה</td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BorderStyle="Dashed" HeaderStyle-HorizontalAlign="Right">
                        <PagerStyle HorizontalAlign="Right" />
                        <RowStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

