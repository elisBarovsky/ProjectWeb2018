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
        pupils = Pupil.getPupils(ClassOt1DLL.SelectedValue);
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
        ClassOt1DLL.Visible = ans;
        Class1LBL.Visible = ans;
        Class2LBL.Visible = ans;
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

    protected void UpdateUserBTN_Click(object sender, EventArgs e) //******************* להתאים עד הסוף שינויים
    {
        string folderPath = Server.MapPath("~/Images/");
        FileUpload1.SaveAs(folderPath + FileUpload1.FileName);
                                                                                                                            //folderPath // להוריד ירוק כשיהיה בשרת
        Users NewUser = new Users(UserIDTB.Text, FNameTB.Text, LNameTB.Text, Calendar1.SelectedDate.ToShortDateString(), "/Images/" + FileUpload1.FileName, UserNameTB.Text, PasswordTB.Text, TelephoneNumberTB.Text, UserTypeDLL.SelectedValue);
        int res1 = NewUser.AddUser(NewUser);
        Users PupilUser = new Users();
        if (res1 == 1)
        {
            if (UserTypeDLL.SelectedValue == "4")
            {
                int num = PupilUser.AddPupil(UserIDTB.Text, GroupAgeDLL.SelectedValue, int.Parse(ClassOt2DLL.SelectedValue));
            }
            else if (UserTypeDLL.SelectedValue == "2")
            {
                Users TeacherUser = new Users();
                string IsMain = "0";
               // if (MainTeacherCB.Checked) { IsMain = "1"; int num1 = TeacherUser.AddClassTeacher(UserIDTB.Text, ClassOt2DLL.SelectedItem.ToString()); }

                Users MainTeacherUser = new Users();
                int num2 = MainTeacherUser.AddTeacher(UserIDTB.Text, IsMain, ClassOt2DLL.SelectedItem.ToString());
            }
            else if (UserTypeDLL.SelectedValue == "3")
            {
                Users UsersParentUser = new Users();
                int num4 = UsersParentUser.AddParent(ChildIDTB.Text, UserIDTB.Text); ;
            }
            UpdateUserSuccssed();
        }
        else
        {
            MessegaeLBL.Text = "הייתה בעיה בעדכון המשתמש, בדוק נתונים";
        }
    }
}