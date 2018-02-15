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

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
         switch (int.Parse(User.GetUserType(Login1.UserName, Login1.Password)))
         {
            case 1:
                Response.Redirect("Admin.aspx");
                break;
            case 2:
                Response.Redirect("Teacher.aspx");
                break;
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        if (Pass1.Text==Pass2.Text)
        {
            // חסרה הפונקציה ששומרת סיסמה בפועל בDB
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        Button2.Visible = false;
        loginPage.Visible = true;
        Label1.Visible = false;
    }
}