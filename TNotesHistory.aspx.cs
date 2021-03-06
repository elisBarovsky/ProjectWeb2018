﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TNotesHistory : System.Web.UI.Page
{
    Dictionary<string, string> List = new Dictionary<string, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            hide(false);
            FillClasses();
            FillSubjects();
            FillNotes();
        }
    }

    protected void FilterNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (FilterNotes.SelectedValue=="1")//מקצוע
        {
            hide(false);
            ChooseLessonsDLL.Visible = true;
        }
        else if (FilterNotes.SelectedValue == "2")//הערת משמעת
        {
            hide(false);
            NotesDLL.Visible = true;
        }
        else if (FilterNotes.SelectedValue == "3")//תלמיד
        {
            hide(false);
            ChooseClassDLL.Visible = true;
        }
        else//מורה
        {
            hide(false);
        }
    }

    protected void FillPupils(object sender, EventArgs e)
    {
        PupilsDLL.Visible = true;
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

    public void hide(bool ans)
    {
        ChooseLessonsDLL.Visible = ans;
        NotesDLL.Visible = ans;
        PupilsDLL.Visible = ans;
        ChooseClassDLL.Visible = ans;
    }

    protected void FilterNotesBTN_Click(object sender, EventArgs e)
    {
        string FilterType = "";
        string ValueFilter = "";

        if (FilterNotes.SelectedValue == "1")//מקצוע
        {
            List = (Dictionary<string, string>)(Session["LessonsList"]);
            FilterType = "dbo.GivenNotes.LessonsCode";
            ValueFilter = KeyByValue(List, ChooseLessonsDLL.SelectedValue);
        }
        else if (FilterNotes.SelectedValue == "2")//הערת משמעת
        {
            List = (Dictionary<string, string>)(Session["NotesList"]);
            FilterType = "dbo.NoteType.CodeNoteType";
            ValueFilter = KeyByValue(List, NotesDLL.SelectedValue);
        }
        else if (FilterNotes.SelectedValue == "3")//תלמיד
        {
            List = (Dictionary<string, string>)(Session["PupilsList"]);
            FilterType = "dbo.Pupil.UserID";
            ValueFilter = KeyByValue(List, PupilsDLL.SelectedValue);
        }
        else//מורה
        {
            FilterType = "dbo.GivenNotes.TeacherID";
            ValueFilter = Request.Cookies["UserID"].Value;
        }

        Notes FilterNote = new Notes();
        GridView1.DataSource = FilterNote.FilterNotes(FilterType, ValueFilter);
        GridView1.DataBind();
    }
}