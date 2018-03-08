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
        //string TotalClassName = OtClassDDL.SelectedValue + NumClassDDL.SelectedValue;
        //Classes IsExitss = new Classes();
        //List<string> ClassesTotalName = new List<string>();
        //ClassesTotalName = IsExitss.ClassesExites(OtClassDDL.SelectedValue, NumClassDDL.SelectedValue);
        //if (ClassesTotalName.Count() > 0)
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הכיתה קיימת, נסה מספר אחר.');", true);
        //}
        //else
        //{
        //    Classes InsertClass = new Classes();
        //    int res = InsertClass.InsertClass(OtClassDDL.SelectedValue, NumClassDDL.SelectedValue);
        //    if (res == 1)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הכיתה נוספה בהצלחה'); location.href='AAddClasses.aspx';", true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בהכנסת הכיתה, פנה לשירות לקוחות');", true);
        //    }
        //}
    }
}