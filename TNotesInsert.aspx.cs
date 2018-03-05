using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TNotesInsert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ClearAll();
            FillClasses();
            FillSubjects();
            FillNotes();
        }
    }

    protected void FillPupils(object sender, EventArgs e)
    {
        string ClassCode = "";
        Dictionary<string, string> Classes = new Dictionary<string, string>();
        Classes = (Dictionary<string, string>)(Session["ClassesList"]);
        ClassCode = KeyByValue(Classes, ChooseClassDLL.SelectedValue);

        Users Pupil = new Users();
        Dictionary<string, string> pupils = new Dictionary<string, string>();

        pupils = Pupil.getPupils(ClassCode);
        PupilsDLL.DataSource = pupils.Values;
        PupilsDLL.DataBind();
        Session["PupilsList"] = pupils;
    }

    protected void FillNotes()
    {
        Dictionary<string, string> Notes = new Dictionary<string, string>();
        Notes PupilNote = new Notes();
        Notes = PupilNote.FillNotes();
        NotesDLL.DataSource = Notes.Values;
        NotesDLL.DataBind();
        Session["NotesList"] = Notes;
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


    protected void AddNotes_Click(object sender, EventArgs e)
    {
        string date = DateTime.Today.ToShortDateString();
        string TeacherId = Request.Cookies["UserID"].Value;
        Dictionary<string, string> NotesList = new Dictionary<string, string>();
        NotesList = (Dictionary<string, string>)(Session["NotesList"]);

        Dictionary<string, string> PupilList = new Dictionary<string, string>();
        PupilList = (Dictionary<string, string>)(Session["PupilsList"]);
        string PupilID = KeyByValue(PupilList, PupilsDLL.SelectedValue);
        string NoteID = KeyByValue(NotesList, NotesDLL.SelectedValue);


        Notes InsertPupilNote = new Notes();

        int res1 = InsertPupilNote.InsertNotes(PupilID, NoteID, date, TeacherId, TNoteTB.Text);
        if (res1 == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הערה נוספה בהצלחה'); location.href='TNotesInsert.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בהוספת הערת משמעת, בדוק נתונים');", true);
        }
    }
}