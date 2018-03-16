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
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
        
        if (!IsPostBack)
        {
            FillDays();
            FillMonth();
            FillYear();
        }
    }

    //protected void FillClasses()
    //{
    //    Dictionary<string, string> Classes = new Dictionary<string, string>();
    //    Grades ClassGrade = new Grades();
    //    Classes = ClassGrade.FillClassOt();
    //    ChooseClassDLL.DataSource = Classes.Values;
    //    ChooseClassDLL.DataBind();
    //    Session["ClassesList"] = Classes;
    //}

    //protected void FillSubjects()
    //{
    //    Dictionary<string, string> Lessons = new Dictionary<string, string>();
    //    Grades ClassGrade = new Grades();
    //    Lessons = ClassGrade.FillLessons();
    //    ChooseLessonsDLL.DataSource = Lessons.Values;
    //    ChooseLessonsDLL.DataBind();
    //    Session["LessonsList"] = Lessons;
    //}

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
        ClassCode = ChooseClassDLL.SelectedValue;
        Subject s = new Subject();
        string LessonsCode = s.GetSubjectCodeBySubjectName(ChooseLessonsDLL.SelectedValue);
        

        string date = DateTime.Today.ToShortDateString();
        string TeacherId = Request.Cookies["UserID"].Value;

        HomeWork HW = new HomeWork();
        Users u = new Users();
        string day = DDLday.SelectedValue, month = DDLmonth.SelectedValue, year = DDLyear.SelectedValue;
        string Bday = day + "/" + month + "/" + year;
        if (day == "יום" || month == "חודש" || year == "שנה")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך לא יכול להיות ריק');", true);
            return;
        }
        else if (!u.IsLegalBday(day, month))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך לא חוקי');", true);
            return;
        }
        int res1 = HW.InserHomeWork(LessonsCode, HomeWorkDesc.Text, TeacherId, ClassCode, Bday, ChangeHagashaCB.Checked);
        if (res1 == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('שיעורי בית נוספו בהצלחה'); location.href='THomeWorkInsert.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בהוספת שיעורי בית, בדוק נתונים');", true);
        }
    }

    protected void FillDays()
    {
        List<string> days = new List<string>();

        for (int i = 1; i <= 31; i++)
        {
            days.Add(i.ToString());
        }

        DDLday.DataSource = days;
        DDLday.DataBind();
        DDLday.Items.Insert(0, new ListItem("יום"));
    }

    protected void FillMonth()
    {
        List<string> months = new List<string>();

        for (int i = 1; i <= 12; i++)
        {
            months.Add(i.ToString());
        }

        DDLmonth.DataSource = months;
        DDLmonth.DataBind();
        DDLmonth.Items.Insert(0, new ListItem("חודש"));
    }

    protected void FillYear()
    {
        string year = DateTime.Now.Year.ToString();
        List<string> years = new List<string>();
        years.Add(year);

        DDLyear.DataSource = years;
        DDLyear.DataBind();
        DDLyear.Items.Insert(0, new ListItem("שנה"));
    }

    protected void ChooseClassDLL_SelectedIndexChanged(object sender, EventArgs e)
    {
        string classCode = ChooseClassDLL.SelectedItem.Value;
        Subject s = new Subject();
        Dictionary<string, string> l = s.GetSubjectsByClassCode(classCode);
        ChooseLessonsDLL.DataSource = l.Values;
        ChooseLessonsDLL.DataBind();
        ChooseLessonsDLL.Enabled = true;

    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));
    }
}