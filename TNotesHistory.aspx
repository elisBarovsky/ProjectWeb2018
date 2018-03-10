<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TNotesHistory.aspx.cs" Inherits="TNotesHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 0;

        }

        .auto-style2 {
            width: 80%;
            height: 43px;
            margin-right: 0;
            position: center;
        }

 
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2 style="text-align: center">הערות משמעת</h2>
        <div class="btn-group" style="position: relative; left: 40%;">
            <button type="button" class="btn btn-primary " onclick="location.href = 'TNotesInsert.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary active" onclick="location.href = 'TNotesHistory.aspx';">צפייה</button>
        </div>
        <table class="auto-style2" align="right">
            <tr>
                <td align="right">
                    <asp:DropDownList ID="ChooseLessonsDLL" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="NotesDLL" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="PupilsDLL" runat="server" AutoPostBack="true" CssClass="auto-style1"></asp:DropDownList>
                    <asp:DropDownList ID="ChooseClassDLL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FillPupils"></asp:DropDownList></td>
                <td align="right">
                    <asp:RadioButtonList ID="FilterNotes" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="FilterNotes_SelectedIndexChanged" Width="365px">
                        <asp:ListItem Text="מקצוע" Value="1" />
                        <asp:ListItem Text="הערת משמעת" Value="2" />
                        <asp:ListItem Text="תלמיד" Value="3" />
                        <asp:ListItem Text="הערות שניתנו על ידך" Value="4" />
                    </asp:RadioButtonList></td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="כיצד תרצה לסנן  "></asp:Label>
                </td>
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
        <br />

        <asp:Button ID="FilterNotesBTN" runat="server" CssClass="form-btn" Text="סנן" OnClick="FilterNotesBTN_Click" />
    </div>
</asp:Content>

