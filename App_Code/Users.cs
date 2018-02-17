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
    public Users()
    {
        db = new DBconnection();
    }

    public string GetUserType(string UserID, string password)
    {
        return db.GetUserType(UserID, password);
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

    public int SaveQuestion(string id, int q, string a)
    {
        return db.SaveQuestion(id, q, a);
    }

    public int ChangeFirstLogin(string id)
    {
        return db.ChangeFirstLogin(id);
    }

}

