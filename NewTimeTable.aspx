<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="NewTimeTable.aspx.cs" Inherits="timeTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        table{
             width: 100%;
        }

        #TimeTable{
            border: 1px solid blue;
           
        }

        tr, td {
             min-height: 20px;
        }

        #TimeTable th, #TimeTable tr, #TimeTable td{
            border: 1px solid blue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
  <h2>מערכת שעות</h2>
  <%--<p>The .btn-group class creates a button group:</p>--%>
  <div class="btn-group">
    <button type="button" class="btn btn-primary" onclick="location.href = 'UpdateTimeTable.aspx';" >עדכון מערכת שעות</button>
    <button type="button" class="btn btn-primary active"  onclick="location.href = 'www.yoursite.com';">יצירת מערכת שעות</button>
  </div>
            <table>
                <tr>
                    <td>
                         <asp:RadioButtonList ID="RadioButtonList_classes" runat="server" RepeatDirection="Horizontal" DataSourceID="DSsemesters" DataTextField="SemesterName" DataValueField="SemesterCode" TextAlign="Right"></asp:RadioButtonList>
                         <asp:SqlDataSource ID="DSsemesters" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT DISTINCT [SemesterCode], [SemesterName] FROM [Semester] ORDER BY [SemesterName]"></asp:SqlDataSource>
                    </td>
                    <td>
                         <asp:Label ID="Label_choose_semester" runat="server" Text=" :בחר מחצית"></asp:Label>
                    <td />
                    <td>
                        <asp:DropDownList ID="ddl_clases" runat="server" DataSourceID="DSclasses" DataTextField="TotalName" DataValueField="ClassCode"></asp:DropDownList>
                        <asp:SqlDataSource ID="DSclasses" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT DISTINCT [ClassCode], [TotalName] FROM [Class] ORDER BY [TotalName]"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        <table id = "TimeTable">
              <tr>
                <th>שישי</th>
                <th>חמישי</th>
                <th>רביעי</th>
                <th>שלישי</th>
                <th>שני</th>
                <th>ראשון</th>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList>
                    <asp:SqlDataSource ID="DSsubjects" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT DISTINCT * FROM [Lessons] ORDER BY [LessonName]"></asp:SqlDataSource>
                </td>
               <td><asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>

            <tr>
                <td><asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList8" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList9" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList10" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList11" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList12" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList13" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList14" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList15" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList16" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList17" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList18" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList19" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList20" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList21" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList22" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList23" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList24" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList25" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList26" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList27" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList28" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList29" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList30" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList31" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList32" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList33" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList34" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList> </td>
                <td><asp:DropDownList ID="DropDownList35" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList36" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList37" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList38" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList39" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList40" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList41" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList42" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>

            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList43" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList44" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList45" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList46" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList47" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList48" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList49" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList50" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList51" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList52" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList53" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList54" runat="server" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
            </tr>
        </table>
</div>
</asp:Content>

