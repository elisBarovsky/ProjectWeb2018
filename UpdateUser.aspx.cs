using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VisiblePupil(false);
            VisibleOtherUsers(false);
        }
    }

    protected void UserTypeDLL_CheckedChanged(object sender, EventArgs e)
    {
        if (UserTypeDLL.SelectedValue == "4")
        {
            VisiblePupil(true);
            VisibleOtherUsers(false);
        }
        else
        {
            VisiblePupil(false);
            VisibleOtherUsers(true);
        }
    }

    protected void UserChosed(object sender, EventArgs e)
    {
        string UserID = "";
        if (UserTypeDLL.SelectedValue == "4")
        {
             UserID = PupilDLL.SelectedValue;
        }
        else
        {
             UserID = OtherUsersDLL.SelectedValue;
        }
        Users UserImg = new Users();

        UserIMG.ImageUrl = UserImg.GetUserIMG(UserID);
       
    }

    protected void VisiblePupil(bool ans)
    {
         ChoosePupilLBL.Visible = ans;
        PupilDLL.Visible = ans;
       ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
    }

    protected void VisibleOtherUsers(bool ans)
    {
        OtherUsersDLL.Visible = ans;
        ChooseOtherUsers.Visible = ans;
        //ChildIDTB.Visible = ans;
        //ChildIDLBL.Visible = ans;
    }

  

    protected void UpdateUserSuccssed()
    {
        MessegaeLBL.Text = "משתמש נוסף בהצלחה";
        UserIDTB.Text = "";
        FNameTB.Text = "";
        LNameTB.Text = "";
        Calendar1.SelectedDate = Calendar1.TodaysDate;
        UserNameTB.Text = "";
        PasswordTB.Text = "";
        TelephoneNumberTB.Text = "";
        UserTypeDLL.SelectedValue = null;
        ChildIDTB.Text = "";
    }
}