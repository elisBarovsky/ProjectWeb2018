<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AAddNewUser.aspx.cs" Inherits="AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 80%;
            position: center;
        }

    </style>
    <link href="css/Style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2 style="text-align: center">ניהול משתמשים</h2>
        <div class="btn-group" style="position: relative; left: 40%;">
            <button type="button" class="btn btn-primary active" onclick="location.href = 'AAddNewUser.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary " onclick="location.href = 'AUpdateUser.aspx';">עדכון</button>
        </div>
        <br />
        <br />

        <table class="auto-style1" align="center">
            <tr>
                <td>
                    <asp:CheckBox ID="MainTeacherCB" runat="server" AutoPostBack="true" OnCheckedChanged="MainTeacherCB_CheckedChanged" />
                </td>
                <td>
                    <asp:Label ID="MainTeacher" runat="server" Text=" האם מחנך"></asp:Label>
                </td>

                <td>
                    <asp:RadioButtonList ID="UserTypeDLL" runat="server" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="UserTypeDLL_CheckedChanged" DataTextField="CodeUserName" DataValueField="CodeUserType" AutoPostBack="true" RepeatDirection="Horizontal"></asp:RadioButtonList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT * FROM [UserType]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="סוג משתמש"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="LNameTB" runat="server" required="required"></asp:TextBox>
                </td>
                <td>שם משפחה</td>
                <td>
                    <asp:TextBox ID="FNameTB" runat="server" required="required" MaxLength="10"></asp:TextBox>
                </td>
                <td>שם פרטי</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="UserIDTB" runat="server" required="required" MaxLength="10"></asp:TextBox>
                    <asp:RegularExpressionValidator runat=server ControlToValidate="UserIDTB" 
                        ErrorMessage="מצחיקול! הזן בשדה רק מספרים." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                </td>
                <td>תעודת זהות</td>
                <td>
                     <asp:DropDownList ID="DDLday"  runat="server"></asp:DropDownList>/
                    <asp:DropDownList ID="DDLmonth" runat="server"></asp:DropDownList>/
                    <asp:DropDownList ID="DDLyear" runat="server"></asp:DropDownList>
                </td>
                <td>תאריך לידה</td>
            </tr>

            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>תמונה</td>
                <td>
                    <asp:DropDownList ID="ClassOtDLL" style="direction:rtl;" runat="server" DataSourceID="SqlDataSource3" DataTextField="TotalName" DataValueField="ClassCode" OnLoad="FillFirstItem"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [ClassCode], [TotalName] FROM [Class]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:Label ID="ClassLBL" runat="server" Text=" בחר כיתה"></asp:Label>


                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TelephoneNumberTB" runat="server" required="required" MaxLength="10"></asp:TextBox>
                    <asp:RegularExpressionValidator runat=server ControlToValidate="TelephoneNumberTB" 
                        ErrorMessage="מצחיקול! הזן בשדה רק מספרים." ForeColor="Red" ValidationExpression="^[0-9]*$" />
                    <br /> 
                </td>
                <td>טלפון</td>
                <td>
                    <asp:TextBox ID="PasswordTB" runat="server" required="required"></asp:TextBox>
                    <asp:RegularExpressionValidator runat=server ControlToValidate="PasswordTB" 
                        ErrorMessage="סיסמא חייבת להכיל לפחות 4 תוים." ValidationExpression=".{4}.*" />
                </td>
                <td>סיסמה</td>
            </tr>      
            <tr>
                
                <td>
                    <br /><br /><br /><br /><br />
                     <asp:TextBox ID="ChildI1DTB" runat="server" required="required" MaxLength="10"></asp:TextBox><br />
                    <asp:RegularExpressionValidator runat=server ControlToValidate="ChildI1DTB" 
                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$"  />
                     <asp:TextBox ID="ChildI2DTB" runat="server" required="required" MaxLength="10"></asp:TextBox><br />
                    <asp:RegularExpressionValidator runat=server ControlToValidate="ChildI2DTB" 
                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$"  />
                     <asp:TextBox ID="ChildI3DTB" runat="server" required="required" MaxLength="10"></asp:TextBox><br />
                    <asp:RegularExpressionValidator runat=server ControlToValidate="ChildI3DTB" 
                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$"  />
                     <asp:TextBox ID="ChildI4DTB" runat="server" required="required" MaxLength="10"></asp:TextBox><br />
                    <asp:RegularExpressionValidator runat=server ControlToValidate="ChildI4DTB" 
                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$"  />
                     <asp:TextBox ID="ChildI5DTB" runat="server" required="required" MaxLength="10"></asp:TextBox><br />
                    <asp:RegularExpressionValidator runat=server ControlToValidate="ChildI5DTB" 
                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$"  />
                     <asp:TextBox ID="ChildI6DTB" runat="server" required="required" MaxLength="10"></asp:TextBox>
                    <asp:RegularExpressionValidator runat=server ControlToValidate="ChildI6DTB" 
                        ErrorMessage="ת.ז. חייבת להכיל מספרים בלבד." ForeColor="Red" ValidationExpression="^[0-9]*$"  />
                </td>
                <td>
                    <asp:Label ID="ChildIDLBL" runat="server" Text=" :הזן תעודת זהות ילד"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="NumOfChildDDL" style="direction:rtl;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="NumOfChildDDL_SelectedIndexChanged"></asp:DropDownList></td>
                <td>
                    <asp:Label ID="NumChildLBL" runat="server" Text="  מספר ילדים רשומים בבית הספר"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button ID="AddUserBTN" runat="server" CssClass="form-btn" Text="הוסף משתמש" OnClick="AddUserBTN_Click" />
    </div>
</asp:Content>

