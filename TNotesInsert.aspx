<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TNotesInsert.aspx.cs" Inherits="TNotesInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            position: center;
             width: 80%;
        }
        .auto-style2 {
            left: 0px;
            top: -37px;
            margin-top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
        <h2 style="text-align: center">הערות משמעת</h2>
        <div class="btn-group" style=" position: relative;  left: 40%;">
            <button type="button" class="btn btn-primary active" onclick="location.href = 'TNotesInsert.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary " onclick="location.href = 'TNotesHistory.aspx';">צפייה</button>
        </div>
        <br />
        <br />
          <table class="auto-style1">
            <tr>
                <td>
                   <asp:DropDownList ID="ChooseClassDLL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FillPupils"></asp:DropDownList>
                </td>
                <td>
                    
                    בחר כיתה
                </td>
                <td><asp:DropDownList ID="ChooseLessonsDLL" runat="server" ></asp:DropDownList>
                </td>
                <td>בחר מקצוע
                </td>

            </tr>
                <tr>
                      <td><asp:DropDownList ID="NotesDLL" runat="server" ></asp:DropDownList>
                </td>
                <td>בחר הערת משמעת
                </td>
                <td>
                    <asp:DropDownList ID="PupilsDLL" runat="server"  ></asp:DropDownList>
                </td>
                <td>בחר תלמיד
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="TNoteTB" runat="server" CssClass="auto-style2" TextMode="MultiLine" Height="52px" Width="1036px"></asp:TextBox>
                </td>
                <td> הערת המורה</td>
            </tr>
            </table>
        <br />
        <asp:button id="AddNotes" runat="server" cssclass="form-btn" text="הוסף הערת משמעת" OnClick="AddNotes_Click"   />
        <asp:label id="MessegaeLBL" runat="server" text="" style="text-align: right"></asp:label>
        </div>
</asp:Content>

