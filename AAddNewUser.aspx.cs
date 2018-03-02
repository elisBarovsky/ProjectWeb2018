using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VisiblePupilFalse(false);
            VisibleTeacherFalse(false);
            VisibleParentFalse(false);
            AddUserBTN.Visible = false;
        }
    }

    protected void UserTypeDLL_CheckedChanged(object sender, EventArgs e)
    {
        Clear();
        if (UserTypeDLL.SelectedValue =="4")
        {
            VisiblePupilFalse(true);
            VisibleTeacherFalse(false);
            VisibleParentFalse(false);
        }
        else if (UserTypeDLL.SelectedValue == "2")
        {
            VisiblePupilFalse(false);
            VisibleTeacherFalse(true);
            VisibleParentFalse(false);
        }
        else if (UserTypeDLL.SelectedValue == "3")
        {
            VisibleParentFalse(true);
            VisibleTeacherFalse(false);
            VisiblePupilFalse(false);
        }
        else
        {
            VisibleTeacherFalse(false);
            VisiblePupilFalse(false);
            VisibleParentFalse(false);
        }
        AddUserBTN.Visible = true;
    }

    protected void VisiblePupilFalse(bool ans)
    {
        GroupAgeLBL.Visible = ans;
        GroupAgeDLL.Visible = ans;
        ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
    }

    protected void VisibleParentFalse(bool ans)
    {
        ChildIDTB.Visible = ans;
        ChildIDLBL.Visible = ans;
    }

    protected void VisibleTeacherFalse(bool ans)
    {
        MainTeacher.Visible = ans;
       // ClassOtDLL.Visible = ans;
      //  ClassLBL.Visible = ans;
        MainTeacherCB.Visible = ans;
    }

    protected void AddUserBTN_Click(object sender, EventArgs e)
    {
        string folderPath = Server.MapPath("~/Images/");
        string ImgPath = "";
        if (FileUpload1.FileName!="")
        {
            FileUpload1.SaveAs(folderPath + FileUpload1.FileName);
            ImgPath = "/Images/" + FileUpload1.FileName;
            //   ImgPath = folderPath + FileUpload1.FileName;  להוריד ירוק כשיהיה בשרת
        }

        Users NewUser = new Users(UserIDTB.Text, FNameTB.Text, LNameTB.Text, Calendar1.SelectedDate.ToShortDateString(), ImgPath, UserNameTB.Text, PasswordTB.Text, TelephoneNumberTB.Text, UserTypeDLL.SelectedValue);
        int res1 = NewUser.AddUser(NewUser);
        if (res1 == 1)
        {
            if (UserTypeDLL.SelectedValue == "4")
            {
                Users PupilUser = new Users();
                int num = PupilUser.AddPupil(UserIDTB.Text, GroupAgeDLL.SelectedValue,int.Parse(ClassOtDLL.SelectedValue));
            }
            else if (UserTypeDLL.SelectedValue == "2")
            {
                Users TeacherUser = new Users();
                string IsMain = "0";
                if (MainTeacherCB.Checked)   {  IsMain = "1"; int num1 = TeacherUser.AddClassTeacher(UserIDTB.Text, ClassOtDLL.SelectedItem.ToString()); }

                Users MainTeacherUser = new Users();
                int num2 = MainTeacherUser.AddTeacher(UserIDTB.Text, IsMain);
            }
            else if(UserTypeDLL.SelectedValue == "3")  
            {
                Users UsersParentUser = new Users();
                int num4 = UsersParentUser.AddParent(ChildIDTB.Text, UserIDTB.Text); ;
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('משתמש נוסף בהצלחה'); location.href='AAddNewUser.aspx';", true);
        //    AddUserSuuccsed();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בעדכון המשתמש, בדוק נתונים');", true);
            //MessegaeLBL.Text = "הייתה בעיה בהוספת המשתמש, בדוק נתונים";
        }
    }
    protected void Clear()
    {
       // MessegaeLBL.Text = "משתמש נוסף בהצלחה";
        UserIDTB.Text="";
        FNameTB.Text="";
        LNameTB.Text="";
        Calendar1.SelectedDate= Calendar1.TodaysDate;
        UserNameTB.Text="";
        PasswordTB.Text="";
        TelephoneNumberTB.Text="";
       // UserTypeDLL.SelectedValue=null;
        ChildIDTB.Text = "";
        MainTeacherCB.Checked = false;
        ClassOtDLL.Visible = false;
        ClassLBL.Visible = false;
    }

    protected void MainTeacherCB_CheckedChanged(object sender, EventArgs e)
    {
        if (MainTeacherCB.Checked)
        {
            ClassOtDLL.Visible = true;
            ClassLBL.Visible = true;
        }
        else
        {
            ClassOtDLL.Visible = false;
            ClassLBL.Visible = false;
        }
    }
}