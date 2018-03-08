using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Lessons
/// </summary>
public class Lessons
{
    DBconnection db;

    public Lessons()
    {
        db = new DBconnection();
    }

    public List<string> GetClassesOt()
    {
        return db.GetClassesOt();
    }

    public int InsertLesson(string ClassOt, string ClassNum)
    {
        return db.InsertLesson(ClassOt, ClassNum);
    }

    public List<string> LessonExites(string ClassOt, string ClassNum)
    {
        return db.LessonExites(ClassOt, ClassNum);
    }
}