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
            FillClasses();
            FillSubjects();
        }
    }

    protected void FillPupils(object sender, EventArgs e)
    {
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Classes = (Dictionary<string, string>)(Session["ClassesList"]);
        string ClassCode = KeyByValue(Classes, ChooseClassDLL.SelectedValue);

        Grades ClassPupilGrades = new Grades();

        GridView1.DataSource = ClassPupilGrades.PupilList(ClassCode);
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        FillPupils(sender,e);
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        FillPupils(sender, e); 
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string PupilID = (string)e.NewValues["UserID"];
        string PupilName = (string)e.NewValues["PupilName"];
        string Grade = (string)e.NewValues["Grade"];
        string TeacherId = Request.Cookies["UserID"].Value;

        // Update here the database record for the selected patientID
        Dictionary<string, string> Lessons = new Dictionary<string, string>();
        Lessons = (Dictionary<string, string>)(Session["LessonsList"]);

        Grades InsertPupilGrade = new Grades();
        InsertPupilGrade.InsertGrade(PupilID, TeacherId, KeyByValue(Lessons, ChooseLessonsDLL.SelectedValue), Calendar1.SelectedDate.ToShortDateString(), int.Parse(Grade));
        GridView1.EditIndex = -1;
        FillPupils(sender, e);
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