<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AAddNewUser.aspx.cs" Inherits="AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            position: center;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2 style="text-align: right">ניהול משתמשים</h2>
        <div class="btn-group" style=" position: relative;  left: 40%;">
            <button type="button" class="btn btn-primary active" onclick="location.href = 'AAddNewUser.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary " onclick="location.href = 'AUpdateUser.aspx';">עדכון</button>
        </div>
        <br />
        <br />

        <table class="auto-style1">
            <tr>
                <td>
                    <asp:radiobuttonlist id="GroupAgeDLL" required="required" runat="server" datasourceid="SqlDataSource1" datatextfield="GroupName" datavaluefield="CodePgroup" repeatdirection="Horizontal"></asp:radiobuttonlist>
                    <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:Betsefer %>" selectcommand="SELECT [CodePgroup], [GroupName] FROM [PupilsGroup]"></asp:sqldatasource>

                    <asp:checkbox id="MainTeacherCB" runat="server" autopostback="true" oncheckedchanged="MainTeacherCB_CheckedChanged" />
                </td>
                <td>
                    <asp:label id="GroupAgeLBL" runat="server" text="קבוצת גיל"> </asp:label>
                    <asp:label id="MainTeacher" runat="server" text=" האם מחנך"></asp:label>
                </td>

                <td>
                    <asp:radiobuttonlist id="UserTypeDLL" runat="server" datasourceid="SqlDataSource2" onselectedindexchanged="UserTypeDLL_CheckedChanged" datatextfield="CodeUserName" datavaluefield="CodeUserType" autopostback="true" repeatdirection="Horizontal"></asp:radiobuttonlist>
                    <asp:sqldatasource id="SqlDataSource2" runat="server" connectionstring="<%$ ConnectionStrings:Betsefer %>" selectcommand="SELECT * FROM [UserType]"></asp:sqldatasource>
                </td>
                <td>
                    <asp:label id="Label1" runat="server" text="סוג משתמש"></asp:label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:textbox id="LNameTB" runat="server" required="required"></asp:textbox>
                </td>
                <td>שם משפחה</td>
                <td>
                    <asp:textbox id="FNameTB" runat="server" required="required"></asp:textbox>
                </td>
                <td>שם פרטי</td>
            </tr>
            <tr>
                <td>
                    <asp:textbox id="UserIDTB" runat="server" required="required"></asp:textbox>
                </td>
                <td>תעודת זהות</td>
                <td>
                    <asp:calendar id="Calendar1" runat="server" autopostback="false" />

                </td>
                <td>תאריך לידה</td>
            </tr>

            <tr>
                <td>
                    <asp:fileupload id="FileUpload1" runat="server" />
                </td>
                <td>תמונה</td>
                <td>
                    <asp:dropdownlist id="ClassOtDLL" runat="server" datasourceid="SqlDataSource3" datatextfield="TotalName" datavaluefield="ClassCode"></asp:dropdownlist>
                    <asp:sqldatasource id="SqlDataSource3" runat="server" connectionstring="<%$ ConnectionStrings:Betsefer %>" selectcommand="SELECT [ClassCode], [TotalName] FROM [Class]"></asp:sqldatasource>
                </td>
                <td>
                    <asp:label id="ClassLBL" runat="server" text=" בחר כיתה"></asp:label>


                </td>
            </tr>
            <tr>
                <td>
                    <asp:textbox id="PasswordTB" runat="server" required="required"></asp:textbox>
                </td>
                <td>סיסמה</td>
                <td>
                    <asp:textbox id="UserNameTB" runat="server" required="required"></asp:textbox>
                </td>
                <td>שם משתמש</td>
            </tr>

            <tr>
                <td>
                    <asp:textbox id="ChildIDTB" runat="server" required="required"></asp:textbox>
                </td>
                <td>
                    <asp:label id="ChildIDLBL" runat="server" text=" הזן תעודת זהות ילד"></asp:label>
                </td>
                <td>
                    <asp:textbox id="TelephoneNumberTB" runat="server" required="required"></asp:textbox>
                </td>
                <td>טלפון</td>

            </tr>

        </table>
        <br />
        <asp:button id="AddUserBTN" runat="server" cssclass="form-btn" text="הוסף משתמש" onclick="AddUserBTN_Click" />
        <asp:label id="MessegaeLBL" runat="server" text="" style="text-align: right"></asp:label>

    </div>
</asp:Content>

