using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subject
/// </summary>
public class Subject
{
    public string name { get; set; }
    DBconnection db = new DBconnection();

    public Subject()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Dictionary<int, string> getSubjects() {

        return db.GetSubjects();
    }
}