﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="THomeWorkInsert.aspx.cs" Inherits="THomeWorkInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            position: center;
        }

        .auto-style2 {
            left: 0px;
            top: 0px;
            width: 1032px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2 style="text-align: right">שיעורי בית</h2>
        <div class="btn-group" style="position: relative; left: 40%;">
            <button type="button" class="btn btn-primary active" onclick="location.href = 'THomeWorkInsert.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary " onclick="location.href = 'THomeWorkHistory.aspx';">צפייה</button>
        </div>
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:DropDownList ID="ChooseLessonsDLL" runat="server"></asp:DropDownList>
                </td>
                <td>בחר מקצוע</td>
                <td>
                    <asp:DropDownList ID="ChooseClassDLL" runat="server" ></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="ClassLBL" runat="server" Text=" בחר כיתה"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="HomeWorkDesc" runat="server" required="required" CssClass="auto-style2" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>תוכן שיעורים</td>
            </tr>

            <tr>
                <td aline="right">
                    <asp:CheckBox ID="ChangeHagashaCB" runat="server" Text="האם השיעורים להגשה?" />
                </td>
                <td></td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" autopostback="false" />
                </td>
                <td>לביצוע עד תאריך </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="AddUserBTN" runat="server" CssClass="form-btn" Text="הוסף שיעורי בית" OnClick="AddUserBTN_Click" />
        <asp:Label ID="MessegaeLBL" runat="server" Text="" Style="text-align: right"></asp:Label>

    </div>


</asp:Content>

