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
    Users u = new Users();

    protected void Page_Load()
    {
        if (!IsPostBack)
        {
            FillDays();
            FillMonth();
            FillYear();
        }
    }

    protected void SaveLoginCookie(string ID, string password)
    {
        Response.Cookies["UserID"].Value = ID;
        Response.Cookies["UserID"].Expires = DateTime.Now.AddMinutes(90);
        Response.Cookies["UserPassword"].Value = password;
        Response.Cookies["UserPassword"].Expires = DateTime.Now.AddMinutes(90);
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
                    case 3:
                        Response.Redirect("~~~~~~");
                        break;
                    case 4:
                        Response.Redirect("PupilStartPageaspx.aspx");
                        break;
                }
            }
        }
        else
        {
            Login1.FailureText = "אחד מהפרטים שהזנת שגוים";
        }
    }

    protected void UpdateQuestion(object sender, EventArgs e)
    {
        int q1 = int.Parse(DropDownList_Qlist1.SelectedItem.Value);
        string a1 = TextBox_answer1.Text;
        int q2 = int.Parse(DropDownList_Qlist2.SelectedItem.Value);
        string a2 = TextBox_answer2.Text;
        string id = Login1.UserName;
        int num = User.SaveQuestion(id, q1, a1, q2, a2);
        
        if (num > 0)
        {
           Users User2 = new Users();
            int result= User2.ChangeFirstLogin(id);
            Users User4 = new Users();
            switch (int.Parse(User4.GetUserType(Request.Cookies["UserID"].Value, Request.Cookies["UserPassword"].Value )))
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

    protected void CheckQ2(object sender, EventArgs e)
    {
        if (int.Parse(DropDownList_Qlist2.SelectedItem.Value)==int.Parse(DropDownList_Qlist1.SelectedItem.Value))
        {
            LinkButton_continue.Visible = false;
            LBLEror.Visible = true;
            LBLEror.Text = "אסור 2 שאלות זהות, בחר שאלה אחרת";
        }
        else
        {
            LinkButton_continue.Visible = true;
            LBLEror.Visible = false;
        }
    }
    
    protected void ButtonCheckUserExist_Click(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        string day = DDLday.SelectedValue, month = DDLmonth.SelectedValue, year = DDLyear.SelectedValue;
        string Bday = day + "/" + month + "/" + year;
        if (day == "יום" || month == "חודש" || year == "שנה")
        {
            LBLEror.Visible = true;
            LBLEror.Text = "תאריך הלידה לא יכול להיות ריק";
            return;
        }
        else if (!u.IsLegalBday(day, month))
        {
            LBLEror.Visible = true;
            LBLEror.Text = "תאריך הלידה לא חוקי.";
            return;
        }
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
            LabelSecurityQ1.Text = l.First();
            LabelSecurityQ2.Text = l[2];
        }
    }

    protected void CheckAnswer_Click(object sender, EventArgs e)
    {
        string userID = TextBoxUserID.Text;
        string day = DDLday.SelectedValue, month = DDLmonth.SelectedValue, year = DDLyear.SelectedValue;
        string Bday = day + "/" + month + "/" + year;
        l = User.GetUserSecurityDetailsByuserIDandBday(userID, Bday);
        
        string answer1= TextBoxSecurityA1.Text;
        string answer2 = TextBoxSecurityA2.Text;

        if (l[3]== answer1 && l[1] == answer2)
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

    protected void FillDays()
    {
        List<string> days = new List<string>();

        for (int i = 1; i <= 31; i++)
        {
            days.Add(i.ToString());
        }

        DDLday.DataSource = days;
        DDLday.DataBind();
        DDLday.Items.Insert(0, new ListItem("יום"));
    }

    protected void FillMonth()
    {
        List<string> months = new List<string>();

        for (int i = 1; i <= 12; i++)
        {
            months.Add(i.ToString());
        }

        DDLmonth.DataSource = months;
        DDLmonth.DataBind();
        DDLmonth.Items.Insert(0, new ListItem("חודש"));
    }

    protected void FillYear()
    {
        int year = 1930;
        List<string> years = new List<string>();

        for (int i = 0; year < 2011; i++, year++)
        {
            years.Add(year.ToString());
        }

        DDLyear.DataSource = years;
        DDLyear.DataBind();
        DDLyear.Items.Insert(0, new ListItem("שנה"));
    }
}