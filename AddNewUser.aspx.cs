using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //}
        VisibleFalse(false);
    }

    protected void UserTypeDLL_CheckedChanged(object sender, EventArgs e)
    {
        if (UserTypeDLL.SelectedValue =="4")
        {
            VisibleFalse(true);
        }
        else
        {
            VisibleFalse(false);
        }
    }
    protected void VisibleFalse(bool ans)
    {
        GroupAgeLBL.Visible = ans;
        GroupAgeDLL.Visible = ans;
        ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
    }

}