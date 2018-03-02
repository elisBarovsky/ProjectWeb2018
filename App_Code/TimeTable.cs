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

    public void InsertTimeTable(List<Dictionary<string, string>> matrix)
    {
        db.InsertTimeTable(matrix);
    }
}