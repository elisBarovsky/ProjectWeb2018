using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TTimeTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }

        ShowTimeTableClass();
    }

    protected void ShowTimeTableClass()
    {
        string teacherID = Request.Cookies["UserID"].Value;
        Users teacher = new Users();
        int classCode = teacher.GetMainTeacherClass(teacherID);
        if (classCode == -1)
        {
            //message - this teacher dont has a class.
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('אין עבורך כיתת חינוך.');", true);
            return;
        }

        //show time table
        Classes c = new Classes();
        string classFullName = c.GetClassNameByCodeClass(classCode);
        className.Text = "מערכת השעות של כיתה " + classFullName;
        CreateEmptyTimeTable();
        FillTimeTableAccordingToClassCode(classCode);
    }

    protected void CreateEmptyTimeTable()
    {
        Subject subject = new Subject();
        Users user = new Users();
        int counter = 1;
        Dictionary<int, string> subjects = subject.getSubjects();
        Dictionary<string, string> teachers = user.GetTeachers();

        FillDaysTitles();

        //rows ^
        for (int i = 0; i < 9; i++)
        {
            TableRow tr = new TableRow();           
            TableCell lessonNumber = new TableCell();
            lessonNumber.Style.Add("width", "20px");
            lessonNumber.Style.Add("height", "40px");
            lessonNumber.Style.Add("text-align", "center");
            lessonNumber.Text = (i + 1).ToString();
            lessonNumber.CssClass = "DDL_TD";
            tr.Cells.Add(lessonNumber);
        
            //the days <>
            for (int j = 0; j < 6; j++)
            {
                TableCell cell = new TableCell();
                cell.Style.Add("width", "70px");
                cell.Style.Add("height", "40px");
                cell.Style.Add("text-align", "center");
                cell.CssClass = "DDL_TD";
                Label dSubject = new Label();
                dSubject.ID = "DDLsubject" + counter;
                dSubject.Text = "";
                dSubject.Style["Font-Weight"] = "bold";
                dSubject.DataBind();
                cell.Controls.Add(dSubject);

                Label dTeacher = new Label();
                dTeacher.ID = "DDLteacher" + counter;
                dTeacher.Text = "";
                dTeacher.DataBind();
                cell.Controls.Add(dTeacher);
                tr.Cells.Add(cell);

                counter++;
            }
            lessonNumber.Text = (i + 1).ToString();
            lessonNumber.CssClass = "DDL_TD";
            tr.Cells.Add(lessonNumber);

            TimeTable.Rows.Add(tr);
        }
    }

    protected void FillDaysTitles()
    {
        string[] days = new string[] { "שישי", "חמישי", "רביעי", "שלישי", "שני", "ראשון", "שיעור" };
        //TimeTable;
        TableRow tr = new TableRow();

        for (int i = 0; i < days.Length; i++)
        {
            TableCell cell = new TableCell();
            cell.Style.Add("text-align", "center");
            cell.Text = days[i];
            tr.Cells.Add(cell);
        }
        TimeTable.Rows.Add(tr);
        TimeTable.DataBind();
    }

    protected void FillTimeTableAccordingToClassCode(int classCode)
        {
            Subject subject = new Subject();
            //Users user = new Users();
            int counter = 1;
            TimeTable TT = new TimeTable();

            //TT from the DB
            List<Dictionary<string, string>> allLessons = TT.GetTimeTableAcordingToClassCode(classCode);
            //rows ^
            for (int i = 1; i < TimeTable.Rows.Count; i++)
            {

                for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
                {
                    Dictionary<string, string> lessonInTT = ReturnIfLessonExsistsInTT(i, j, allLessons);
                    string subjectID = "DDLsubject" + counter;
                    string TID = "DDLteacher" + counter;
                Users u = new Users();

                    if (lessonInTT.Count > 0)
                    {
                        string lessonName = TT.GetLessonNameByLessonCode(lessonInTT["CodeLesson"]);
                        string teacherName = u.GetUserFullNameByID(lessonInTT["TeacherId"]);

                        (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as Label).Text = lessonName + "<br/>";
                        (TimeTable.Rows[i].Cells[j].FindControl(TID) as Label).Text = teacherName;
                    }
                else
                {
                    (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as Label).Text = "";
                    (TimeTable.Rows[i].Cells[j].FindControl(TID) as Label).Text = "";
                }

                counter++;
                }

            }
        }

    protected Dictionary<string, string> ReturnIfLessonExsistsInTT(int lessonNumber, int weekDay, List<Dictionary<string, string>> TimeTable)
    {
        //return just the specific lesson if exists in row number and day.
        Dictionary<string, string> lessonInTT = new Dictionary<string, string>();

        for (int i = 0; i < TimeTable.Count; i++)
        {
            Dictionary<string, string> tempLesson = TimeTable[i];
            if (tempLesson["ClassTimeCode"] == lessonNumber.ToString() && tempLesson["CodeWeekDay"] == weekDay.ToString())
            {
                return lessonInTT = tempLesson;
            }
        }

        return lessonInTT;
    }
}