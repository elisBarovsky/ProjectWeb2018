﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewUser : System.Web.UI.Page
{
    Users u = new Users();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["UserID"] == null || Request.Cookies["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }

        if (!IsPostBack)
        {
            VisiblePupilFalse(false);
            VisibleTeacherFalse(false);
            VisibleParentFalse(false);
            AddUserBTN.Visible = false;
            FillNumChilds();
            HideChildTBID();
            FillDays();
            FillMonth();
            FillYear();
        }
    }

    protected void FillFirstItem(object sender, EventArgs e)
    {
        (sender as DropDownList).Items.Insert(0, new ListItem("בחר", "0"));
    }

    private void FillNumChilds()
    {
        List<int> NumChild = new List<int>();
        for (int i = 1; i < 7; i++)
        {
            NumChild.Add(i);
        }
        NumOfChildDDL.DataSource = NumChild;
        NumOfChildDDL.DataBind();
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
        //GroupAgeLBL.Visible = ans;
        //GroupAgeDLL.Visible = ans;
        ClassOtDLL.Visible = ans;
        ClassLBL.Visible = ans;
    }

    protected void VisibleParentFalse(bool ans)
    {
        ChildIDLBL.Visible = ans;
        NumOfChildDDL.Visible = ans;
        NumChildLBL.Visible = ans;
        ChildI1DTB.Visible = ans;
    }

    protected void HideChildTBID()
    {       
        ChildI2DTB.Visible = false;
        ChildI3DTB.Visible = false;
        ChildI4DTB.Visible = false;
        ChildI5DTB.Visible = false;
        ChildI6DTB.Visible = false;
    }

    protected void VisibleTeacherFalse(bool ans)
    {
        MainTeacher.Visible = ans;
        MainTeacherCB.Visible = ans;
    }
    //this function changed**************************************************************************************************************************************************************
    protected void AddUserBTN_Click(object sender, EventArgs e)
    {
        string folderPath = Server.MapPath("~/Images/");
        string ImgPath = "";
        if (FileUpload1.FileName!="")
        {
            FileUpload1.SaveAs(folderPath + FileUpload1.FileName);
               ImgPath = "/Images/" + FileUpload1.FileName;
        }
        string day = DDLday.SelectedValue, month = DDLmonth.SelectedValue, year = DDLyear.SelectedValue;
        if (day == "יום" || month == "חודש" || year == "שנה")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך הלידה לא יכול להיות ריק');", true);
            return;
            
        }
        else if (!u.IsLegalBday(day, month))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('תאריך הלידה לא תקני.');", true);
            return;
        }
        else if (ClassOtDLL.SelectedValue == "בחר")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('לא נבחרה כיתה.');", true);
            return;
        }
        string bDay = day + "/" + month + "/" + year;
        Users NewUser = new Users(UserIDTB.Text, FNameTB.Text, LNameTB.Text, bDay, ImgPath, "", PasswordTB.Text, TelephoneNumberTB.Text, UserTypeDLL.SelectedValue);
        Administrator admin = new Administrator();
        int res1 = admin.AddUser(NewUser);
        if (res1 == 1)
        {
            if (UserTypeDLL.SelectedValue == "4")
            {
                Administrator a = new Administrator();
                int num = a.AddPupil(UserIDTB.Text,int.Parse(ClassOtDLL.SelectedValue));
            }
            else if (UserTypeDLL.SelectedValue == "2")
            {
                Administrator d = new Administrator();
                string IsMain = "0";
                if (MainTeacherCB.Checked)   {  IsMain = "1"; int num1 = d.AddClassTeacher(UserIDTB.Text, ClassOtDLL.SelectedItem.ToString()); }

                int num2 = d.AddTeacher(UserIDTB.Text, IsMain);
            }
            else if(UserTypeDLL.SelectedValue == "3")  
            {
                    //string[] ChildID = new string[int.Parse(NumOfChildDDL.SelectedValue)];
                string[] ChildID = new string[6];

                    ChildID[0] = ChildI1DTB.Text;
                    ChildID[1] = ChildI2DTB.Text;
                    ChildID[2] = ChildI3DTB.Text;
                    ChildID[3] = ChildI4DTB.Text;
                    ChildID[4] = ChildI5DTB.Text;
                    ChildID[5] = ChildI6DTB.Text;

                    for (int i = 0; i < ChildID.Length; i++)
                    {
                        if (ChildID[i]!="")
                        {
                            Users GetPupilClass = new Users();
                            string ChildCodeClass= GetPupilClass.GetPupilOtClass(ChildID[i]);
                            Administrator AddMoreThanOneChild = new Administrator();
                            AddMoreThanOneChild.AddParent(UserIDTB.Text, ChildID[i],ChildCodeClass);
                        }
                    }
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('משתמש נוסף בהצלחה'); location.href='AAddNewUser.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('הייתה בעיה בעדכון המשתמש, בדוק נתונים');", true);
        }
    }

    protected void Clear()
    {
        UserIDTB.Text = "";
        FNameTB.Text = "";
        LNameTB.Text = "";
        DDLday.SelectedValue = "יום";
        DDLmonth.SelectedValue = "חודש";
        DDLyear.SelectedValue = "שנה";
        PasswordTB.Text = "";
        TelephoneNumberTB.Text = "";
        MainTeacherCB.Checked = false;
        ClassOtDLL.Visible = false;
        ClassLBL.Visible = false;
        ChildI1DTB.Text = "";
        ChildI2DTB.Text = "";
        ChildI3DTB.Text = "";
        ChildI4DTB.Text = "";
        ChildI5DTB.Text = "";
        ChildI6DTB.Text = "";
    }

    protected void FillDays()
    {
        List<string> days = new List<string>();

        for (int i = 1; i <= 31; i++)
        {
            if (i<10)
            {
                days.Add("0"+i.ToString());
            }
            else
            {
                days.Add(i.ToString());
            }
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
            if (i < 10)
            {
                months.Add("0" + i.ToString());
            }
            else
            {
                months.Add(i.ToString());
            }         
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

    protected void NumOfChildDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (NumOfChildDDL.SelectedValue)
        {
            case "1":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = false;
                ChildI3DTB.Visible = false;
                ChildI4DTB.Visible = false;
                ChildI5DTB.Visible = false;
                ChildI6DTB.Visible = false;
                break;
            case "2":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = false;
                ChildI4DTB.Visible = false;
                ChildI5DTB.Visible = false;
                ChildI6DTB.Visible = false;
                break;
            case "3":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = true;
                ChildI4DTB.Visible = false;
                ChildI5DTB.Visible = false;
                ChildI6DTB.Visible = false;
                break;
            case "4":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = true;
                ChildI4DTB.Visible = true;
                ChildI5DTB.Visible = false;
                ChildI6DTB.Visible = false;
                break;
            case "5":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = true;
                ChildI4DTB.Visible = true;
                ChildI5DTB.Visible = true;
                ChildI6DTB.Visible = false;
                break;
            case "6":
                ChildI1DTB.Visible = true;
                ChildI2DTB.Visible = true;
                ChildI3DTB.Visible = true;
                ChildI4DTB.Visible = true;
                ChildI5DTB.Visible = true;
                ChildI6DTB.Visible = true;
                break;
        }
    }
}