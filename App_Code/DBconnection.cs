using System;
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

    //--------------------------------------------------------------------
    // Read from the DB into a table
    //--------------------------------------------------------------------

    //public void readCarsDataBase()
    //{
    //    String selectStr = "SELECT * FROM Cars"; // create the select that will be used by the adapter to select data from the DB
    //    SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter
    //    DataSet ds = new DataSet("carsDS"); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
    //    da.Fill(ds);       // Fill the datatable (in the dataset), using the Select command
    //    dt = ds.Tables[0]; // point to the cars table , which is the only table in this case
    //}

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
        string UserFName, UserLName, BirthDate, UserImg, UserName, UserPassword, PhoneNumber;
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

    public List<string> GetUserSecurityDetailsByuserIDandBday(string userID, string Bday) {
        String selectSTR = "SELECT dbo.SecurityQ.SecurityQInfo, dbo.Users.SecurityQAnswer FROM dbo.SecurityQ INNER JOIN" +
            "  dbo.Users 	ON dbo.SecurityQ.CodeSecurityQ = dbo.Users.SecurityQCode INNER" +
            " JOIN dbo.UserType ON dbo.Users.CodeUserType = dbo.UserType.CodeUserType " +
            "where dbo.Users.UserID = '" + userID + "'  and dbo.Users.BirthDate ='" + Bday + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string Q, answer;
        List<string> l = new List<string>();
        while (dr.Read())
        {
            Q = dr["SecurityQInfo"].ToString();
            l.Add(Q);
            answer = dr["SecurityQAnswer"].ToString();
            l.Add(answer);
        }
        return l;
    }

    public int ChangePassword(string userID, string Password)
    {
        SqlCommand cmd;
        String cStr = "update[dbo].[Users] set[LoginPassword] = ('" + Password + "') WHERE UserID = '" + userID + "'";
        cmd = CreateCommand(cStr, con);             // create the command
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
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd); // execute the command   
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

    public int AddPupil(string UserID, string GroupType, int classNumber)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[Pupil]([UserID] ,[CodePgroup],[CodeClass])  VALUES ('"+ UserID + "' ,'"+ GroupType + "' ,"+ classNumber + ")";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd); // execute the command   
    }

    public int UpdatePupil(string userID, string CodePgroup, string ClassOt)
    {
        SqlCommand cmd;
        String cStr = "UPDATE[dbo].[Pupil] [CodePgroup]='" + CodePgroup + "',[CodeClass]='" + GetCodeClass(ClassOt) + "' where [UserID]='" + userID + "'";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd); // execute the command   
    }

    public string GetCodeClass(string ClassOt)
    {
        String selectSTR = "select ClassCode * from Class where TotalName= '"+ ClassOt + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string CodeClass="";
        while (dr.Read())
        {
            CodeClass = dr["ClassCode"].ToString();
        }
        return CodeClass;
    }

    public int AddTeacher(string UserID, string IsMain)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[Teachers] ([TeacherID] ,[IsMainTeacher]) VALUES ('"+ UserID + "' ,'"+ IsMain + "')";
        cmd = CreateCommand(cStr, con);
       return ExecuteNonQuery(cmd);// execute the command  
    }

    public int UpdateTeacher(string UserID, string IsMain, string ClassOt)
    {
        SqlCommand cmd;
        String cStr = "UPDATE [dbo].[Teachers]  SET [IsMainTeacher] = '" + IsMain + "' where [TeacherID]='" + UserID + "'";

        if (IsMain=="1") { UpdateClassTeacher( UserID,  ClassOt); }

        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd); // execute the command   
    }

    public int UpdateClassTeacher(string UserID, string ClassOt)
    {
        SqlCommand cmd;
        String cStr = "UPDATE [dbo].[Class] SET [MainTeacherID] = '" + UserID + "' where [TotalName]='" + ClassOt + "'";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd); // execute the command   
    }

    public int AddParent(string PupilID, string ParentID)
    {
        SqlCommand cmd;
        String cStr = "INSERT INTO [dbo].[PupilsParent] ([PupilID] ,[ParentID]) VALUES ('" + PupilID + "' ,'" + ParentID + "')";
        cmd = CreateCommand(cStr, con);
        return ExecuteNonQuery(cmd);// execute the command  
    }

    public int UpdateParent(string PupilID, string ParentID)
    {
        SqlCommand cmd;
        String cStr = "UPDATE [dbo].[PupilsParent] SET [PupilID] = '" + PupilID + "' ,[ParentID] = '" + ParentID + "' WHERE [ParentID]= '" + ParentID + "'";
        cmd = CreateCommand(cStr, con);             // create the command
        return ExecuteNonQuery(cmd); // execute the command   
    }

    public int ChangeFirstLogin(string id)
    {
        SqlCommand cmd;
        String cStr = "update Users set alreadyLogin = 1  where UserID = '" + id + "'";
        cmd = CreateCommand(cStr, con);             // create the command      
        return ExecuteNonQuery(cmd); // execute the command   
    }

    public int AddMainTeacherToClass(string id,string OtClass)
    {
        SqlCommand cmd;
        String cStr= "update Class set MainTeacherID = '" + id + "'  where TotalName = '" + OtClass + "'";
        cmd = CreateCommand(cStr, con);             // create the command      
        return ExecuteNonQuery(cmd); // execute the command   
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
}

