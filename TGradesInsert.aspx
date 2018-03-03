<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TGradesInsert.aspx.cs" Inherits="TGrades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
          .auto-style1 {
              width: 100%;
              position: center;
          }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <h2 style="text-align: right">ציונים</h2>
        <div class="btn-group" style=" position: relative;  left: 40%;">
            <button type="button" class="btn btn-primary active" onclick="location.href = 'TGradesInsert.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary " onclick="location.href = 'TGradesUpdate.aspx';">עדכון</button>
        </div>
        <br />
        <br />
          <table class="auto-style1">
            <tr>
                <td>
                    <asp:DropDownList ID="ChooseClassDLL" runat="server" OnLoad="FillClasses"></asp:DropDownList>
                </td>
                <td>בחר כיתה
                </td>

                <td><asp:DropDownList ID="ChooseLessonsDLL" runat="server" OnLoad="FillSubjects"></asp:DropDownList>
                </td>
                <td>בחר מקצוע
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td></td>
                <td align="center" style="margin:auto">
                     <asp:calendar id="Calendar1" runat="server" autopostback="false" />
                </td>
                <td>תאריך בחינה</td>
            </tr>



            <tr>
                <td align="center" colspan="4"">
                   
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="UserID" DataSourceID="SqlDataSource1" ForeColor="Black">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:BoundField DataField="Grade" HeaderText="ציון" SortExpression="Grade" />
                            <asp:BoundField DataField="StudentName" HeaderText="שם תלמיד" ReadOnly="True" SortExpression="StudentName" />
                            <asp:BoundField DataField="UserID" HeaderText="תעודת זהות תלמיד" ReadOnly="True" SortExpression="UserID" />
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>

                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" InsertCommand="SELECT    dbo.Users.UserID,( dbo.Users.UserFName+' '+ dbo.Users.UserLName)as StudentName, dbo.Grades.Grade
FROM            dbo.Users Full outer JOIN  dbo.Grades ON dbo.Users.UserID = dbo.Grades.PupilID AND dbo.Users.UserID = dbo.Grades.TeacherID where dbo.Users.CodeUserType='4'" 
                        SelectCommand="SELECT    dbo.Users.UserID,( dbo.Users.UserFName+' '+ dbo.Users.UserLName)as StudentName, dbo.Grades.Grade FROM     dbo.Users Full outer JOIN
                         dbo.Grades ON dbo.Users.UserID = dbo.Grades.PupilID AND dbo.Users.UserID = dbo.Grades.TeacherID
						 where dbo.Users.CodeUserType='4'" 
                        UpdateCommand="SELECT    dbo.Users.UserID,( dbo.Users.UserFName+' '+ dbo.Users.UserLName)as StudentName, dbo.Grades.Grade FROM dbo.Users Full outer JOIN
                         dbo.Grades ON dbo.Users.UserID = dbo.Grades.PupilID AND dbo.Users.UserID = dbo.Grades.TeacherID
						 where dbo.Users.CodeUserType='4'"></asp:SqlDataSource>

                </td>

            </tr>



        </table>
        <br />
        <asp:button id="AddGrades" runat="server" cssclass="form-btn" text="הוסף ציונים" OnClick="AddGrades_Click"  />
        <asp:label id="MessegaeLBL" runat="server" text="" style="text-align: right"></asp:label>







         </div>



</asp:Content>

