using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Classes
/// </summary>
public class Classes
{
    DBconnection db;

    public Classes()
    {
        db = new DBconnection();
    }

    public List<string> GetClassesOt()
    {
        return db.GetClassesOt();
    }

    public int InsertClass(string ClassOt, string ClassNum)
    {
        return db.InsertClass(ClassOt, ClassNum);
    }

    public List<string> ClassesExites(string ClassOt, string ClassNum)
    {
        return db.ClassesExites(ClassOt, ClassNum);
    }
}