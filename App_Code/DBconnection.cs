﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for DBconnection
/// </summary>
public class DBconnection
{
    public SqlDataAdapter da;
    public DataTable dt;

    SqlConnection con = new SqlConnection();

    public DBconnection()
    {
        con = connect("Betsefer");
    }

    public SqlConnection connect(String conString) 
    {
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); 
        cmd.Connection = con;            
        cmd.CommandText = CommandSTR;      
        cmd.CommandTimeout = 10;           
        cmd.CommandType = System.Data.CommandType.Text; 
        return cmd;
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

    public bool IsExists(string newSubject)
    {
        String selectSTR = "SELECT count(LessonName) FROM Lessons where LessonName  = '" + newSubject + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        int countRow = 0;
        while (dr.Read())
        {
            countRow = int.Parse(dr[0].ToString());
        }

        if (countRow > 0)
        {
            return true;
        }

        return false;
    }

    public int AddNewSubject(string newSubject)
    {
        String cStr = "INSERT INTO [dbo].[Lessons]  (LessonName) VALUES ('" + newSubject + "')";
        SqlCommand cmd = CreateCommand(cStr, con);
        return ExecuteNonQuery(cmd);
    }

    public string GetPupilGroup(string UserID)
    {
        String selectSTR = "SELECT CodePgroup  FROM Pupil where UserID  = '" + UserID + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string CodePgroup = "";

        while (dr.Read())
        {
            CodePgroup = dr["CodePgroup"].ToString();
        }
        return CodePgroup;
    }

    public string GetPupilOtClass(string UserID)
    {
        String selectSTR = "SELECT  dbo.Class.ClassCode FROM dbo.Class INNER JOIN  dbo.Pupil ON dbo.Class.ClassCode = dbo.Pupil.CodeClass where  dbo.Pupil.UserID='" + UserID + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string ClassCode = "";

        while (dr.Read())
        {
            ClassCode = dr["ClassCode"].ToString();
        }
        return ClassCode;
    }

    public bool GetTeacherMain(string UserID)
    {
        String selectSTR = "SELECT IsMainTeacher  FROM Teachers where TeacherID  = '" + UserID + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        bool Checked = false;

        while (dr.Read())
        {
            Checked = bool.Parse(dr["IsMainTeacher"].ToString());
        }
        return Checked;
    }

    public string GetTeacherMainClass(string UserID)
    {
        String selectSTR = "SELECT ClassCode  FROM Class where MainTeacherID  = '" + UserID + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string ClassCode = "";

        while (dr.Read())
        {
            ClassCode = dr["ClassCode"].ToString();
        }
        return ClassCode;
    }

