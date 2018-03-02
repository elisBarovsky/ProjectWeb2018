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
        if (!IsPostBack)
        {
            ClearAll();
        }
    }

    protected void FillClasses(object sender, EventArgs e)
    {
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Grades ClassGrade = new Grades();
        Classes = ClassGrade.FillClassOt();
        ChooseClassDLL.DataSource = Classes.Values;
        ChooseClassDLL.DataBind();
        Session["ClassesList"] = Classes;
    }

    protected void FillSubjects(object sender, EventArgs e)
    {
        Dictionary<string, string> Lessons = new Dictionary<string, string>();
        Grades ClassGrade = new Grades();
        Lessons = ClassGrade.FillLessons();
        ChooseLessonsDLL.DataSource = Lessons.Values;
        ChooseLessonsDLL.DataBind();
        Session["ClassesList"] = Lessons;
    }

    protected void AddGrades_Click(object sender, EventArgs e)
    {

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

    protected void ClearAll()
    {
        //UserIDTB.Text = "";
        //FNameTB.Text = "";
        //LNameTB.Text = "";
        //Calendar1.SelectedDate = Calendar1.TodaysDate;
        //UserNameTB.Text = "";
        //PasswordTB.Text = "";
        //TelephoneNumberTB.Text = "";
        //ChildIDTB.Text = "";
        //UserIMG.ImageUrl = "";
        //UserIMG.Visible = false;
        //BirthDateTB.Text = "";
        //ChangeBdateCB.Visible = false;
        //ChangeBdateCB.Checked = false;
        //Calendar1.Visible = false;
        //ChildIDTB.Visible = false;
        //ChildIDLBL.Visible = false;
        //MainTeacher.Visible = false;
        //MainTeacherCB.Visible = false;
    }
}