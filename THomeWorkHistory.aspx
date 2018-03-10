<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher_MasterPage.master" AutoEventWireup="true" CodeFile="THomeWorkHistory.aspx.cs" Inherits="THomeWorkHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style type="text/css">
        .auto-style1 {
           width: 80%;
            position: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <h2 style="text-align: center">שיעורי בית</h2>
        <div class="btn-group" style="position: relative; left: 40%;">
            <button type="button" class="btn btn-primary " onclick="location.href = 'THomeWorkInsert.aspx';">הוספה  </button>
            <button type="button" class="btn btn-primary active" onclick="location.href = 'THomeWorkHistory.aspx';">צפייה</button>
        </div>
        <br />
        <br />
        <table class="auto-style1" >
            <tr>
                <td align="right">
                    <asp:dropdownlist id="ChooseLessonsDLL" runat="server"></asp:dropdownlist>
                </td>
                <td align="right">בחר מקצוע</td>
                <td align="right">
                    <asp:dropdownlist id="ChooseClassDLL" runat="server"></asp:dropdownlist>
                </td>
                <td align="right">
                    <asp:label id="ClassLBL" runat="server" text=" בחר כיתה"></asp:label>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BorderStyle="Dashed" HeaderStyle-HorizontalAlign="Right">
                        <PagerStyle HorizontalAlign="Right" />
                        <RowStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
                <td></td>
            </tr>

            <tr>
                <td >
                   
                </td>
                <td></td>
                <td>
                    
                </td>
                <td> </td>
            </tr>
        </table>
        <br />
        <asp:button runat="server" text="סנן"  />

    </div>

</asp:Content>

