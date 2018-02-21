using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
    DBconnection db;
    string UserID, UserFName, UserLName,  BirthDate, UserImg,  UserName, UserPassword, PhoneNumber, CodeUserType;

    public string UserID1
    {
        get
        {
            return UserID;
        }

        set
        {
            UserID = value;
        }
    }

    public string UserFName1
    {
        get
        {
            return UserFName;
        }

        set
        {
            UserFName = value;
        }
    }

    public string UserLName1
    {
        get
        {
            return UserLName;
        }

        set
        {
            UserLName = value;
        }
    }

    public string BirthDate1
    {
        get
        {
            return BirthDate;
        }

        set
        {
            BirthDate = value;
        }
    }

    public string UserImg1
    {
        get
        {
            return UserImg;
        }

        set
        {
            UserImg = value;
        }
    }

    public string UserName1
    {
        get
        {
            return UserName;
        }

        set
        {
            UserName = value;
        }
    }

    public string UserPassword1
    {
        get
        {
            return UserPassword;
        }

        set
        {
            UserPassword = value;
        }
    }

    public string PhoneNumber1
    {
        get
        {
            return PhoneNumber;
        }

        set
        {
            PhoneNumber = value;
        }
    }

    public string CodeUserType1
    {
        get
        {
            return CodeUserType;
        }

        set
        {
            CodeUserType = value;
        }
    }

    public Users()
    {
        db = new DBconnection();
    }

    public Users(string userID, string userFName, string userLName, string birthDate, string userImg, string userName, string userPassword, string phoneNumber, string codeUserType)
    {
        db = new DBconnection();

        UserID = userID;
        UserFName = userFName;
        UserLName = userLName;
        BirthDate = birthDate;
        UserImg = userImg;
        UserName = userName;
        UserPassword = userPassword;
        PhoneNumber = phoneNumber;
        CodeUserType = codeUserType;
    }

    public int AddPupil(string UserID,string GroupType,int classNumber )
    {
        return db.AddPupil(UserID, GroupType, classNumber);
    }

    public int AddTeacher(string UserID, string IsMain,string ClassOt)
    {
        return db.AddTeacher(UserID, IsMain, ClassOt);
    }

    public Dictionary<string, string> getPupils(string classCode)
    {
        return db.getPupils(classCode);
    }

    public Dictionary<string, string> FillUsers(string CodeUserType)
    {
        return db.FillUsers(CodeUserType);
    }

    public int AddClassTeacher(string UserID, string ClassOt)
    {
        return db.AddMainTeacherToClass(UserID, ClassOt);
    }

    public int AddParent(string PupilID, string ParentID)
    {
        return db.AddParent(PupilID, ParentID);
    }

    public int AddUser(Users NewUser)
    {
        return db.AddUser(NewUser);
    }

    public int UpdateUser(string userID, string userFName, string userLName, string birthDate, string userImg, string userName, string userPassword, string phoneNumber)
    {
        return db.UpdateUser(userID, userFName, userLName, birthDate, userImg, userName, userPassword, phoneNumber);
    }

    public string GetUserType(string UserID, string password)
    {
        return db.GetUserType(UserID, password);
    }

    public string GetPupilGroup(string UserID)
    {
        return db.GetPupilGroup(UserID);
    }

    public bool GetTeacherMain(string UserID)
    {
        return db.GetTeacherMain(UserID);
    }

    public string GetTeacherMainClass(string UserID)
    {
        return db.GetTeacherMainClass(UserID);
    }

    public List<string> GetUserInfo(string UserID)
    {
        return db.GetUserInfo(UserID);
    }

    public List<string> GetUserSecurityDetailsByuserIDandBday(string userID, string Bday)
    {
        List<string> l = new List<string>();
        l = db.GetUserSecurityDetailsByuserIDandBday(userID, Bday);

        return l;
    }

    public int ChangePassword(string userID, string Password)
    {
        return db.ChangePassword(userID, Password);
    }

    public string IsAlreadyLogin(string UserID, string password)
    {
        return db.IsAlreadyLogin(UserID, password);
    }

    public int SaveQuestion(string id, int q1, string a1, int q2, string a2)
    {
        return db.SaveQuestion(id, q1, a1, q2, a2);
    }

    public int ChangeFirstLogin(string id)
    {
        return db.ChangeFirstLogin(id);
    }

}

