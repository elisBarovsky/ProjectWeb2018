using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class timeTable : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
        CreateEmptyTimeTable();

    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        string Value;

        if ((sender as DropDownList).ID == "ddl_clasesAdd" || (sender as DropDownList).ID == "ddl_clasesEdit")
        {
            Value = "בחר כיתה";
        }
        else Value = "-";
        (sender as DropDownList).Items.Insert(0, new ListItem(Value, "0"));
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
            
            //the days <>
            for (int j = 0; j < 6; j++)
            {
                TableCell cell = new TableCell();
                cell.CssClass = "DDL_TD";
                DropDownList dSubject = new DropDownList();
                dSubject.ID = "DDLsubject" + counter;
                dSubject.DataTextField = "Value";
                dSubject.DataValueField = "Key";
                dSubject.DataSource = subjects;

                dSubject.DataBind();
                cell.Controls.Add(dSubject);
                //cell.Controls.Add(new HtmlGenericControl("br"));

                DropDownList dTeacher = new DropDownList();
                dTeacher.ID = "DDLteacher" + counter;
                dTeacher.DataSource = teachers;
                dTeacher.DataValueField = "Key";
                dTeacher.DataTextField = "Value";
                dTeacher.DataBind();
                cell.Controls.Add(dTeacher);
                tr.Cells.Add(cell);
                //cell.Controls.Add(new HtmlGenericControl("br"));

                counter++;
            }

            TableCell lessonNumber = new TableCell();
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
            cell.Text = days[i];
            tr.Cells.Add(cell);
        }
        TimeTable.Rows.Add(tr);
        TimeTable.DataBind();
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        TimeTable TT = new TimeTable();

        if (ddl_clasesAdd.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שים לב! לא ניתן לשמור מערכת ללא בחירת כיתה.');", true);
            return;
        }
        
        List<Dictionary<string, string>> matrix = new List<Dictionary<string, string>>();
        string classCode = ddl_clasesAdd.SelectedValue;
        string CodeLesson; //מקצוע
        string teacherID;
        int counter = 1;
        bool flag = false;
        // rows - ^.
        for (int i = 1; !flag && i < TimeTable.Rows.Count; i++)
        {
            // cells - the days <>.
            for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
            {
                string subjectID = "DDLsubject" + counter;
                string TID = "DDLteacher" + counter;
                CodeLesson = (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue;
                teacherID = (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue;
                if (CodeLesson == "0" && teacherID != "0")
                {
                    flag = true;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא ניתן להזין מורה ללא מקצוע נלמד.');", true);
                }
                else if (CodeLesson != "0" && teacherID == "0")
                {
                    flag = true;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שים לב! לא ניתן להזין מקצוע ללא מורה.');", true);
                }
                else if (CodeLesson != "0" && teacherID != "0")
                {
                    Dictionary<string, string> lessonInTimeTable = new Dictionary<string, string>();
                    lessonInTimeTable.Add("classCode", classCode); //className
                    lessonInTimeTable.Add("CodeWeekDay", j.ToString()); //numDay
                    lessonInTimeTable.Add("ClassTimeCode", i.ToString()); //numLesson - 1 is the first lesson.
                    lessonInTimeTable.Add("CodeLesson", CodeLesson);
                    lessonInTimeTable.Add("TeacherID", teacherID);

                    matrix.Add(lessonInTimeTable);
                }
                else
                {
                    Dictionary<string, string> empty = new Dictionary<string, string>();
                    empty.Add("classCode", "empty");
                    matrix.Add(empty);
                }

                counter++;
            }
        }
        if (!flag)
        {
            int rowsAffected = TT.InsertTimeTable(matrix, classCode);
            if (rowsAffected > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('מערכת נשמרה בהצלחה'); location.href='ATimeTable.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('קרתה תקלה בעת שמירת המערכת. נא צור קשר עם שירות הלקוחות בטלפון: 1-800-400-400');", true);
            }

        }
    }

    protected void PreparePageToUpdate(object sender, EventArgs e)
    {
        updateB.CssClass = "btn btn-primary active";
        addB.CssClass = "btn btn-primary";
        ButtonSave.Visible = false;
        ButtonUpdate.Visible = true;
        ddl_clasesAdd.ClearSelection();
        ddl_clasesEdit.ClearSelection();
        ddl_clasesAdd.Visible = false;
        ddl_clasesEdit.Visible = true;
        ClearTimeTable();
    }

    protected void PreparePageToAddNew(object sender, EventArgs e)
    {
        addB.CssClass = "btn btn-primary active";
        updateB.CssClass = "btn btn-primary";
        ButtonSave.Visible = true;
        ButtonUpdate.Visible = false;
        ddl_clasesAdd.SelectedValue = "0";
        ddl_clasesEdit.SelectedValue = "0";
        ddl_clasesAdd.Visible = true;
        ddl_clasesEdit.Visible = false;
        ClearTimeTable();
    }

    protected void ClearTimeTable()
    {
        int counter = 1;
        for (int i = 1; i < TimeTable.Rows.Count; i++)
        {
            // cells - the days <>.
            for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
            {
                string subjectID = "DDLsubject" + counter;
                string TID = "DDLteacher" + counter;
                (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue = "0";
                (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue = "0";

                counter++;
            }
        }

    }

    protected void ddl_clases_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ButtonUpdate.Visible == true)
        {
            int classCode = int.Parse(ddl_clasesEdit.SelectedValue.ToString());
            FillTimeTableAccordingToClassCode(classCode);
            return;
        }

    }

    protected void FillTimeTableAccordingToClassCode(int classCode)
    {
        Subject subject = new Subject();
        //Users user = new Users();
        int counter = 1;
        TimeTable TT = new TimeTable();

        //TT from the DB
        List<Dictionary<string, string>> allLessons = TT.GetTimeTableAcordingToClassCode(classCode);
        //CreateEmptyTimeTable();
        //rows ^
        for (int i = 1; i < TimeTable.Rows.Count; i++)
        {
        
            for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
            {
                Dictionary<string, string> lessonInTT = ReturnIfLessonExsistsInTT(i, j, allLessons);
                string subjectID = "DDLsubject" + counter;
                string TID = "DDLteacher" + counter;

                if (lessonInTT.Count > 0)
                {
                    
                    (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue = lessonInTT["CodeLesson"];
                    (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue = lessonInTT["TeacherId"];
                }
                else
                {
                    (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue = "0";
                    (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue = "0";
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

    protected void ButtonUpdate_Click(object sender, EventArgs e)
    {
        TimeTable TT = new TimeTable();

        //delete timetablelessom acording to class and delete timetable acording to class
        if (ddl_clasesEdit.SelectedValue == "0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שים לב! לא ניתן לעדכן מערכת ללא בחירת כיתה.');", true);
            return;
        }

        List<Dictionary<string, string>> matrix = new List<Dictionary<string, string>>();
        string classCode = ddl_clasesEdit.SelectedValue;
        int answer1 = TT.DeleteTimeTableLessons(classCode); 
        int answer2 = TT.DeleteTimeTable(classCode); 
        if (answer2 > 0)
        {
            //call the save time table function
            string CodeLesson; //מקצוע
            string teacherID;
            int counter = 1;
            bool flag = false;
            // rows - ^.
            for (int i = 1; !flag && i < TimeTable.Rows.Count; i++)
            {
                // cells - the days <>.
                for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
                {
                    string subjectID = "DDLsubject" + counter;
                    string TID = "DDLteacher" + counter;
                    CodeLesson = (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue;
                    teacherID = (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue;
                    if (CodeLesson == "0" && teacherID != "0")
                    {
                        flag = true;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא ניתן להזין מורה ללא מקצוע נלמד.');", true);
                    }
                    else if (CodeLesson != "0" && teacherID == "0")
                    {
                        flag = true;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שים לב! לא ניתן להזין מקצוע ללא מורה.');", true);
                    }
                    else if (CodeLesson != "0" && teacherID != "0")
                    {
                        Dictionary<string, string> lessonInTimeTable = new Dictionary<string, string>();
                        lessonInTimeTable.Add("classCode", classCode); //className
                        lessonInTimeTable.Add("CodeWeekDay", j.ToString()); //numDay
                        lessonInTimeTable.Add("ClassTimeCode", i.ToString()); //numLesson - 1 is the first lesson.
                        lessonInTimeTable.Add("CodeLesson", CodeLesson);
                        lessonInTimeTable.Add("TeacherID", teacherID);

                        matrix.Add(lessonInTimeTable);
                    }
                    else
                    {
                        Dictionary<string, string> empty = new Dictionary<string, string>();
                        empty.Add("classCode", "empty");
                        matrix.Add(empty);
                    }

                    counter++;
                }
            }
            if (!flag)
            {
                int rowsAffected = TT.InsertTimeTable(matrix, classCode);
                if (rowsAffected > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('מערכת נשמרה בהצלחה'); location.href='ATimeTable.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('קרתה תקלה בעת שמירת המערכת. נא צור קשר עם שירות הלקוחות בטלפון: 1-800-400-400 AIG');", true);
                }

            }
        }

    }
}
