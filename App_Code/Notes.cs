using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Notes
/// </summary>
public class Notes
{
    DBconnection db;
    DBconnectionTeacher dbT;

    public Notes()
    {
        dbT = new DBconnectionTeacher();
        db = new DBconnection();
    }

    public Dictionary<string, string> FillNotes()
    {
        return dbT.FillNotes();
    }

    public int InsertNotes(string PupilID, string CodeNoteType, string NoteDate, string TeacherID, string Comment)
    {
        return dbT.InsertNotes(PupilID, CodeNoteType, NoteDate, TeacherID, Comment);
    }

    public DataTable FilterNotes(string FilterType,string ValueFilter)
    {
        return dbT.FilterNotes(FilterType, ValueFilter);
    }

}