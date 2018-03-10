using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for BetseferWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BetseferWS : System.Web.Services.WebService
{

    public BetseferWS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataTable TelephoneList(string UserTypeFilter,string PupilID)
    {
        Users PupilClass = new Users();
        string PupilClassCode = PupilClass.GetPupilOtClass(PupilID);

        TelphoneList TL = new TelphoneList();
        return TL.FilterTelphoneList(UserTypeFilter, PupilClassCode);
    }

    [WebMethod]
    public DataTable GivenAllNotes(string PupilID)
    {
        Notes AllNotesByID = new Notes();
        return AllNotesByID.GivenAllNotes(PupilID);
    }

    [WebMethod]
    public DataTable GivenNotesBySubject(string PupilID, string ChooseSubjectCode)
    {
        //Dictionary<string, string> LessonsList = new Dictionary<string, string>();
        //LessonsList = (Dictionary<string, string>)(Session["LessonsList"]);
        //string LessonCode = KeyByValue(LessonsList, ChooseSubjectCode);

        Notes FilterNoteBySubject = new Notes();
        return FilterNoteBySubject.GivenNotesBySubject(PupilID, ChooseSubjectCode);
    }

    [WebMethod]
    public List<Dictionary<string, string>> GivenTimeTableByClassCode(int classCode)
    {
        //איך את שולחת בדיוק את הקלאס קוד? כי אם אין דרך אלא רק עי שליחת תעודת זהות אז תורידי את הירקת למטה
        //Users PupilClass = new Users();
        //string PupilClassCode = PupilClass.GetPupilOtClass(PupilID);
        TimeTable TimeTableByClassCode = new TimeTable();
        return TimeTableByClassCode.GetTimeTableAcordingToClassCode(classCode);
    }

    [WebMethod]
    public DataTable FillAllHomeWork(string PupilID)
    {
        Users PupilClass = new Users();
        string PupilClassCode =  PupilClass.GetPupilOtClass(PupilID);
        HomeWork HomeWork = new HomeWork();
        return HomeWork.FillAllHomeWork(PupilClassCode);
    }

    public static string KeyByValue(Dictionary<string, string> dict, string val)
    {
        string key = null;
        foreach (KeyValuePair<string, string> pair in dict)
        {
            if (pair.Value == val)
            {
                key = pair.Key;
                break;
            }
        }
        return key;
    }
}

