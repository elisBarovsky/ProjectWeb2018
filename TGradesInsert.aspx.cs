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
        //if (!IsPostBack)
        {
            ClearAll();
            //FillClasses();
            //FillSubjects();
        }
    }

    protected void FillPupils(object sender, EventArgs e)
    {
        //Dictionary<string, string> Classes = new Dictionary<string, string>();
        //Classes = (Dictionary<string, string>)(Session["ClassesList"]);
        //string ClassCode = KeyByValue(Classes, ChooseClassDLL.SelectedValue);

        CreatePupilsListByClassCode();

        //Grades ClassPupilGrades = new Grades();

        //GridView1.DataSource = ClassPupilGrades.PupilList(ClassCode);
        //GridView1.DataBind();
    }

    protected void CreatePupilsListByClassCode()
    {
        string ClassCode = ChooseClassDLL.SelectedValue;

        List<Dictionary<string, string>> pupils = new List<Dictionary<string, string>>();
        Users u = new Users();
        pupils = u.getPupilsByClassCode(ClassCode);

        string[] tytles = new string[] { "ציון", "שם", "ת.ז." };
        TableRow tr = new TableRow();

        for (int i = 0; i < 3; i++)
        {
            TableCell tytle = new TableCell();
            tytle.Text = tytles[i];
            tr.Cells.Add(tytle);
        }
        tableGrades.Rows.Add(tr);

        for (int i = 0; i < pupils.Count; i++)
        {
            TableRow row = new TableRow();

            TableCell grade = new TableCell();
                TextBox tb = new TextBox();
                tb.Text = "";
                grade.Controls.Add(tb);
                row.Cells.Add(grade);

                TableCell name = new TableCell();
                name.Text = pupils[i]["UserName"];
                row.Cells.Add(name);

                TableCell id = new TableCell();
                id.Text = pupils[i]["UserId"];
                row.Cells.Add(id);

                tableGrades.Rows.Add(row);
        }
    }

    //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    GridView1.EditIndex = e.NewEditIndex;
    //    FillPupils(sender,e);
    //}

    //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    GridView1.EditIndex = -1;
    //    FillPupils(sender, e); 
    //}

    //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    string PupilID = (string)e.NewValues["UserID"];
    //    string PupilName = (string)e.NewValues["PupilName"];
    //    string Grade = (string)e.NewValues["Grade"];
    //    string TeacherId = Request.Cookies["UserID"].Value;

    //    // Update here the database record for the selected patientID
    //    Dictionary<string, string> Lessons = new Dictionary<string, string>();
    //    Lessons = (Dictionary<string, string>)(Session["LessonsList"]);

    //    Grades InsertPupilGrade = new Grades();
    //    InsertPupilGrade.InsertGrade(PupilID, TeacherId, KeyByValue(Lessons, ChooseLessonsDLL.SelectedValue), Calendar1.SelectedDate.ToShortDateString(), int.Parse(Grade));
    //    GridView1.EditIndex = -1;
    //    FillPupils(sender, e);
    //}

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

    protected void AddGrades_Click(object sender, EventArgs e)
    {
        //int classCode = int.Parse(ChooseClassDLL.SelectedValue);
        string codeLesson = ChooseLessonsDLL.SelectedValue;
        string teacherId = Request.Cookies["UserID"].ToString();
        string date = Calendar1.SelectedDate.ToShortDateString();
        Grades g = new Grades();

        for (int i = 0; i < tableGrades.Rows.Count; i++)
        {
            int grade = int.Parse(tableGrades.Rows[i].Cells[0].ToString());
            string pupilId = tableGrades.Rows[i].Cells[2].ToString();
            int num = g.InsertGrade(pupilId, teacherId, codeLesson, date,grade);
        }
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