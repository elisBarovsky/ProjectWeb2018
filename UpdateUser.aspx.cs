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
            VisibleTeacherUsers(false);
        }
        else if (UserTypeDLL.SelectedValue == "2")
        {
            VisibleTeacherUsers(true);
            VisiblePupil(false);
            VisibleOtherUsers(true);
            FillUsers();
        }
        else
        {
            VisibleTeacherUsers(false);
            VisiblePupil(false);
            VisibleOtherUsers(true);
            FillUsers();
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

    protected void FillUsers()
    {
        Users Users = new Users();
        Dictionary<string, string> UsersList = new Dictionary<string, string>();
        UsersList = Users.FillUsers(UserTypeDLL.SelectedValue);
        OtherUsersDLL.DataSource = UsersList.Values;
        OtherUsersDLL.DataBind();
        Session["UsersList"] = UsersList;
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
            UserID = KeyByValue(pupils, UserID);
            GroupAgeDLL.SelectedValue = PupilGroupID.GetPupilGroup(UserID);  
        }
        else
        {
            UserID = OtherUsersDLL.SelectedValue;
            Dictionary<string, string> Users = new Dictionary<string, string>();
            Users = (Dictionary<string, string>)(Session["UsersList"]);
            UserID = KeyByValue(Users, UserID);
            if (UserTypeDLL.SelectedValue == "2") {

                Users TeacherChecked = new Users();
                bool IsMain = TeacherChecked.GetTeacherMain(UserID);

                if (IsMain)
                {
                    MainTeacherCB.Checked = true;
                    Class2LBL.Visible = true;
                    ClassOt2DLL.Visible = true;
                    Users TeacherMainClass = new Users();
                    ClassOt2DLL.SelectedValue = TeacherMainClass.GetTeacherMainClass(UserID); ;
                }
            }
        }

        Users UserInfo_ = new Users();
        UserIMG.Visible = true;

        List<string> UserInfo = new List<string>();
        UserInfo = UserInfo_.GetUserInfo(UserID);
        
        UserIDTB.Text = UserID;
        FNameTB.Text = UserInfo[0];
        LNameTB.Text = UserInfo[1];
        BirthDateTB.Text = UserInfo[2];
        ChangeBdateCB.Visible = true;
        UserNameTB.Text = UserInfo[3];
        PasswordTB.Text = UserInfo[4];
        TelephoneNumberTB.Text = UserInfo[5];

        if (UserInfo[6]=="")
        {
            UserIMG.ImageUrl = "/Images/NoImg.png";
        }
        else
        {
            UserIMG.ImageUrl = UserInfo[6];
        }
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

    protected void FillTBofBdate(object sender, EventArgs e)
    {
        BirthDateTB.Text = Calendar1.SelectedDate.ToShortDateString();
    }
    
    protected void VisiblePupil(bool ans)
    {
        ChoosePupilLBL.Visible = ans;
        PupilDLL.Visible = ans;
        ClassOt1DLL.Visible = ans;
        Class1LBL.Visible = ans;
        Class2LBL.Visible = ans;
        ClassOt2DLL.Visible = ans;
        GroupAgeLBL.Visible = ans;
        GroupAgeDLL.Visible = ans;
    }

    protected void VisibleOtherUsers(bool ans)
    {
        OtherUsersDLL.Visible = ans;
        ChooseOtherUsers.Visible = ans;
    }

    protected void VisibleTeacherUsers(bool ans)
    {
        MainTeacher.Visible = ans;
        MainTeacherCB.Visible = ans;
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
        MainTeacher.Visible = false;
        MainTeacherCB.Visible = false;
    }

    protected void UpdateUserBTN_Click(object sender, EventArgs e) //******************* להתאים עד הסוף שינויים
    {
        string folderPath = Server.MapPath("~/Images/");
        int res1 = 0;
        Users NewUser = new Users();
        if (FileUpload1.FileName=="")
        {
            if (ChangeBdateCB.Checked == false)
            {
                res1 = NewUser.UpdateUser(UserIDTB.Text, FNameTB.Text, LNameTB.Text, BirthDateTB.Text,"", UserNameTB.Text, PasswordTB.Text, TelephoneNumberTB.Text);
            }
            else
            {
                res1 = NewUser.UpdateUser(UserIDTB.Text, FNameTB.Text, LNameTB.Text, Calendar1.SelectedDate.ToShortDateString(),"", UserNameTB.Text, PasswordTB.Text, TelephoneNumberTB.Text);
            }
        }
        else
        {
            FileUpload1.SaveAs(folderPath + FileUpload1.FileName);

            if (ChangeBdateCB.Checked == false)
            {
                res1 = NewUser.UpdateUser(UserIDTB.Text, FNameTB.Text, LNameTB.Text, BirthDateTB.Text, "/Images/" + FileUpload1.FileName, UserNameTB.Text, PasswordTB.Text, TelephoneNumberTB.Text);
            }
            else
            {
                res1 = NewUser.UpdateUser(UserIDTB.Text, FNameTB.Text, LNameTB.Text, Calendar1.SelectedDate.ToShortDateString(), "/Images/" + FileUpload1.FileName, UserNameTB.Text, PasswordTB.Text, TelephoneNumberTB.Text);
            }
        }                                                                                                                       //folderPath // להוריד ירוק כשיהיה בשרת

        Users PupilUser = new Users();
        if (res1 == 1)
        {
            if (UserTypeDLL.SelectedValue == "4")
            {
                int num = PupilUser.UpdatePupil(UserIDTB.Text, GroupAgeDLL.SelectedValue, ClassOt2DLL.SelectedValue);
            }
            else if (UserTypeDLL.SelectedValue == "2")
            {
                Users TeacherUser = new Users();
                string IsMain = "0";
                if (MainTeacherCB.Checked) { IsMain = "1"; int num1 = TeacherUser.AddClassTeacher(UserIDTB.Text, ClassOt2DLL.SelectedItem.ToString()); }

                Users MainTeacherUser = new Users();
                int num2 = MainTeacherUser.AddTeacher(UserIDTB.Text, IsMain, ClassOt2DLL.SelectedItem.ToString());
            }
            else if (UserTypeDLL.SelectedValue == "3")
            {
                Users UsersParentUser = new Users();
                int num4 = UsersParentUser.UpdateParent(ChildIDTB.Text, UserIDTB.Text); ;
            }

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('משתמש עודכן בהצלחה'); location.href='UpdateUser.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בעדכון המשתמש, בדוק נתונים');", true);
            //MessegaeLBL.Text = "הייתה בעיה בעדכון המשתמש, בדוק נתונים";
        }
    }
}