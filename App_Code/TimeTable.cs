using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeTable
/// </summary>
public class TimeTable
{
    DBconnection db = new DBconnection();

    public TimeTable()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertTimeTable(List<Dictionary<string, string>> matrix)
    {
        return db.InsertTimeTable(matrix);
    }

    public Dictionary<string, string> GetTimeTableAcordingToClassCode(int classCode)
    {
        return db.GetTimeTableAcordingToClassCode(classCode);
    }
}