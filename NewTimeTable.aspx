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

        .DDL {
            width: 100%;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
  <h2 style="text-align: right">מערכת שעות</h2>
  <%--<p>The .btn-group class creates a button group:</p>--%>
  <div class="btn-group">
    <button type="button" class="btn btn-primary" onclick="location.href = 'UpdateTimeTable.aspx';" >עדכון מערכת שעות</button>
    <button type="button" class="btn btn-primary active"  onclick="location.href = 'www.yoursite.com';">יצירת מערכת שעות</button>
  </div>
            <table>
                <tr>
                    <td>
                         <asp:RadioButtonList ID="RadioButtonList_semesters" runat="server" RepeatDirection="Horizontal" DataSourceID="DSsemesters" DataTextField="SemesterName" DataValueField="SemesterCode" TextAlign="Right"></asp:RadioButtonList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator_Semester" ControlToValidate="RadioButtonList_semesters" runat="server" ErrorMessage="עלייך לבחור סמסטר"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="DSsemesters" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT DISTINCT [SemesterCode], [SemesterName] FROM [Semester] ORDER BY [SemesterName]"></asp:SqlDataSource>
                    </td>
                    <td>
                         <asp:Label ID="Label_choose_semester" runat="server" Text=" :בחר מחצית"></asp:Label>
                    <td />
                    <td>
                        <asp:DropDownList ID="ddl_clases" runat="server" ondatabound="FillFirstItem" DataSourceID="DSclasses" DataTextField="TotalName" DataValueField="ClassCode"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Class" runat="server" ControlToValidate="ddl_clases" ErrorMessage="עליך לבחור כיתה" InitialValue="0"></asp:RequiredFieldValidator>
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
                <th>שיעור</th>
            </tr>
            <tr>
                
                <td><asp:DropDownList ID="DropDownList1" CssClass="DDL" runat="server" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList>
                    <asp:SqlDataSource ID="DSsubjects" runat="server" ConnectionString="<%$ ConnectionStrings:Betsefer %>" SelectCommand="SELECT DISTINCT * FROM [Lessons] ORDER BY [LessonName]"></asp:SqlDataSource>
                </td>
               <td><asp:DropDownList ID="DropDownList2"  CssClass="DDL" runat="server" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList3" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList4" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList5" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList6" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"><asp:ListItem> - </asp:ListItem></asp:DropDownList></td>
                <td>1</td>
            <tr>
                <td><asp:DropDownList ID="DropDownList7" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList8" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList9" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList10" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList11" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList12" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td>2</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList13" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList14" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList15" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList16" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList17" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList18" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td>3</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList19" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList20" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList21" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList22" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList23" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList24" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td>4</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList25" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList26" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList27" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList28" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList29" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList30" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td>5</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList31" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList32" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList33" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList34" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList> </td>
                <td><asp:DropDownList ID="DropDownList35" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList36" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td>6</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList37" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList38" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList39" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList40" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList41" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList42" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td>7</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList43" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList44" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList45" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList46" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList47" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList48" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td>8</td>
            </tr>
            <tr>
                <td><asp:DropDownList ID="DropDownList49" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList50" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList51" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList52" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList53" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td><asp:DropDownList ID="DropDownList54" runat="server" CssClass="DDL" ondatabound="FillFirstItem" DataSourceID="DSsubjects" DataTextField="LessonName" DataValueField="CodeLesson"></asp:DropDownList></td>
                <td>9</td>
            </tr>
        </table>
        <br /><br />
        <asp:Button ID="ButtonSave" CssClass="form-btn"  runat="server" Text="שמור" />
</div>
</asp:Content>

