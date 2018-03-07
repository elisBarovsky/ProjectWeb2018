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

        CreateEmptyTimeTable();


    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        string Value;

        if ((sender as DropDownList).ID == "ddl_clases")
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
        //rows ^
        for (int i = 0; i < 9; i++)
        {
            TableRow tr = new TableRow();
            TableCell lessonNumber = new TableCell();
            lessonNumber.Text = (i + 1).ToString();
            tr.Cells.Add(lessonNumber);
            //the days <>
            for (int j = 0; j < 6; j++)
            {
                TableCell cell = new TableCell();
                cell.CssClass = "DDL";
                DropDownList dSubject = new DropDownList();
                dSubject.ID = "DDLsubject" + counter;
                dSubject.DataTextField = "Value";
                dSubject.DataValueField = "Key";
                dSubject.DataSource = subjects;

                dSubject.DataBind();
                cell.Controls.Add(dSubject);
                cell.Controls.Add(new HtmlGenericControl("br"));

                DropDownList dTeacher = new DropDownList();
                dTeacher.ID = "DDLteacher" + counter;
                dTeacher.CssClass = "DDL";
                dTeacher.DataSource = teachers;
                dTeacher.DataValueField = "Key";
                dTeacher.DataTextField = "Value";
                dTeacher.DataBind();
                cell.Controls.Add(dTeacher);
                tr.Cells.Add(cell);
                cell.Controls.Add(new HtmlGenericControl("br"));

                counter++;
            }

            TimeTable.Rows.Add(tr);
        }

    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        List<Dictionary<string, string>> matrix = new List<Dictionary<string, string>>();
        string classCode = ddl_clases.SelectedValue;
        string CodeLesson; //מקצוע
        string teacherID;
        TimeTable TT = new TimeTable();
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
                if (CodeLesson != "0" && teacherID == "0")
                {
<<<<<<< HEAD
                    flag = true;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא ניתן להזין מורה ללא מקצוע נלמד.');", true);
                }
                else if (CodeLesson == "0" && teacherID != "0")
                {
                    flag = true;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שים לב! לא ניתן להזין מקצוע ללא מורה.');", true);

=======
                    this.AlertBoxMessage.InnerText = "לא ניתן להזין מורה ללא מקצוע נלמד.";
                    this.AlertBox.Visible = true;
                    flag = true; 
                }
                else if (CodeLesson == "0" && teacherID != "0")
                {
                    this.AlertBoxMessage.InnerText = "שים לב כי הוזן מקצוע ללא מורה.";
                    this.AlertBox.Visible = true;
                    flag = true;
<<<<<<< HEAD
>>>>>>> 5f4064e1e0fff68c42d8d4dca10cf800de452ea3
=======
>>>>>>> 5f4064e1e0fff68c42d8d4dca10cf800de452ea3
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
                    empty.Add("classCode", null);
                    matrix.Add(empty);
                }

                counter++;
            }
        }
        if (!flag)
        {
            int rowsAffected = TT.InsertTimeTable(matrix);
            if (rowsAffected > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('מערכת נשמרה בהצלחה'); location.href='ANewTimeTable.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('קרתה תקלה בעת שמירת המערכת. נא צור קשר עם שירות הלקוחות בטלפון: 1-800-400-400 AIG');", true);
            }

        }
    }

    protected void PreparePageToUpdate(object sender, EventArgs e)
    {
        updateB.CssClass = "btn btn-primary active";
        addB.CssClass = "btn btn-primary";
        ButtonSave.Visible = false;
        ButtonUpdate.Visible = true;
        ClearTimeTable();
    }

    protected void PreparePageToAddNew(object sender, EventArgs e)
    {
        addB.CssClass = "btn btn-primary active";
        updateB.CssClass = "btn btn-primary";
        ButtonSave.Visible = true;
        ButtonUpdate.Visible = false;
        ClearTimeTable();
    }

    protected void ClearTimeTable()
    {
        int counter = 1;
        for (int i = 0; i < TimeTable.Rows.Count; i++)
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
}