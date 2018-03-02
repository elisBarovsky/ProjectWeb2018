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

        for (int i = 0; i < 9; i++)
        {
            TableRow tr = new TableRow();

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
            TableCell lessonNumber = new TableCell();
            lessonNumber.Text = (i + 1).ToString();
            tr.Cells.Add(lessonNumber);
            TimeTable.Rows.Add(tr);
        }

    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        List<Dictionary<string, string>> matrix = new List<Dictionary<string, string>>();
        string classCode = ddl_clases.SelectedValue;
        string CodeLesson;
        string teacherID;
        TimeTable TT = new TimeTable();

        // rows - the days.
        for (int i = 1; i < TimeTable.Rows.Count; i++)
        {
            // cells - j = 1, it is all the first lesson in the week.
            for (int j = 1; j < TimeTable.Rows[i].Cells.Count; j++)
            {
                string subjectID = "DDLsubject" + (i * j);
                string TID = "DDLteacher" + (i * j);
                CodeLesson = (TimeTable.Rows[i].Cells[j].FindControl(subjectID) as DropDownList).SelectedValue;
                teacherID = (TimeTable.Rows[i].Cells[j].FindControl(TID) as DropDownList).SelectedValue;

                if (CodeLesson != "0" && teacherID != "0")
                {
                    Dictionary<string, string> lessonInTimeTable = new Dictionary<string, string>();
                    lessonInTimeTable.Add("classCode", classCode); //className
                    lessonInTimeTable.Add("CodeWeekDay", j.ToString()); //numDay
                    lessonInTimeTable.Add("ClassTimeCode", j.ToString()); //numLesson - 1 is the first lesson.
                    lessonInTimeTable.Add("CodeLesson", CodeLesson);
                    lessonInTimeTable.Add("TeacherID", teacherID);

                    matrix.Add(lessonInTimeTable);
                }
                else
                {
                    Dictionary<string, string> empty = new Dictionary<string, string>();
                    empty.Add("0", "empty");
                    matrix.Add(empty);
                }
            }
        }
        TT.InsertTimeTable(matrix);
    }
}