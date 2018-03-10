using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Teacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadUser();
        }
    }

    public void LoadUser()
    {
        string TeacherId = Request.Cookies["UserID"].Value;
        Users UserInfo_ = new Users();
        TeacherIMG.Visible = true;

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(TeacherId);
        TeacherNameLBL.Text = "שלום " + UserInfo[0] + " " + UserInfo[1];


        if (UserInfo[5] == "")
        {
            TeacherIMG.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            TeacherIMG.ImageUrl = UserInfo[5];
        }
    }
}