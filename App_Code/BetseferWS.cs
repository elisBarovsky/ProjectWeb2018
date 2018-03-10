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
    public DataTable TelephoneList(string UserTypeFilter,string ClassFilter)
    {
        TelphoneList TL = new TelphoneList();
        return TL.FilterTelphoneList(UserTypeFilter, ClassFilter);
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
        Notes FilterNoteBySubject = new Notes();
        return FilterNoteBySubject.GivenNotesBySubject(PupilID, ChooseSubjectCode);
    }

    [WebMethod]
    public List<Dictionary<string, string>> GivenTimeTableByClassCode(int classCode)
    {
        TimeTable TimeTableByClassCode = new TimeTable();
        return TimeTableByClassCode.GetTimeTableAcordingToClassCode(classCode);
    }



}

