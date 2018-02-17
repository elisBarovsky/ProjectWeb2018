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
        }
    }

    protected void UserTypeDLL_CheckedChanged(object sender, EventArgs e)
    {
        if (UserTypeDLL.SelectedValue =="4")
        {
            VisiblePupilFalse(true);
        }
        else if (UserTypeDLL.SelectedValue == "2")
        {
            VisibleTeacherFalse(true);
        }
        else
        {
            VisibleTeacherFalse(false);
            VisiblePupilFalse(false);
        }
    }
    protected void VisiblePupilFalse(bool ans)
    {
        GroupAgeLBL.Visible = ans;
        GroupAgeDLL.Visible = ans;
        ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
    }

    protected void VisibleTeacherFalse(bool ans)
    {
        MainTeacher.Visible = ans;
        ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
        MainTeacherCB.Visible = ans;
    }

    protected void AddUserBTN_Click(object sender, EventArgs e)
    {
        string folderPath = Server.MapPath("~/images/");
        FileUpload1.SaveAs(folderPath + FileUpload1.FileName);
        
        Users NewUser = new Users(UserIDTB.Text, FNameTB.Text, LNameTB.Text, Calendar1.SelectedDate.ToShortDateString(), folderPath + FileUpload1.FileName, UserNameTB.Text, PasswordTB.Text, TelephoneNumberTB.Text, UserTypeDLL.SelectedValue);
        int res1 = NewUser.AddUser(NewUser);

        if (res1 == 1)
        {
            if (UserTypeDLL.SelectedValue == "4")
            {
                int num=  NewUser.AddPupil(UserIDTB.Text, GroupAgeDLL.SelectedValue,int.Parse(ClassOtDLL.SelectedValue));
            }
            else if (MainTeacherCB.Checked)
            {
                int num1 = NewUser.AddClassTeacher(UserIDTB.Text, ClassOtDLL.SelectedItem.ToString());
            }
            AddUserSuuccsed();
    }
        else
        {
            MessegaeLBL.Text = "הייתה בעיה בהוספת המשתמש, בדוק נתונים";
        }
    }
    protected void AddUserSuuccsed()
    {
        MessegaeLBL.Text = "משתמש נוסף בהצלחה";
        UserIDTB.Text="";
        FNameTB.Text="";
        LNameTB.Text="";
        Calendar1.SelectedDate= Calendar1.TodaysDate;
        UserNameTB.Text="";
        PasswordTB.Text="";
        TelephoneNumberTB.Text="";
        UserTypeDLL.SelectedValue=null;
    }

}