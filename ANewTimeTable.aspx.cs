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
                DropDownList dSubject = new DropDownList();
                dSubject.ID = "DropDownList" + counter;
                dSubject.CssClass = "DDL";
                dSubject.DataSource = subjects.Values;
                dSubject.DataBind();
                cell.Controls.Add(dSubject);
                cell.Controls.Add(new HtmlGenericControl("br"));

                DropDownList dTeacher = new DropDownList();
                dTeacher.ID = "DDLteacher" + counter;
                dTeacher.CssClass = "DDL";
                dTeacher.DataSource = teachers.Values;
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
        List<List<string>> matrix = new List<List<string>>();
        string className = ddl_clases.Text;
    }
}