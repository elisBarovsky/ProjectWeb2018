﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subject
/// </summary>
public class Subject
{
    public int subjectCode { get; set; }
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

    public bool IsExists(string newSubject)
    {
        return db.IsExists(newSubject);
    }

    public int AddNewSubject(string newSubject) {
        return db.AddNewSubject(newSubject);
    }
}