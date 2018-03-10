<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="TGradesInsert.aspx.cs" Inherits="TGrades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
          .auto-style1 {
              width: 80%;
              position: center;
          }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <h2 style="text-align: center">ציונים</h2>
        <div class="btn-group" style=" position: relative;  left: 40%;">
            <button type="button" class="btn btn-primary active" onclick="location.href = 'TGradesInsert.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary " onclick="location.href = 'TGradesUpdate.aspx';">עדכון</button>
        </div>
        <br />
        <br />
          <table class="auto-style1">
            <tr>
                <td>
                    <asp:DropDownList ID="ChooseClassDLL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FillPupils"></asp:DropDownList>
                </td>
                <td>בחר כיתה
                </td>

                <td><asp:DropDownList ID="ChooseLessonsDLL" runat="server" ></asp:DropDownList>
                </td>
                <td>בחר מקצוע
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td></td>
                <td align="center" style="margin:auto">
                     <asp:calendar id="Calendar1" runat="server" autopostback="false" />
                </td>
                <td>תאריך בחינה</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:GridView ID="GridView1" runat="server" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                      OnRowUpdating="GridView1_RowUpdating" >
                    <Columns>
                        <asp:CommandField ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="true" />
                    </Columns>
                    </asp:GridView>
                   

                </td>
            </tr>
        </table>
        <br />
        <asp:button id="AddGrades" runat="server" cssclass="form-btn" text="הוסף ציונים" OnClick="AddGrades_Click"  />
        <asp:label id="MessegaeLBL" runat="server" text="" style="text-align: right"></asp:label>
         </div>
</asp:Content>

