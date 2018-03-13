<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <div style="text-align=center">
            <br/>
            <img src="Images/Betsefer.png" />
            <br/>
            <div id="loginPage" runat="server"> 
        <asp:Login ID="Login1" runat="server"  OnAuthenticate="Login1_Authenticate" LoginButtonText="התחבר" PasswordLabelText=":סיסמה " RememberMeText="זכור אותי להתחברות הבאה" TextLayout="TextOnTop" TitleText="" UserNameLabelText=":מספר תעודת זהות" style="text-align: right"></asp:Login>
           
            <br/>
            <div>
                <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="IforgotPassword">שכחתי סיסמה</asp:LinkButton>--%>
                <asp:ImageButton ID="ImageButton1" runat="server" src="Images/5897a7cfcba9841eabab6152.png" Height="75px" title="שכחתי סיסמה" OnClick="IforgotPassword" />
            </div>
            

           </div>
             <br/>
                <div id="firstLogin"  runat="server" visible="false">
                    <asp:Label ID="Label_firstLogin" runat="server" Text="אנא ענה על מספר שאלות שיעזרו לנו במקרה ותצטרך לשחזר את סיסמתך"></asp:Label>
                    <br /> <br />
                    <asp:DropDownList ID="DropDownList_Qlist1" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="CheckQ2" DataSourceID="SqlDataSource1" DataTextField="SecurityQInfo" DataValueField="CodeSecurityQ"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bgroup52_test2ConnectionString %>" SelectCommand="SELECT * FROM [SecurityQ]"></asp:SqlDataSource>
                    <asp:Label ID="Label_Q1" runat="server" Text="בחר שאלת הזדהות"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox_answer1" runat="server"></asp:TextBox>
                    <br /> <br />
                    <asp:DropDownList ID="DropDownList_Qlist2" runat="server" AutoPostBack="true"  DataSourceID="SqlDataSource2" OnSelectedIndexChanged="CheckQ2" DataTextField="SecurityQInfo" DataValueField="CodeSecurityQ"></asp:DropDownList>
                     <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT * FROM [SecurityQ]"></asp:SqlDataSource>
                     <asp:Label ID="Label_Q2" runat="server" Text="בחר שאלת הזדהות שנייה"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox_answer2" runat="server"></asp:TextBox>
                      <br />  <br />
                    <asp:Button ID="LinkButton_continue" runat="server" OnAuthenticate="Login1_Authenticate" text="המשך" OnClick="UpdateQuestion"/>
                </div>

            <div id="forgetMyPassword"  runat="server" visible="false">

                <asp:TextBox ID="TextBoxUserID" runat="server" MaxLength="10"></asp:TextBox>
                <asp:Label ID="LabelUserID" runat="server" Text=".ת.ז"></asp:Label>
                <br/>
                <br />
                <asp:DropDownList ID="DDLday" runat="server"></asp:DropDownList> /
                <asp:DropDownList ID="DDLmonth" runat="server"></asp:DropDownList> /
                <asp:DropDownList ID="DDLyear" runat="server"></asp:DropDownList>
                <br/>
               
                <br/>
                <asp:Button ID="ButtonCheckUserExist" runat="server" Text="בדיקת משתמש" OnClick="ButtonCheckUserExist_Click" />
            </div>
            <br />

             <asp:Label ID="LBLEror" runat="server" Text=""></asp:Label>
            <div id="securityQ"  runat="server" visible="false">
                 <asp:TextBox ID="TextBoxSecurityA1" runat="server"></asp:TextBox>
                 <asp:Label ID="LabelSecurityQ1" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="TextBoxSecurityA2" runat="server"></asp:TextBox>
                 <asp:Label ID="LabelSecurityQ2" runat="server" Text=""></asp:Label>
                <br/><br/>
             <asp:Button ID="CheckAnswer" runat="server" Text="אימות תשובה" OnClick="CheckAnswer_Click"  />

                <br/>
            </div>

             <div id="ChangePassword"  runat="server" visible="false">
                 <asp:Table ID="Table1" runat="server">
                     <asp:TableRow>
                         <asp:TableCell>
                 <asp:TextBox ID="Pass1" runat="server" TextMode="Password" ></asp:TextBox>
                 <asp:RegularExpressionValidator ID="valPassword" runat="server" BorderStyle="Groove" Font-Size="Medium" ControlToValidate="Pass1"
                    ErrorMessage="סיסמא צריכה להכיל לפחות 4 תוים" ValidationExpression=".{4}.*" />
                         </asp:TableCell>
                         <asp:TableCell>
                  <asp:Label ID="Label3" runat="server" Text="הזן סיסמה חדשה"></asp:Label>
                         </asp:TableCell>
                     </asp:TableRow>
                     <asp:TableRow>
                         <asp:TableCell>
                 <asp:TextBox ID="Pass2" runat="server" TextMode="Password"></asp:TextBox>
                         </asp:TableCell>
                         <asp:TableCell>
                  <asp:Label ID="Label2" runat="server" Text="הזן סיסמה בשנית"></asp:Label>
                         </asp:TableCell>
                     </asp:TableRow>
                 </asp:Table>
                 <br/><br/>
                 <br/>
                 <br/>
                <asp:Button ID="Button1" runat="server" Text="שנה סיסמה" OnClick="ChangePasswordBTN"   />
                <br/>
                        

            </div>
              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/><br/>
              <asp:Button ID="Button2" runat="server" Text="מעבר להתחברות " Visible="false" OnClick="BackToLoginBTN" />
    </div>
        </div>
    </form>
</body>
</html>
