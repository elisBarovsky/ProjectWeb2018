using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AAddClasses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            FillClassesOt();
            FillClassesNum();
        }
    }

    protected void FillClassesOt()
    {
        List<string> ClassesOt = new List<string>();
        Classes ClassGrade = new Classes();
        ClassesOt = ClassGrade.GetClassesOt();
        OtClassDDL.DataSource = ClassesOt;
        OtClassDDL.DataBind();
        Session["ClassesOt"] = ClassesOt;
    }

    protected void FillClassesNum()
    {
        List<string> ClassNum = new List<string>();
        for (int i = 1; i <= 10; i++)
        {
            ClassNum.Add(i.ToString());
        }

        NumClassDDL.DataSource = ClassNum;
        NumClassDDL.DataBind();
        Session["ClassNum"] = ClassNum;
    }

    protected void AddClassBTN_Click(object sender, EventArgs e)
    {
        string TotalClassName = OtClassDDL.SelectedValue + NumClassDDL.SelectedValue;
        Classes IsExitss = new Classes();
        List<string> ClassesTotalName = new List<string>();
        ClassesTotalName=IsExitss.ClassesExites(OtClassDDL.SelectedValue, NumClassDDL.SelectedValue);
        if (ClassesTotalName.Count()>0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הכיתה קיימת, נסה מספר אחר.');", true);
        }
        else
        {
            Classes InsertClass = new Classes();
            int res=  InsertClass.InsertClass(OtClassDDL.SelectedValue, NumClassDDL.SelectedValue);
            if (res==1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הכיתה נוספה בהצלחה'); location.href='AAddClasses.aspx';", true);
            }
            else
            {
              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('עקב תקלה לא ניתן להוסיף מקצוע זה.<br/> אנא נסה מאוחר יותר. במידה והתקלה נמשכת אנא פנה לשירות הלקוחות.');", true);
            }
        }
    }
}