    public List<string> GetUserInfo(string UserID)
    {
        string UserFName, UserLName, BirthDate, UserImg, UserPassword, PhoneNumber;
        String selectSTR = "select * from [dbo].[Users] where UserID  = '" + UserID + "'" ;
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
            UserPassword = dr["LoginPassword"].ToString();
            UserInfo.Add(UserPassword);
            PhoneNumber = dr["PhoneNumber"].ToString();
            UserInfo.Add(PhoneNumber);
            UserImg = dr["UserImg"].ToString();
            UserInfo.Add(UserImg);
        }
        return UserInfo;
    }

    public List<string> GetUserSecurityDetailsByuserIDandBday(string userID, string Bday) {
        List<string> l = new List<string>();

        l = GetSecurityInfo(1, userID, Bday).Concat(GetSecurityInfo(2, userID, Bday)).ToList();
        
        return l;
    }

    public List<string> GetSecurityInfo(int numQ, string id, string bDay)
    {
        string str = "";
        SqlCommand cmd;
        List<string> l = new List<string>();

        switch (numQ)
        {
            case 1:
                str = "SELECT dbo.SecurityQ.SecurityQInfo, dbo.Users.SecurityQ1Answer FROM dbo.SecurityQ " +
            "INNER JOIN dbo.Users ON dbo.SecurityQ.CodeSecurityQ = dbo.Users.SecurityQ1Code " +
            "where dbo.Users.UserID = '" + id + "' and dbo.Users.BirthDate ='" + bDay + "'";

                cmd = new SqlCommand(str, con);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    string Q1 = dr["SecurityQInfo"].ToString();
                    l.Add(Q1);
                    string answer1 = dr["SecurityQ1Answer"].ToString();
                    l.Add(answer1);
                }
                break;
            case 2:
                str = "SELECT dbo.SecurityQ.SecurityQInfo, dbo.Users.SecurityQ2Answer FROM dbo.SecurityQ " +
            "INNER JOIN dbo.Users ON dbo.SecurityQ.CodeSecurityQ = dbo.Users.SecurityQ2Code " +
            "where dbo.Users.UserID = '" + id + "' and dbo.Users.BirthDate ='" + bDay + "'";

                cmd = new SqlCommand(str, con);
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    string Q2 = dr["SecurityQInfo"].ToString();
                    l.Add(Q2);
                    string answer2 = dr["SecurityQ2Answer"].ToString();
                    l.Add(answer2);
                }
                break;
        }

        return l;
    }

    public int ChangePassword(string userID, string Password)
    {
        SqlCommand cmd;
        String cStr = "update[dbo].[Users] set[LoginPassword] = ('" + Password + "') WHERE UserID = '" + userID + "'";
        cmd = CreateCommand(cStr, con);            
        return ExecuteNonQuery(cmd);
    }

    public List<string> GetClassesOt()
    {
        String selectSTR = "select distinct [OtClass] from [dbo].[Class]";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string Ot;
        List<string> l = new List<string>();
        while (dr.Read())
        {
            Ot = dr["OtClass"].ToString();
            l.Add(Ot);
        }
        return l;
    }

    public List<string> ClassesExites(string ClassOt, string ClassNum)
    {
        String selectSTR = "select [TotalName] from [dbo].[Class] where [TotalName] = '" + ClassOt + ClassNum + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string Ot;
        List<string> l = new List<string>();
        while (dr.Read())
        {
            Ot = dr["TotalName"].ToString();
            l.Add(Ot);
        }
        return l;
    }

    public string GetClassNameByCodeClass(int codeClass)
    {
        String selectSTR = "select [TotalName] from [dbo].[Class] where [ClassCode] = " + codeClass;
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string className = "";
        while (dr.Read())
        {
            className = dr[0].ToString();
        }
        return className;
    }

    public int InsertClass(string ClassOt, string ClassNum)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[Class]  ([OtClass], [NumClass], [MainTeacherID], [TotalName]) VALUES ('" + ClassOt + "', '"+ ClassNum + "',null,'" + ClassOt+ ClassNum + "')";
        cmd = CreateCommand(cStr, con);      
        return ExecuteNonQuery(cmd);
    }

    public string IsAlreadyLogin(string UserID, string password)
    {
        String selectSTR = "select alreadyLogin from Users where UserID = '" + UserID + "' and LoginPassword = '" + password + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string isAlreadyLogin = "";
        while (dr.Read())
        {
            isAlreadyLogin = dr["alreadyLogin"].ToString();
        }
        return isAlreadyLogin;
    }

    public List<Questions> GetQuestions()
    {
        List<Questions> questions = new List<Questions>();

        String selectSTR = "select * from SecurityQ";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dr.Read())
        {
            Questions q = new Questions();
            q.SecurityCode = int.Parse(dr["CodeSecurityQ"].ToString());
            q.SecurityInfo = dr["SecurityQInfo"].ToString();
            questions.Add(q);
        }
        return questions;
    }

    public int SaveQuestion(string id, int q1, string a1, int q2, string a2)
    {
        SqlCommand cmd;
        String cStr = "update Users set SecurityQ1Code = " + q1 + ", SecurityQ1Answer = '" + a1 + "', SecurityQ2Code="+ q2 + ",SecurityQ2Answer='"+ a2+ "'  where UserID = '" + id + "'";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd); // execute the command   
    }

    public int AddUser(Users NewUser)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[Users] ([UserID],[UserFName],[UserLName],[BirthDate],[UserImg],[LoginName],[LoginPassword],[PhoneNumber],[CodeUserType],[SecurityQ1Code],[SecurityQ1Answer],[alreadyLogin],[SecurityQ2Code],[SecurityQ2Answer])" +
                     " VALUES('"+ NewUser.UserID1+"','"+ NewUser.UserFName1+"','"+ NewUser.UserLName1+"','"+ NewUser.BirthDate1+"','"+ NewUser.UserImg1+"','"+ NewUser.UserName1+"','"+ NewUser.UserPassword1+"','"+ NewUser.PhoneNumber1+"','"+ NewUser.CodeUserType1+ "' , null, null, 0, null, null)";
        cmd = CreateCommand(cStr, con);           
        return ExecuteNonQuery(cmd);   
    }

    public int InsertTimeTable(List<Dictionary<string, string>> matrix, string classCode)
    {
        SqlCommand cmd; string cStr;
        int num = 0;
        //check empty cells.

        cStr = "INSERT INTO [dbo].[Timetable] (ClassCode) values (" + classCode + ")";
        cmd = CreateCommand(cStr, con);
        ExecuteNonQuery(cmd);

        for (int i = 0; i < matrix.Count; i++)
        {
            SqlConnection conn = connect("Betsefer");

                if (matrix[i]["classCode"] != "empty")
                {
                    int TimeTableCode = GetLastTimeTableCode();
                    int CodeWeekDay = int.Parse(matrix[i]["CodeWeekDay"]);
                    int ClassTimeCode = int.Parse(matrix[i]["ClassTimeCode"]);
                    int CodeLesson = int.Parse(matrix[i]["CodeLesson"]);
                    string TeacherId = matrix[i]["TeacherID"];

                   
                    cStr = "INSERT INTO [dbo].[TimetableLesson] (TimeTableCode, CodeWeekDay, ClassTimeCode, CodeLesson, TeacherId) values (" + TimeTableCode + ", " + CodeWeekDay + ", " + ClassTimeCode + ", " + CodeLesson + ", '" + TeacherId + "')";
                    cmd = CreateCommand(cStr, conn);
                    num = ExecuteNonQuery(cmd);
                 }
        }
        return num;
    }

    public int GetLastTimeTableCode()
    {
        int TTC = 0;
        SqlConnection conn = connect("Betsefer");
        String cStr = "select max(TimeTableCode) from dbo.TimeTable";
        SqlCommand cmd = new SqlCommand(cStr, conn);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dr.Read())
        {
            TTC = int.Parse(dr[0].ToString());
        }
        return TTC;
    }

    public int UpdateUser(string userID, string userFName, string userLName, string birthDate, string userImg, string userName, string userPassword, string phoneNumber)
    {
        SqlCommand cmd;
        String cStr;
        if (userImg == "")
        {
            cStr = "Update Users set [UserID]='" + userID + "',[UserFName]='" + userFName + "',[UserLName]='" + userLName + "',[BirthDate]='" + birthDate + "',[LoginName]='"+ userName + "',[LoginPassword]='" + userPassword + "',[PhoneNumber]='" + phoneNumber + "' where [UserID]='" + userID + "'";
        }
        else
        {
             cStr = "Update Users set [UserID]='" + userID + "',[UserFName]='" + userFName + "',[UserLName]='" + userLName + "',[BirthDate]='" + birthDate + "',[UserImg]='" + userImg + "',[LoginName]='"+ userName + "',[LoginPassword]='"+ userPassword + "',[PhoneNumber]='" + phoneNumber + "' where [UserID]='" + userID + "'";
        }
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd); // execute the command   
    }

    public int AddPupil(string UserID, int classNumber)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[Pupil]([UserID],[CodeClass])  VALUES ('"+ UserID + "' ,'"+ classNumber + ")";
        cmd = CreateCommand(cStr, con);          
        return ExecuteNonQuery(cmd);  
    }

    public string GetNumChild(string UserID)
    {
        String cStr = "select count([ParentID]) as num from [dbo].[PupilsParent] where [ParentID]='" + UserID + "'";
        SqlCommand cmd = new SqlCommand(cStr, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string NumChilds="";
        
        while (dr.Read())
        {
            NumChilds = dr["num"].ToString();
        }
        return NumChilds;
    }
    public int UpdatePupil(string userID, string ClassOt)
    {
        SqlCommand cmd;                                                                 
        String cStr = "UPDATE[dbo].[Pupil] [CodeClass]='" + ClassOt + "' where [UserID]='" + userID + "'";
        cmd = CreateCommand(cStr, con);         
        return ExecuteNonQuery(cmd);   
    }

    public int AddTeacher(string UserID, string IsMain)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[Teachers] ([TeacherID] ,[IsMainTeacher]) VALUES ('"+ UserID + "' ,'"+ IsMain + "')";
        cmd = CreateCommand(cStr, con);
       return ExecuteNonQuery(cmd);
    }

    public int UpdateTeacher(string UserID, string IsMain, string ClassOt)
    {
        SqlCommand cmd;
        String cStr = "UPDATE [dbo].[Teachers]  SET [IsMainTeacher] = '" + IsMain + "' where [TeacherID]='" + UserID + "'";
        cmd = CreateCommand(cStr, con);            
        return ExecuteNonQuery(cmd);  
    }

    public int UpdateClassTeacher(string UserID, string ClassOt)
    {
        SqlCommand cmd;
        String cStr = "UPDATE [dbo].[Class] SET [MainTeacherID] = '" + UserID + "' where [TotalName]='" + ClassOt + "'";
        cmd = CreateCommand(cStr, con);          
        return ExecuteNonQuery(cmd);  
    }

    public int AddParent( string ParentID, string PupilID, string ChildCodeClass)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[PupilsParent] ([ParentID] ,[PupilID],[codeClass]) VALUES ('" + ParentID + "' ,'" + PupilID + ",'"+ ChildCodeClass + "')";
        cmd = CreateCommand(cStr, con);
        return ExecuteNonQuery(cmd); 
    }

    public int UpdateParent(string PupilID, string ParentID, string ChildCodeClass)
    {
        SqlCommand cmd;
        String cStr = "UPDATE [dbo].[PupilsParent] SET [PupilID] = '" + PupilID + "' ,[ParentID] = '" + ParentID + "',codeClass='"+ ChildCodeClass+ "' WHERE [ParentID]= '" + ParentID + "'";
        cmd = CreateCommand(cStr, con);             
        return ExecuteNonQuery(cmd);    
    }

    public int ChangeFirstLogin(string id)
    {
        SqlCommand cmd;
        String cStr = "update Users set alreadyLogin = 1  where UserID = '" + id + "'";
        cmd = CreateCommand(cStr, con);                   
        return ExecuteNonQuery(cmd); 
    }

    public int AddMainTeacherToClass(string id,string OtClass)
    {
        SqlCommand cmd;     
        String cStr= "update Class set MainTeacherID = '" + id + "'  where TotalName = '" + OtClass + "'";
        cmd = CreateCommand(cStr, con);              
        return ExecuteNonQuery(cmd);
    }

    public int DeleteMainTeacherToClass(string TotalClassName)
    {
        SqlCommand cmd;
        String DeletePrevieusClassTeacher = "update Class set MainTeacherID = null where TotalName = '" + TotalClassName + "'";
        cmd = CreateCommand(DeletePrevieusClassTeacher, con);                 
        return ExecuteNonQuery(cmd); 
    }

    public List<string> IsAlreadyMainTeacher(string id)
    {
        String cStr = "select [TotalName] from Class where MainTeacherID= '" + id + "'";
        SqlCommand cmd = new SqlCommand(cStr, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string ClassOt;
        List<string> l = new List<string>();

        while (dr.Read())
        {
            ClassOt = dr["TotalName"].ToString();
            l.Add(ClassOt);
        }
        return l;
    } 

    public Dictionary<string,string> getPupils(string classCode)
    {
        String selectSTR = "SELECT   dbo.Users.UserID,(dbo.Users.UserLName + ' ' + dbo.Users.UserFName)AS PupilName" +
           "  FROM dbo.Pupil INNER JOIN   dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID   where dbo.Pupil.CodeClass='" + classCode + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string UserID, UserName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        l.Add("1", "בחר תלמיד");
        while (dr.Read())
        {
            UserID = dr["UserID"].ToString();
            UserName = dr["PupilName"].ToString();
            l.Add(UserID, UserName);
        }
        return l;
    }

    public List<Dictionary<string, string>> getPupilsByClassCode(string classCode)
    {
        String selectSTR = "SELECT   dbo.Users.UserID,(dbo.Users.UserLName + ' ' + dbo.Users.UserFName)AS PupilName" +
           "  FROM dbo.Pupil INNER JOIN   dbo.Users ON dbo.Pupil.UserID = dbo.Users.UserID   where dbo.Pupil.CodeClass='" + classCode + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        List<Dictionary<string, string>> l = new List<Dictionary<string, string>>();

        while (dr.Read())
        {
            Dictionary<string, string> p = new Dictionary<string, string>();
            p["UserId"] = dr["UserID"].ToString();
            p["UserName"] = dr["PupilName"].ToString();

            l.Add(p);
        }
        return l;
    }

    public Dictionary<string, string> GetTeachers()
    {
        String selectSTR = "SELECT UserID, UserFName + ' ' + UserLName AS FullName FROM Users WHERE (CodeUserType = 2)";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string UserID, TeacherFullName;
        Dictionary<string, string> l = new Dictionary<string, string>();

        l.Add("0", "-");
        while (dr.Read())
        {
            UserID = dr["UserID"].ToString();
            TeacherFullName = dr["FullName"].ToString();
            l.Add(UserID, TeacherFullName);
        }
        return l;
    }

    public Dictionary<string, string> FillUsers(string CodeUserType)
    {
        String selectSTR = "SELECT(UserLName+' '+ UserFName) as UserName, UserID" +
           " FROM dbo.Users where CodeUserType='" + CodeUserType + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string UserID, UserName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        l.Add("1", "בחר משתמש");
        while (dr.Read())
        {
            UserID = dr["UserID"].ToString();
            UserName = dr["UserName"].ToString();
            l.Add(UserID, UserName);
        }
        return l;
    }

    public Dictionary<int, string> GetSubjects()
    {
        String selectSTR = "SELECT DISTINCT * FROM [Lessons] ORDER BY [LessonName]";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        int SubjectID;
        string SubjectName;
        Dictionary<int, string> l = new Dictionary<int, string>();

        l.Add(0, "-");
        while (dr.Read())
        {
            SubjectID = int.Parse(dr["CodeLesson"].ToString());
            SubjectName = dr["LessonName"].ToString();
            l.Add(SubjectID, SubjectName);
        }
        return l;
    }

    public Dictionary<string, string> FillClassOt()
    {
        String selectSTR = "SELECT ClassCode,TotalName FROM Class ";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string ClassCode, TotalName;
        Dictionary<string, string> l = new Dictionary<string, string>();
        l.Add("0", "בחר");
        while (dr.Read())
        {
            ClassCode = dr["ClassCode"].ToString();
            TotalName = dr["TotalName"].ToString();
            l.Add(ClassCode, TotalName);
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

    public List<Dictionary<string, string>> GetTimeTableAcordingToClassCode(int classCode) //webService
    {
        //keep just one time table for a class. no history.
        List<Dictionary<string, string>> TT = new List<Dictionary<string, string>>();

        SqlCommand cmd; string cStr;

        cStr = "select [dbo].[TimetableLesson].TimeTableCode, [dbo].[TimetableLesson].CodeWeekDay, [dbo].[TimetableLesson].ClassTimeCode, [dbo].[TimetableLesson].CodeLesson, [dbo].[TimetableLesson].TeacherId from [dbo].[TimetableLesson] inner join[dbo].[Timetable] on[dbo].[TimetableLesson].TimeTableCode = [dbo].[Timetable].TimeTableCode where[dbo].[Timetable].ClassCode = " + classCode;
        cmd = CreateCommand(cStr, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dr.Read())
        {
            Dictionary<string, string> lesson = new Dictionary<string, string>();
            lesson.Add("TimeTableCode", dr["TimeTableCode"].ToString());
            lesson.Add("CodeWeekDay", dr["CodeWeekDay"].ToString());
            lesson.Add("ClassTimeCode", dr["ClassTimeCode"].ToString());
            lesson.Add("CodeLesson", dr["CodeLesson"].ToString());
            lesson.Add("TeacherId", dr["TeacherId"].ToString());

            TT.Add(lesson);
        }
        return TT;
    }

    public List<Dictionary<string, string>> GetValuesTimeTableAcordingToClassCode(int classCode)
    {
        List<Dictionary<string, string>> TT = new List<Dictionary<string, string>>();

        SqlCommand cmd; string cStr;

        cStr = "select [dbo].[TimetableLesson].TimeTableCode, [dbo].[TimetableLesson].CodeWeekDay, [dbo].[TimetableLesson].ClassTimeCode, [dbo].[TimetableLesson].CodeLesson, [dbo].[TimetableLesson].TeacherId from [dbo].[TimetableLesson] inner join[dbo].[Timetable] on[dbo].[TimetableLesson].TimeTableCode = [dbo].[Timetable].TimeTableCode where[dbo].[Timetable].ClassCode = " + classCode;
        cmd = CreateCommand(cStr, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dr.Read())
        {
            Dictionary<string, string> lesson = new Dictionary<string, string>();
            lesson.Add("TimeTableCode", dr["TimeTableCode"].ToString());
            lesson.Add("CodeWeekDay", dr["CodeWeekDay"].ToString());
            lesson.Add("ClassTimeCode", dr["ClassTimeCode"].ToString());
            lesson.Add("CodeLesson", dr["CodeLesson"].ToString());
            lesson.Add("TeacherId", dr["TeacherId"].ToString());

            TT.Add(lesson);
        }
        return TT;
    }

    public bool IsClassHasTimeTable(string classCode)
    {
        int num = 0;

        String selectSTR = "SELECT count(TimeTableCode) FROM Timetable where ClassCode = " + classCode;
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        while (dr.Read())
        {
            num = int.Parse(dr[0].ToString());
        }

        if (num > 0)
        {
            return true;
        }
        return false;
    }

    public int DeleteTimeTable(string classCode)
    {
        String selectSTR = "DELETE T2 FROM dbo.TimetableLesson as T2 INNER JOIN dbo.Timetable as T1 ON T2.TimeTableCode = T1.TimeTableCode where T1.ClassCode = " + classCode;
        SqlCommand cmd;
        cmd = CreateCommand(selectSTR, con);        
        return ExecuteNonQuery(cmd);
    }

    public string GetLessonNameByLessonCode(string lessonCode)
    {
        String selectSTR = "SELECT LessonName FROM Lessons where CodeLesson = " + lessonCode;
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string lessonName = "";
        while (dr.Read())
        {
            lessonName = dr[0].ToString();
        }

        return lessonName;
    }

    public string GetTeacherNameByID(string TeacherId)
    {
        String selectSTR = "SELECT UserFName + ' ' + UserLName FROM Users where UserId = '" + TeacherId +"'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string teacherName = "";
        while (dr.Read())
        {
            teacherName = dr[0].ToString();
        }

        return teacherName;
    }
}