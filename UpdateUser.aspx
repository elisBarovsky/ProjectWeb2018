<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="UpdateUser.aspx.cs" Inherits="UpdateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            position: center;
        }
        .auto-style2 {
            width: 446px;
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
    <button type="button" class="btn btn-primary " onclick="location.href = 'AddNewUser.aspx';" >הוספה  </button>
    <button type="button" class="btn btn-primary active " onclick="location.href = 'UpdateUser.aspx';">עדכון</button>
  </div>
     <br /><br />
     

     <table class="auto-style1">
         <tr>
             <td class="auto-style2"  >
               <asp:DropDownList ID="ClassOtDLL" runat="server"  DataSourceID="SqlDataSource3" DataTextField="TotalName"  DataValueField="ClassCode" AutoPostBack="true" onselectedindexchanged="FillPupils"></asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [ClassCode], [TotalName] FROM [Class]"></asp:SqlDataSource>
             </td>
             <td  ><asp:Label ID="ClassLBL" runat="server" Text=" בחר כיתה" ></asp:Label>               
               </td>
                                                       
             <td> <asp:RadioButtonList ID="UserTypeDLL" runat="server" DataSourceID="SqlDataSource2"  OnSelectedIndexChanged ="UserTypeDLL_CheckedChanged"  DataTextField="CodeUserName" DataValueField="CodeUserType" AutoPostBack="true" RepeatDirection="Horizontal" ></asp:RadioButtonList>  
                 <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT * FROM [UserType]" ></asp:SqlDataSource>
             </td>
             <td>  <asp:Label ID="Label1" runat="server" Text="סוג משתמש"></asp:Label></td>
         </tr>
            <tr>
             <td class="auto-style2">   <asp:Image ID="UserIMG" runat="server" /> </td>
             <td></td>
             <td> <asp:DropDownList ID="PupilDLL" runat="server" OnSelectedIndexChanged ="UserChosed"  AutoPostBack="true"></asp:DropDownList>   
                
            

                 <asp:DropDownList ID="OtherUsersDLL" runat="server" DataSourceID="SqlDataSource4" OnSelectedIndexChanged ="UserChosed" DataTextField="UserName" AutoPostBack="true" DataValueField="UserID"></asp:DropDownList>

                 <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT        (UserLName+' '+ UserFName) as UserName, UserID
                                            FROM dbo.Users where CodeUserType=@CodeUserType">
                     <SelectParameters>
                            <asp:ControlParameter ControlID="UserTypeDLL" DefaultValue="1" Name="CodeUserType" PropertyName="SelectedValue" Type="int32" />
                     </SelectParameters>
                 </asp:SqlDataSource>

                </td>
             <td><asp:Label ID="ChoosePupilLBL" runat="server" Text="בחר תלמיד"></asp:Label>
                 <asp:Label ID="ChooseOtherUsers" runat="server" Text="בחר משתמש"></asp:Label>
             </td>
         </tr>
           <tr>
             <td class="auto-style2"></td>
             <td></td>
             <td> </td>
             <td >עדכון פרטים</td>
         </tr>
         <tr>
             <td class="auto-style2"><asp:TextBox ID="LNameTB" runat="server"></asp:TextBox></td>
             <td>שם משפחה</td>
             <td> <asp:TextBox ID="FNameTB" runat="server"></asp:TextBox></td>
             <td>שם פרטי</td>
         </tr>
         <tr>
             <td class="auto-style2"><asp:TextBox ID="UserIDTB" runat="server"></asp:TextBox></td>
             <td>תעודת זהות</td>
             <td>
                 <asp:TextBox ID="BirthDateTB" runat="server"></asp:TextBox>
                 <br />
                 <asp:CheckBox ID="ChangeBdateCB" runat="server"  Text="האם תרצה לשנות תאריך לידה?"  OnCheckedChanged="ShowCalendar_" AutoPostBack="true"/>
                <asp:Calendar ID="Calendar1" runat="server"  AutoPostBack="false" />

             </td>
             <td>תאריך לידה</td>
         </tr>
         
         <tr >
                 <td class="auto-style2"> <asp:FileUpload ID="FileUpload1" runat="server" /></td>
             <td>תמונה</td>
             <td></td>
             <td >
                 

             </td>
         </tr>
            <tr>
             <td class="auto-style2"><asp:TextBox ID="PasswordTB" runat="server"></asp:TextBox></td>
             <td>סיסמה</td>
             <td><asp:TextBox ID="UserNameTB" runat="server"></asp:TextBox></td>
             <td>שם משתמש</td>
         </tr>

         <tr>
             <td ><asp:TextBox ID="ChildIDTB" runat="server"></asp:TextBox>
                  <asp:RadioButtonList ID="GroupAgeDLL" runat="server"   RepeatDirection="Horizontal" DataSourceID="SqlDataSource5" DataTextField="GroupName" DataValueField="CodePgroup"></asp:RadioButtonList>
                 <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT [CodePgroup], [GroupName] FROM [PupilsGroup]"></asp:SqlDataSource>
             </td>
             <td> <asp:Label ID="ChildIDLBL" runat="server" Text=" הזן תעודת זהות ילד"></asp:Label>

            <asp:Label ID="GroupAgeLBL" runat="server" Text="קבוצת גיל"> </asp:Label>
             </td>
             
             <td><asp:TextBox ID="TelephoneNumberTB" runat="server"></asp:TextBox></td>
             <td>טלפון</td>

         </tr>
       
     </table>
     <br />                                                          <%--OnClick="AddUserBTN_Click"--%>
     <asp:Button ID="AddUserBTN" runat="server" CssClass="form-btn" Text="עדכן משתמש" />
     <asp:Label ID="MessegaeLBL" runat="server" Text=""></asp:Label>

</div>
</asp:Content>

