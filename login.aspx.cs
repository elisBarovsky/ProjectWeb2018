using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    Users User = new Users();
    List<string> l = new List<string>();
    Questions q = new Questions();

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
           
        //}
    }
    protected void SaveLoginCookie(string ID, string password)
    {
        Response.Cookies["UserID"].Value = ID;
        Response.Cookies["UserID"].Expires = DateTime.Now.AddMinutes(5);
        Response.Cookies["UserPassword"].Value = password;
        Response.Cookies["UserPassword"].Expires = DateTime.Now.AddMinutes(5);
    }

    protected void FillSecurityQ()
    {   
        firstLogin.Visible = true;
    }

    protected void Login1_Authenticate(object sender, EventArgs e)
    {
        string UserID = Login1.UserName, password = Login1.Password;
        string isAlreadyLogin = User.IsAlreadyLogin(UserID, password);

        SaveLoginCookie(UserID, password);

        if (isAlreadyLogin != "")
        {
            if (!bool.Parse(isAlreadyLogin))
            {
                loginPage.Visible = false;
                FillSecurityQ();
            }

            else
            {
                switch (int.Parse(User.GetUserType(UserID, password)))
                {
                    case 1:
                        Response.Redirect("Admin.aspx");
                        break;
                    case 2:
                        Response.Redirect("Teacher.aspx");
                        break;
                }
            }
        }
        else
        {
            Login1.FailureText = "אחד מהפרטים שהקשת שגוים";
        }
    }
    protected void UpdateQuation(object sender, EventArgs e)
    {
        int q = int.Parse(DropDownList_Qlist.SelectedItem.Value);
        string a = TextBox_answer.Text;
        string id = Login1.UserName;
        int num = User.SaveQuestion(id, q, a);
        
        if (num > 0)
        {
           int result= User.ChangeFirstLogin(id);

            switch (int.Parse(User.GetUserType(Request.Cookies["UserID"].Value, Request.Cookies["UserPassword"].Value )))
            {
                case 1:
                    Response.Redirect("Admin.aspx");
                    break;
                case 2:
                    Response.Redirect("Teacher.aspx");
                    break;
            }
        }
    }
    protected void IforgotPassword(object sender, EventArgs e)
    {
        loginPage.Visible = false;
        forgetMyPassword.Visible = true;
    }

    protected void ButtonCheckUserExist_Click(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        string Bday = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
         l = User.GetUserSecurityDetailsByuserIDandBday(userID, Bday);
        
        if (l.Count() == 0)
        {
            LBLEror.Visible = true;
            LBLEror.Text = "תאריך הלידה ו/או תעודת הזהות שגויים";
        }
        else
        {
            forgetMyPassword.Visible = false;
            LBLEror.Visible = false;
            securityQ.Visible = true;
            LabelSecurityQ.Text = l.First();
        }
    }

    protected void CheckAnswer_Click(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        string Bday = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        l = User.GetUserSecurityDetailsByuserIDandBday(userID, Bday);
        
        string answer= TextBoxSecurityA.Text;

        if (l[1]== answer)
        {
            ChangePassword.Visible = true;
            securityQ.Visible = false;
        }
        else
        {
            LBLEror.Visible = true;
            Label1.Text = "תשובה שגויה";
        }
    }

    protected void ChangePasswordBTN(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        if (Pass1.Text==Pass2.Text)
        {
            int num = User.ChangePassword(userID, Pass1.Text);
            if (num > 0)
            {
                ChangePassword.Visible = false;
                Label1.Text = "סיסמתך שונתה בהצלחה, לחץ על הכפתור להתחברות מחדש" + "<img src = 'Images/good.png' style='height: 45px'/>";
                Button2.Visible = true;
            }
            else Label1.Text = "עקב בעיות טכניות לא ניתן לשמור את סיסמתך כרגע, אנא נסה במועד מאוחר יותר או פנה לשירות הלקוחות" + "<br/><img src = 'Images/Ambulance.png' style='height: 55px'/>"; 
        }
        else
        {
            Label1.Text = "הסיסמאות לא תואמות, נסה שנית";
        }
    }

    protected void BackToLoginBTN(object sender, EventArgs e)
    {
        Button2.Visible = false;
        loginPage.Visible = true;
        Label1.Visible = false;
    }

  
}