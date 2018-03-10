﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBconnectionTeacher
/// </summary>
public class DBconnectionTeacher
{
    public SqlDataAdapter da;
    public DataTable dt;
    public DataSet ds; 
    SqlConnection con = new SqlConnection();

    public DBconnectionTeacher()
    {
        con = connect("Betsefer");
    }

    public SqlConnection connect(String conString)  // read the connection string from the configuration file
    {
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object
        cmd.Connection = con;              // assign the connection to the command object
        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 
        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds
        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure
        return cmd;
    }

    public DataTable PupilList(string ClassOtID)
    {
       string selectSTR = " SELECT dbo.Pupil.UserID, (dbo.Users.UserFName +' '+ dbo.Users.UserLName) as PupilName, dbo.Grades.Grade" +
                         " FROM dbo.Pupil INNER JOIN dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID Full outer JOIN dbo.Grades ON dbo.Users.UserID = dbo.Grades.PupilID where dbo.Pupil.CodeClass = '" + ClassOtID + "'";
        SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con); // create the data adapter
        DataSet ds = new DataSet("PupilsDS");
        daa.Fill(ds);
        DataTable dtt = ds.Tables[0];
        return dtt = ds.Tables[0];
    }

    public DataTable FilterNotes(string FilterType,string ValueFilter)
    {
        string selectSTR = " SELECT  dbo.GivenNotes.Comment AS 'הערת מורה', dbo.GivenNotes.NoteDate AS 'תאריך', dbo.Lessons.LessonName AS 'שיעור', dbo.NoteType.NoteName AS 'הערת משמעת', (dbo.Users.UserFName +' '+ dbo.Users.UserLName) as 'שם תלמיד' ,dbo.Pupil.UserID as 'תעודת זהות תלמיד'" +
                          " FROM  dbo.Users inner JOIN dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID inner JOIN dbo.GivenNotes " +
                          "ON dbo.Users.UserID = dbo.GivenNotes.PupilID  inner JOIN dbo.NoteType ON dbo.GivenNotes.CodeNoteType = dbo.NoteType.CodeNoteType  INNER JOIN  dbo.Lessons ON dbo.GivenNotes.LessonsCode = dbo.Lessons.CodeLesson " +
                          " where "+ FilterType + "='" + ValueFilter + "'";
        SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con); // create the data adapter
        DataSet ds = new DataSet("NotesDS");
        daa.Fill(ds);
        DataTable dtt = ds.Tables[0];
        return dtt = ds.Tables[0];
    }

    public DataTable GivenAllNotes(string PupilID) //webService
    {
        string selectSTR = " SELECT  dbo.GivenNotes.Comment AS 'הערת מורה', dbo.GivenNotes.NoteDate AS 'תאריך', dbo.Lessons.LessonName AS 'שיעור', dbo.NoteType.NoteName AS 'הערת משמעת'" +
                          " FROM  dbo.Users inner JOIN dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID inner JOIN dbo.GivenNotes " +
                          "ON dbo.Users.UserID = dbo.GivenNotes.PupilID  inner JOIN dbo.NoteType ON dbo.GivenNotes.CodeNoteType = dbo.NoteType.CodeNoteType  INNER JOIN  dbo.Lessons ON dbo.GivenNotes.LessonsCode = dbo.Lessons.CodeLesson " +
                          " where dbo.Pupil.UserID='" + PupilID + "'";
        SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con); // create the data adapter
        DataSet ds = new DataSet("ALLNotesDS");
        daa.Fill(ds);
        DataTable dtt = ds.Tables[0];
        return dtt = ds.Tables[0];
    }

    public DataTable GivenNotesBySubject(string PupilID, string ChooseSubjectCode) //webService
    {
        string selectSTR = " SELECT  dbo.GivenNotes.Comment AS 'הערת מורה', dbo.GivenNotes.NoteDate AS 'תאריך', dbo.Lessons.LessonName AS 'שיעור', dbo.NoteType.NoteName AS 'הערת משמעת'" +
                          " FROM  dbo.Users inner JOIN dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID inner JOIN dbo.GivenNotes " +
                          "ON dbo.Users.UserID = dbo.GivenNotes.PupilID  inner JOIN dbo.NoteType ON dbo.GivenNotes.CodeNoteType = dbo.NoteType.CodeNoteType  INNER JOIN  dbo.Lessons ON dbo.GivenNotes.LessonsCode = dbo.Lessons.CodeLesson " +
                          " where dbo.Pupil.UserID='" + PupilID + "' and dbo.GivenNotes.LessonsCode ='" + ChooseSubjectCode + "'";
        SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con); // create the data adapter
        DataSet ds = new DataSet("NotesDS");
        daa.Fill(ds);
        DataTable dtt = ds.Tables[0];
        return dtt = ds.Tables[0];
    }

    public DataTable FilterTelphoneList(string UserTypeFilterType, string ClassFilter)
    {
        string selectSTR = "  SELECT  dbo.Users.PhoneNumber as 'מספר סלולרי', (dbo.Users.UserFName +' '+ dbo.Users.UserLName) as 'שם מלא' " +
                       " FROM dbo.Users full JOIN dbo.PupilsParent ON dbo.Users.UserID = dbo.PupilsParent.PupilID  AND dbo.Users.UserID = dbo.PupilsParent.ParentID Full JOIN" +
                       " dbo.Pupil ON dbo.Users.UserID = dbo.Pupil.UserID   where dbo.Users.CodeUserType='" + UserTypeFilterType + "'and dbo.Pupil.CodeClass='" + ClassFilter + "'";
        SqlDataAdapter daa = new SqlDataAdapter(selectSTR, con); // create the data adapter
        DataSet ds = new DataSet("TelephoneNumDS");
        daa.Fill(ds);
        DataTable dtt = ds.Tables[0];
        return dtt = ds.Tables[0];
    }

    public string GetUserType(string UserID, string password)
    {
        String selectSTR = "SELECT CodeUserType  FROM Users where UserID  = '" + UserID + "' and LoginPassword  = '" + password + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string type = "";

        while (dr.Read())
        {
            type = dr["CodeUserType"].ToString();
        }
        return type;
    }

    public List<string> GetUserInfo(string UserID)
    {
        string UserFName, UserLName, BirthDate, UserImg, UserName, UserPassword, PhoneNumber;
        String selectSTR = "select * from [dbo].[Users] where UserID  = '" + UserID + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        List<string> UserInfo = new List<string>();

        while (dr.Read())
        {
            UserFName = dr["UserFName"].ToString();
            UserInfo.Add(UserFName);
            UserLName = dr["UserLName"].ToString();
            UserInfo.Add(UserLName);
            BirthDate = dr["BirthDate"].ToString();
            UserInfo.Add(BirthDate);
            UserName = dr["LoginName"].ToString();
            UserInfo.Add(UserName);
            UserPassword = dr["LoginPassword"].ToString();
            UserInfo.Add(UserPassword);
            PhoneNumber = dr["PhoneNumber"].ToString();
            UserInfo.Add(PhoneNumber);
            UserImg = dr["UserImg"].ToString();
            UserInfo.Add(UserImg);
        }
        return UserInfo;
    }

    public int ChangePassword(string userID, string Password)
    {
        SqlCommand cmd;
        String cStr = "update[dbo].[Users] set[LoginPassword] = ('" + Password + "') WHERE UserID = '" + userID + "'";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd);
    }

    public int InsertGrade(string PupilID, string TeacherID, string CodeLesson, string ExamDate, int Grade)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[Grades]  ([PupilID] ,[TeacherID],[CodeLesson],[ExamDate],[Grade])   VALUES ('"+ PupilID + "','"+ TeacherID + "','"+ CodeLesson + "' ,'"+ ExamDate + "' ,"+ Grade + ")";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd);
    }

    public Dictionary<string, string> FillNotes()
    {
        String selectSTR = "SELECT CodeNoteType,NoteName FROM NoteType ";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string CodeNoteType, NoteName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        l.Add("0", "בחר");
        while (dr.Read())
        {
            CodeNoteType = dr["CodeNoteType"].ToString();
            NoteName = dr["NoteName"].ToString();
            l.Add(CodeNoteType, NoteName);
        }
        return l;
    }

    public int InsertNotes(string PupilID, string CodeNoteType, string NoteDate, string TeacherID,string LessonsCode, string Comment)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[GivenNotes]  ([PupilID] ,[CodeNoteType],[NoteDate],[TeacherID],[LessonsCode],[Comment])   VALUES ('" + PupilID + "','" + CodeNoteType + "','" + NoteDate + "' ,'" + TeacherID + "' ,'" + LessonsCode + "','"+ Comment + "')";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd);
    }

    public int InserHomeWork(string LessonsCode, string HWInfo, string TeacherID, string CodeClass, string HWDate, bool IsLehagasha)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[HomeWork] ([LessonsCode] ,[HWInfo],[TeacherID],[CodeClass],[HWDate],[IsLehagasha]) " +
                   " VALUES ('" + LessonsCode + "','" + HWInfo + "','" + TeacherID + "' ,'" + CodeClass + "' ,'" + HWDate + "','" + IsLehagasha + "')";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd);
    }

    public Dictionary<string, string> FillLessons()
    {
        String selectSTR = "SELECT CodeLesson, LessonName from Lessons";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string CodeLesson, LessonName;
        Dictionary<string, string> l = new Dictionary<string, string>();

        l.Add("0", "בחר מקצוע");
        while (dr.Read())
        {
            CodeLesson = dr["CodeLesson"].ToString();
            LessonName = dr["LessonName"].ToString();
            l.Add(CodeLesson, LessonName);
        }
        return l;
    }

    //--------------------------------------------------------------------------------------------------
    // This method returns number of rows affected
    //--------------------------------------------------------------------------------------------------
    public int ExecuteNonQuery(SqlCommand cmd)
    {
        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
}