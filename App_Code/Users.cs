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
        //
        // TODO: Add constructor logic here
        //
        db = new DBconnection();
    }

    public string GetUserType(string name, string password)
    {
        return db.GetUserType(name, password);
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

    public string IsAlreadyLogin(string userName, string password)
    {
        return db.IsAlreadyLogin(userName, password);
    }

    public int SaveQuestion(string id, int q, string a)
    {
        return db.SaveQuestion(id, q, a);
    }


}

