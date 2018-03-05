<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TNotesHistory.aspx.cs" Inherits="TNotesHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 0;
        }
        .auto-style2 {
            width: 1124px;
            height: 43px;
            margin-right: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2 style="text-align: right">הערות משמעת</h2>
        <div class="btn-group" style="position: relative; left: 40%;">
            <button type="button" class="btn btn-primary " onclick="location.href = 'TNotesInsert.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary active" onclick="location.href = 'TNotesHistory.aspx';">צפייה</button>
        </div>
        <br />
        <br />
        <table class="auto-style2">
            <tr>
                  <td>
                    <asp:DropDownList ID="ChooseLessonsDLL" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="NotesDLL" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="PupilsDLL" runat="server" AutoPostBack="true" CssClass="auto-style1"></asp:DropDownList>
                <td>
                    <asp:RadioButtonList ID="FilterNotes" runat="server" repeatdirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="FilterNotes_SelectedIndexChanged">
                        <asp:ListItem Text="מקצוע" Value="1" />
                        <asp:ListItem Text="הערת משמעת" Value="2" />
                        <asp:ListItem Text="תלמיד" Value="3" />
                         <asp:ListItem Text="הערות שניתנו על ידך" Value="4" />
                    </asp:RadioButtonList></td>
                <td>כיצד תרצה לסנן
                </td>
            
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                </td>
            </tr>
            </table>
        <br />
        <%--   <asp:button id="AddNotes" runat="server" cssclass="form-btn" text="הוסף הערת משמעת"   />
        <asp:label id="MessegaeLBL" runat="server" text="" style="text-align: right"></asp:label>--%>
    </div>
</asp:Content>

