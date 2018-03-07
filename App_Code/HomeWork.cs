using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HomeWork
/// </summary>
public class HomeWork
{
    DBconnection db;
    DBconnectionTeacher dbT;

    public HomeWork()
    {
        dbT = new DBconnectionTeacher();
        db = new DBconnection();
    }

    public int InserHomeWork(string LessonsCode, string HWInfo, string TeacherID, string CodeClass, string HWDate, bool IsLehagasha)
    {
        return dbT.InserHomeWork(LessonsCode, HWInfo, TeacherID, CodeClass, HWDate, IsLehagasha);
    }
}