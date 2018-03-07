using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class THomeWorkInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillClasses();
            FillSubjects();
        }
    }

    protected void FillClasses()
    {
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Grades ClassGrade = new Grades();
        Classes = ClassGrade.FillClassOt();
        ChooseClassDLL.DataSource = Classes.Values;
        ChooseClassDLL.DataBind();
        Session["ClassesList"] = Classes;
    }

    protected void FillSubjects()
    {
        Dictionary<string, string> Lessons = new Dictionary<string, string>();
        Grades ClassGrade = new Grades();
        Lessons = ClassGrade.FillLessons();
        ChooseLessonsDLL.DataSource = Lessons.Values;
        ChooseLessonsDLL.DataBind();
        Session["LessonsList"] = Lessons;
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

    protected void AddUserBTN_Click(object sender, EventArgs e)
    {
        string ClassCode = "";
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Classes = (Dictionary<string, string>)(Session["ClassesList"]);
        ClassCode = KeyByValue(Classes, ChooseClassDLL.SelectedValue);

        string LessonsCode = "";
        Dictionary<string, string> LessonsList = new Dictionary<string, string>();
        LessonsList = (Dictionary<string, string>)(Session["LessonsList"]);
        LessonsCode = KeyByValue(Classes, ChooseClassDLL.SelectedValue);

        string date = DateTime.Today.ToShortDateString();
        string TeacherId = Request.Cookies["UserID"].Value;

        HomeWork HW = new HomeWork();

        int res1 = HW.InserHomeWork(LessonsCode, HomeWorkDesc.Text, TeacherId, ClassCode, Calendar1.SelectedDate.ToShortDateString(), ChangeHagashaCB.Checked);
        if (res1 == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שיעורי בית נוספו בהצלחה'); location.href='THomeWorkInsert.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בהוספת שיעורי בית, בדוק נתונים');", true);
        }
    }
}