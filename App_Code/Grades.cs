using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Grades
/// </summary>
public class Grades
{
    DBconnectionTeacher dbT;
    DBconnection db;

    public Grades()
    {
        dbT = new DBconnectionTeacher();
        db = new DBconnection();
    }

    public Dictionary<string, string> FillClassOt()
    {
        return db.FillClassOt();
    }

    public Dictionary<string, string> FillLessons()
    {
        return dbT.FillLessons();
    }
}