using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TNotesHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hide(false);
        }
    }

    protected void FilterNotes_SelectedIndexChanged(object sender, EventArgs e)
    {
        string FilterType = "";
        string ValueFilter = "";

        if (FilterNotes.SelectedValue=="1")//מקצוע
        {
            hide(false);
            ChooseLessonsDLL.Visible = true;
            FilterType ="";
            ValueFilter ="";
        }
        else if (FilterNotes.SelectedValue == "2")//הערת משמעת
        {
            hide(false);
            NotesDLL.Visible = true;
            FilterType = "dbo.NoteType.CodeNoteType";
            ValueFilter ="";
        }
        else if (FilterNotes.SelectedValue == "3")//תלמיד
        {
            hide(false);
            PupilsDLL.Visible = true;
            FilterType = "dbo.Pupil.UserID";
            ValueFilter ="";
        }
        else//מורה
        {
            hide(false);
            FilterType = "dbo.GivenNotes.TeacherID";
            ValueFilter ="";
        }

        Notes FilterNote = new Notes();

        GridView1.DataSource = FilterNote.FilterNotes(FilterType, ValueFilter);
        GridView1.DataBind();
    }

    public void hide(bool ans)
    {
        ChooseLessonsDLL.Visible = ans;
        NotesDLL.Visible = ans;
        PupilsDLL.Visible = ans;
    }
}