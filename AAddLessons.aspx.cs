using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AAddLessons : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
    }

    protected void AddLessonsBTN_Click(object sender, EventArgs e)
    {
        Subject newS = new Subject();
        string newSubject = LessonsNameTB.Text;
        if (newS.IsExists(newSubject))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('המקצוע כבר קיים ברשימת המקצועות.');", true);
            return;
        }
        else if ( newSubject == "")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא הוזן מקצוע.');", true);
            return;
        }
        else
        {
            int answer = newS.AddNewSubject(newSubject);
            if (answer > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('מקצוע חדש נוסף.');", true);
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('עקב תקלה לא ניתן להוסיף מקצוע זה.<br/> אנא נסה מאוחר יותר. במידה והתקלה נמשכת אנא פנה לשירות הלקוחות.');", true);
            }
        }
    }
}