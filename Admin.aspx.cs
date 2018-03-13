using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            LoadUser();
        }
    }

    public void LoadUser()
    {
       string AdminId= Request.Cookies["UserID"].Value;
        Users UserInfo_ = new Users();
        AdminIMG.Visible = true;

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(AdminId);
        AdminNameLBL.Text = "שלום "+UserInfo[0]+" "+ UserInfo[1];


        if (UserInfo[5] == "")
        {
            AdminIMG.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            AdminIMG.ImageUrl = UserInfo[5];
        }
    }
}