using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TGrades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            CreatePupilsListByClassCode();
    }

    protected void FillPupils(object sender, EventArgs e)
    {
        CreatePupilsListByClassCode();
    }

    protected void CreatePupilsListByClassCode()
    {
        tableGrades.Rows.Clear();
        string ClassCode = ChooseClassDLL.SelectedValue;
        List<Dictionary<string, string>> pupils = new List<Dictionary<string, string>>();
        Users u = new Users();
        pupils = u.getPupilsByClassCode(ClassCode);
        string[] titles = new string[] { "ציון", "שם", "ת.ז." };
        TableRow tr = new TableRow();
        int counter = 0;
        for (int i = 0; i < 3; i++)
        {
            TableCell title = new TableCell();
            title.CssClass = "DDL_TD";
            title.Text = titles[i];
            tr.Cells.Add(title);
        }
        tableGrades.Rows.Add(tr);

        for (int i = 0; i < pupils.Count; i++)
        {
            TableRow row = new TableRow();

            TableCell grade = new TableCell();
            grade.CssClass = "DDL_TD";
            grade.ID = "grade" + counter;
            TextBox tb = new TextBox();
            tb.ID = "gradeTB" + counter;
            tb.Attributes["type"] = "number";
            tb.Text = "";
            grade.Controls.Add(tb);
            row.Cells.Add(grade);

            TableCell name = new TableCell();
            name.CssClass = "DDL_TD";
            name.ID = "name" + counter;
            name.Text = pupils[i]["UserName"];
            row.Cells.Add(name);

            TableCell id = new TableCell();
            id.CssClass = "DDL_TD";
            id.ID = "id" + counter;
            id.Text = pupils[i]["UserId"];
            row.Cells.Add(id);

            tableGrades.Rows.Add(row);
            counter++;
        }
        tableGrades.DataBind();
    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        string value = "";

        if ((sender as DropDownList).ID == "ChooseClassDLL")
        {
            value = "בחר כיתה";
        }
        else value = "בחר מקצוע";
         (sender as DropDownList).Items.Insert(0, new ListItem(value, "0"));
    }

    protected void AddGrades_Click(object sender, EventArgs e)
    {
        string codeLesson = ChooseLessonsDLL.SelectedValue;
        string teacherId = Request.Cookies["UserID"].Value;
        string date = Calendar1.SelectedDate.ToShortDateString();
        if (date == "01/01/0001")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא נבחר תאריך בחינה.');", true);
            return;
        }
        int num = 0;
        for (int i = 1; i < tableGrades.Rows.Count; i++)
        {
            string gradeID = "gradeTB" + (i-1);
            string idID = "id" + (i-1);
            if (IsGradeMiss())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא ניתן להשאיר את השדה - ציון ריק.');", true);
                return;
            }
           
            int grade = int.Parse((tableGrades.Rows[i].Cells[0].FindControl(gradeID) as TextBox).Text);
            string pupilId = tableGrades.Rows[i].Cells[2].Text;
            Grades g = new Grades();
            num += g.InsertGrade(pupilId, teacherId, codeLesson, date,grade);
        }

        if (num == (tableGrades.Rows.Count - 1))
        {
            ChooseClassDLL.SelectedValue = "0";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('ציונים נשמרו בהצלחה'); location.href='TGradesInsert.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('נתקלנו בבעיה בשמירת הנתונים. אנא צור קשר עם שירות הלקוחות.');", true);

        }
    }

    public bool IsGradeMiss()
    {
        bool empty = false;

        for (int i = 1; i < tableGrades.Rows.Count; i++)
        {
            string gradeID = "gradeTB" + (i-1);

            if ((tableGrades.Rows[i].Cells[0].FindControl(gradeID) as TextBox).Text == "")
            {
                empty = true;
                break;
            }
        }
        return empty;
    }

    public static string KeyByValue(Dictionary<string, string> dict, string val)
    {
        string key = null;
        foreach (KeyValuePair<string, string> pair in dict)
        {
            if (pair.Value == val)
            {
                key = pair.Key;
                break;
            }
        }
        return key;
    }

    protected void ChooseLessonsDLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChooseLessonsDLL.Enabled = false;
        ChooseClassDLL.Visible = true;
    }
}