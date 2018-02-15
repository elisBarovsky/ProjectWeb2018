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

    public DBconnection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlConnection connect(String conString)
    {
        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand(string userID, string Password)
    {
        String command;
        
       // StringBuilder sb = new StringBuilder();
       // use a string builder to create the dynamic string
       // sb.AppendFormat("Values('{0}', '{1}' ,{2}, {3},{4},{5})", pro, pro, "'" + pro + "'", pro, pro, pro);
        String prefix = "update[dbo].[Users] set[LoginPassword] = ('" + Password + "') WHERE UserID = '" + userID + "'";
       // command = prefix + sb.ToString();

        return prefix;
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
    public void readCarsDataBase()
    {

        SqlConnection con = connect("Betsefer"); // open the connection to the database/

        String selectStr = "SELECT * FROM Cars"; // create the select that will be used by the adapter to select data from the DB

        SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

        DataSet ds = new DataSet("carsDS"); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB

        da.Fill(ds);       // Fill the datatable (in the dataset), using the Select command

        dt = ds.Tables[0]; // point to the cars table , which is the only table in this case
    }


    public string GetUserType(string name, string password)
    {
        SqlConnection con = connect("Betsefer");
        String selectSTR = "SELECT CodeUserType  FROM Users where LoginName  = '" + name + "' and LoginPassword  = '" + password + "'";
        SqlCommand cmd = new SqlCommand(selectSTR, con);
        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        string type = "";

        while (dr.Read())
        {
            type = dr["CodeUserType"].ToString();
        }
        return type;
    }

    public List<string> GetUserSecurityDetailsByuserIDandBday(string userID, string Bday) {
        SqlConnection con = connect("Betsefer");
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

    //public int ChangePassword(string userID, string Password)
    //{
    //    SqlConnection con = connect("Betsefer");
    //    String selectSTR = "INSERT INTO [dbo].[Users] [LoginPassword] VALUES (" + Password + ") WHERE UserID = '" + userID + "'";
    //    SqlCommand cmd = new SqlCommand(selectSTR, con);
    //    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
    //    string Q, answer;
    //    List<string> l = new List<string>();
    //    while (dr.Read())
    //    {
    //        Q = dr["SecurityQInfo"].ToString();
    //        l.Add(Q);
    //        answer = dr["SecurityQAnswer"].ToString();
    //        l.Add(answer);

    //    }
    //    return l;

    //}








    //public List<string> getCategories()
    //{
    //    List<string> categories = new List<string>();
    //    SqlConnection con = connect("ShoppingDB");
    //    String selectSTR = "SELECT distinct [CatName] FROM [Category] ";
    //    SqlCommand cmd = new SqlCommand(selectSTR, con);
    //    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

    //    while (dr.Read())
    //    {
    //        category c = new category();
    //        c.CategoryName = dr["CatName"].ToString();
    //        categories.Add(c.CategoryName);
    //    }
    //    return categories;
    //}

    //--------------------------------------------------------------------------------------------------
    // This method inserts a product to the productN table 
    //--------------------------------------------------------------------------------------------------
    public int ChangePassword(string userID, string Password)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("Betsefer"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(userID, Password);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

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