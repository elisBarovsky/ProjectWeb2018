<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="AddNewUser.aspx.cs" Inherits="AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            position: center;
        }
    </style>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="container">
  <h2>ניהול משתמשים</h2>
  <%--<p>The .btn-group class creates a button group:</p>--%>
  <div class="btn-group" style="position:center" >
    <button type="button" class="btn btn-primary active" onclick="location.href = 'AddNewUser.aspx';" >הוספה  </button>
    <button type="button" class="btn btn-primary " onclick="location.href = 'UpdateUser.aspx';">עדכון</button>
  </div>
     <br /><br />
     

     <table class="auto-style1">
         <tr>
             <td  > <asp:RadioButtonList ID="GroupAgeDLL" required="required" runat="server" DataSourceID="SqlDataSource1" DataTextField="GroupName" DataValueField="CodePgroup" RepeatDirection="Horizontal"></asp:RadioButtonList>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [CodePgroup], [GroupName] FROM [PupilsGroup]"></asp:SqlDataSource>

               <asp:CheckBox ID="MainTeacherCB" runat="server" AutoPostBack="true" OnCheckedChanged="MainTeacherCB_CheckedChanged" />
             </td>
             <td  ><asp:Label ID="GroupAgeLBL" runat="server" Text="קבוצת גיל"> </asp:Label> 
               <asp:Label ID="MainTeacher" runat="server" Text=" האם מחנך"></asp:Label>  
               </td>

             <td> <asp:RadioButtonList ID="UserTypeDLL" runat="server" DataSourceID="SqlDataSource2"  OnSelectedIndexChanged ="UserTypeDLL_CheckedChanged"  DataTextField="CodeUserName" DataValueField="CodeUserType" AutoPostBack="true" RepeatDirection="Horizontal" ></asp:RadioButtonList>  
                 <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT * FROM [UserType]" ></asp:SqlDataSource>
             </td>
             <td>  <asp:Label ID="Label1" runat="server" Text="סוג משתמש"></asp:Label></td>
         </tr>
         <tr>
             <td><asp:TextBox ID="LNameTB" runat="server" required="required"></asp:TextBox></td>
             <td>שם משפחה</td>
             <td> <asp:TextBox ID="FNameTB" runat="server" required="required"></asp:TextBox></td>
             <td>שם פרטי</td>
         </tr>
         <tr>
             <td><asp:TextBox ID="UserIDTB" runat="server" required="required"></asp:TextBox></td>
             <td>תעודת זהות</td>
             <td>
                <asp:Calendar ID="Calendar1" runat="server"  AutoPostBack="false" />

             </td>
             <td>תאריך לידה</td>
         </tr>
         
         <tr >
                 <td> <asp:FileUpload ID="FileUpload1" runat="server" /></td>
             <td>תמונה</td>
             <td><asp:DropDownList ID="ClassOtDLL" runat="server" DataSourceID="SqlDataSource3" DataTextField="TotalName" DataValueField="ClassCode"></asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [ClassCode], [TotalName] FROM [Class]"></asp:SqlDataSource>
                 </td>
             <td ><asp:Label ID="ClassLBL" runat="server" Text=" בחר כיתה"></asp:Label>
                 

             </td>
         </tr>
            <tr>
             <td><asp:TextBox ID="PasswordTB" runat="server" required="required"></asp:TextBox></td>
             <td>סיסמה</td>
             <td><asp:TextBox ID="UserNameTB" runat="server" required="required"></asp:TextBox></td>
             <td>שם משתמש</td>
         </tr>

         <tr>
             <td><asp:TextBox ID="ChildIDTB" runat="server" required="required"></asp:TextBox> </td>
             <td> <asp:Label ID="ChildIDLBL" runat="server" Text=" הזן תעודת זהות ילד"></asp:Label></td>
             <td><asp:TextBox ID="TelephoneNumberTB" runat="server" required="required"></asp:TextBox></td>
             <td>טלפון</td>

         </tr>
       
     </table>
     <br />
     <asp:Button ID="AddUserBTN" runat="server" CssClass="form-btn" Text="הוסף משתמש" OnClick="AddUserBTN_Click" />
     <asp:Label ID="MessegaeLBL" runat="server" Text=""></asp:Label>

</div>
</asp:Content>

