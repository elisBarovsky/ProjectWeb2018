using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TTelphoneNumbers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            FillClasses();
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

    protected void TLBTN_Click(object sender, EventArgs e)
    {
        string UserTypeFilter = FilterNotes.SelectedValue;

        Dictionary<string, string> List = new Dictionary<string, string>();
        List = (Dictionary<string, string>)(Session["ClassesList"]);
        string ClassFilter  = KeyByValue(List, ChooseClassDLL.SelectedValue); ;

        TelphoneList TL = new TelphoneList();
        GridView1.DataSource = TL.FilterTelphoneList(UserTypeFilter, ClassFilter);
        GridView1.DataBind();
    }
}