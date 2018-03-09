<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AUpdateUser.aspx.cs" Inherits="UpdateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 80%;
            position: center;
        }

    </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2 style="text-align: center">ניהול משתמשים</h2>
        <div class="btn-group" style="position: relative; left: 45%;">
            <button type="button" class="wrapper btn btn-primary " onclick="location.href = 'AAddNewUser.aspx';">הוספה  </button>
            <button type="button" class="wrapper btn btn-primary active " onclick="location.href = 'AUpdateUser.aspx';">עדכון</button>
        </div>
        <br />
        <br />


        <table class="auto-style1" align="center">
            <tr>
                <td >
                    <asp:DropDownList ID="ClassOt1DLL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FillPupils"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [ClassCode], [TotalName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:Label ID="Class1LBL" runat="server" Text=" בחר כיתה"></asp:Label>
                </td>

                <td>
                    <asp:RadioButtonList ID="UserTypeDLL" runat="server" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="UserTypeDLL_CheckedChanged" DataTextField="CodeUserName" DataValueField="CodeUserType" AutoPostBack="true" RepeatDirection="Horizontal"></asp:RadioButtonList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT * FROM [UserType]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="סוג משתמש"></asp:Label></td>
            </tr>
            <tr>
                <td >
                    <asp:Image ID="UserIMG" runat="server" />
                </td>
                <td></td>
                <td>
                    <asp:DropDownList ID="PupilDLL" runat="server" OnSelectedIndexChanged="UserChosed" AutoPostBack="true"></asp:DropDownList>
                    <asp:DropDownList ID="OtherUsersDLL" runat="server" OnSelectedIndexChanged="UserChosed" AutoPostBack="true"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="ChoosePupilLBL" runat="server" Text="בחר תלמיד"></asp:Label>
                    <asp:Label ID="ChooseOtherUsers" runat="server" Text="בחר משתמש"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td></td>
                <td></td>
                <td>עדכון פרטים</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="LNameTB" runat="server" required="required"></asp:TextBox></td>
                <td>שם משפחה</td>
                <td>
                    <asp:TextBox ID="FNameTB" runat="server" required="required"></asp:TextBox></td>
                <td>שם פרטי</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:TextBox ID="UserIDTB" runat="server" required="required"></asp:TextBox></td>
                <td>תעודת זהות</td>
                <td>
                    <asp:TextBox ID="BirthDateTB" runat="server" required="required"></asp:TextBox>
                    <br />
                    <asp:CheckBox ID="ChangeBdateCB" runat="server" Text="האם תרצה לשנות תאריך לידה?" OnCheckedChanged="ShowCalendar_" AutoPostBack="true" />
                    <asp:Calendar ID="Calendar1" runat="server" AutoPostBack="false" OnSelectionChanged="FillTBofBdate" />

                </td>
                <td>תאריך לידה</td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                <td>תמונה</td>
                <td>
                    <asp:TextBox ID="TelephoneNumberTB" runat="server" required="required"></asp:TextBox>
                </td>
                <td>טלפון 
                </td>
            </tr>
            <tr>
                <td >
                    <asp:DropDownList ID="NumChildDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="NumChildDDL_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                <td> <asp:Label ID="NumChildLBL" runat="server" Text="מספר ילדים"></asp:Label>   </td>
                <td ><asp:TextBox ID="PasswordTB" runat="server" required="required"></asp:TextBox>
                   </td>
                <td>סיסמה</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="ChildI1DTB" runat="server" required="required"></asp:TextBox><br />
                     <asp:TextBox ID="ChildI2DTB" runat="server" required="required"></asp:TextBox><br />
                     <asp:TextBox ID="ChildI3DTB" runat="server" required="required"></asp:TextBox><br />
                     <asp:TextBox ID="ChildI4DTB" runat="server" required="required"></asp:TextBox><br />
                     <asp:TextBox ID="ChildI5DTB" runat="server" required="required"></asp:TextBox><br />
                     <asp:TextBox ID="ChildI6DTB" runat="server" required="required"></asp:TextBox>
                    <asp:RadioButtonList ID="GroupAgeDLL" runat="server" RepeatDirection="Horizontal" DataSourceID="SqlDataSource5" DataTextField="GroupName" DataValueField="CodePgroup"></asp:RadioButtonList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [CodePgroup], [GroupName] FROM [PupilsGroup]"></asp:SqlDataSource>
                    <asp:DropDownList ID="ClassOt2DLL" runat="server" DataSourceID="SqlDataSource3" DataTextField="TotalName" DataValueField="ClassCode" AutoPostBack="false" OnSelectedIndexChanged="FillPupils"></asp:DropDownList>
                </td>
                <td>

                    <asp:Label ID="GroupAgeLBL" runat="server" Text="קבוצת גיל"> </asp:Label>
                    <br />
                    <asp:Label ID="Class2LBL" runat="server" Text=" בחר כיתה"></asp:Label>
                    <asp:Label ID="ChildIDLBL" runat="server" Text=" הזן תעודת זהות"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="MainTeacherCB" runat="server"  AutoPostBack="true" OnCheckedChanged="MainTeacherCB_CheckedChanged"/>
                      <asp:CheckBox ID="UpdateChild" runat="server"  AutoPostBack="true" Text="לעדכן ילדים?" OnCheckedChanged="UpdateChild_CheckedChanged"/>
                </td>
                <td>
                    <asp:Label ID="MainTeacher" runat="server" Text=" האם מחנך"></asp:Label>

                </td>
            </tr>

        </table>
        <br />
        <asp:Button ID="UpdateUserBTN" runat="server" CssClass="form-btn" Text="עדכן משתמש" OnClick="UpdateUserBTN_Click" />
        <asp:Label ID="MessegaeLBL" runat="server" Text="" Style="text-align: right"></asp:Label>

    </div>
</asp:Content>

