using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class THomeWorkHistory : System.Web.UI.Page
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

    protected void FilterHWBTN_Click(object sender, EventArgs e)
    {
        if (ChooseClassDLL.SelectedValue=="בחר" || ChooseLessonsDLL.SelectedValue=="בחר מקצוע")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא בחרת כיתה ו/או מקצוע'); ", true);
        }
        else
        {
            string TeacherId = Request.Cookies["UserID"].Value;
            Dictionary<string, string> LessonsList = new Dictionary<string, string>();
            LessonsList = (Dictionary<string, string>)(Session["LessonsList"]);
            Dictionary<string, string> ClassesList = new Dictionary<string, string>(); 
            ClassesList = (Dictionary<string, string>)(Session["ClassesList"]);
            DataTable dtt = new DataTable();

            string ClassCode = KeyByValue(ClassesList, ChooseClassDLL.SelectedValue);
            string LessonCode = KeyByValue(LessonsList, ChooseLessonsDLL.SelectedValue);
            HomeWork FilterHomeWork = new HomeWork();
            dtt = FilterHomeWork.FilterHomeWork(TeacherId, LessonCode, ClassCode);
           
            if (dtt.Rows.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('אין היסטוריית שיעורים שהוזנה על ידך עבור הכיתה והמקצוע שנבחר'); ", true);
                GridView1.DataSource = null;
            }
            else
            {
                GridView1.DataSource = dtt;
            }
            GridView1.DataBind();
        }
    }
}