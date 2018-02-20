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
            ClearAll();
        }
    }

    protected void UserTypeDLL_CheckedChanged(object sender, EventArgs e)
    {
         ClearAll();
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

    protected void FillPupils(object sender, EventArgs e)
    {
        Users Pupil = new Users();
        Dictionary<string, string> pupils = new Dictionary<string, string>();
        pupils = Pupil.getPupils(ClassOtDLL.SelectedValue);
        PupilDLL.DataSource = pupils.Values;
        PupilDLL.DataBind();
        Session["PupilsList"] = pupils;
    }

    protected void UserChosed(object sender, EventArgs e)
    {
        string UserID = "";
        if (UserTypeDLL.SelectedValue == "4")
        {
            UserID = PupilDLL.SelectedValue;
            Users PupilGroupID = new Users();
            Dictionary<string, string> pupils = new Dictionary<string, string>();
            pupils = (Dictionary<string, string>)(Session["PupilsList"]);
            
         //   GroupAgeDLL.SelectedValue = PupilGroupID.GetPupilGroup(pupils[UserID]);    יש בעיה למשוך את התעודת זהות
        }
        else
        {
             UserID = OtherUsersDLL.SelectedValue;
        }

        Users UserInfo_ = new Users();
        UserIMG.Visible = true;

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(UserID);
        UserIDTB.Text = UserInfo[0];
        FNameTB.Text = UserInfo[1];
        LNameTB.Text = UserInfo[2];
        BirthDateTB.Text = UserInfo[3];
        ChangeBdateCB.Visible = true;
        UserNameTB.Text = UserInfo[4];
        PasswordTB.Text = UserInfo[5];
        TelephoneNumberTB.Text = UserInfo[6];
        UserIMG.ImageUrl = UserInfo[7];
        
    }

    protected void ShowCalendar_(object sender, EventArgs e)
    {
        if (ChangeBdateCB.Checked==true )
        {
            Calendar1.Visible = true;
        }
        else
        {
            Calendar1.Visible = false;
        }
    }

    protected void VisiblePupil(bool ans)
    {
        ChoosePupilLBL.Visible = ans;
        PupilDLL.Visible = ans;
        ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
        GroupAgeLBL.Visible = ans;
        GroupAgeDLL.Visible = ans;
    }

    protected void VisibleOtherUsers(bool ans)
    {
        OtherUsersDLL.Visible = ans;
        ChooseOtherUsers.Visible = ans;
       
    }
  
    protected void UpdateUserSuccssed()
    {
        MessegaeLBL.Text = "משתמש נוסף בהצלחה";
        Calendar1.SelectedDate = Calendar1.TodaysDate;
        UserTypeDLL.SelectedValue = null;
        ClearAll();
    }
    
    protected void ClearAll()
    {
        UserIDTB.Text = "";
        FNameTB.Text = "";
        LNameTB.Text = "";
        Calendar1.SelectedDate = Calendar1.TodaysDate;
        UserNameTB.Text = "";
        PasswordTB.Text = "";
        TelephoneNumberTB.Text = "";
        ChildIDTB.Text = "";
        UserIMG.ImageUrl = "";
        UserIMG.Visible = false;
        BirthDateTB.Text = "";
        ChangeBdateCB.Visible = false;
        ChangeBdateCB.Checked = false;
        Calendar1.Visible = false;
        ChildIDTB.Visible = false;
        ChildIDLBL.Visible = false;
    }
}