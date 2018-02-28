<%@ Page Title="" Language="C#" MasterPageFile="~/Pupil_MasterPage.master" AutoEventWireup="true" CodeFile="PupilStartPageaspx.aspx.cs" Inherits="PupilStartPageaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css" />
    <script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.js"></script>

        <script type="text/javascript">
            jQuery(function ($) {
                $('.menu-btn').click(function () {
                    $('.responsive-menu').toggleClass('expand')
                })
            })
    </script>
    <link href="css/mobileStyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="mobile-nav">
        <div class="menu-btn" id="menu-btn">
            <div></div>
            <span></span>
            <span></span>
            <span></span>
        </div>

        <div class="responsive-menu">
            <a href='login.aspx'>  <img id="LogOutIcon" src="Images/logoutIcon.png" /> </a>
           
            <div align="center" style="width:500px">
                <div style="position:relative" >
                    <img src="Images/NoImg.png" style="height:160px"/>
                </div>
               <div style="position:relative">
                   <label>ישראל ישראלי</label>
                   <label>01/01/1991</label>
                   <label>12346789</label>
               </div>
               
            </div>
            <table style="width:500px;margin:auto;padding-top:100px">
                <tr>
                    <td>
                    <a href='#'>  <img class="Icons" src="Images/msgIcon.png" /> </a>
                    <br/>הודעות
                    </td>
                    <td>
                    <a href='#'>  <img class="Icons" src="Images/LuzUIcon.png" /></a>
                    <br/>לוח שנה ואירועים </td>
                    <td> 
                    <a href='#'>  <img class="Icons" src="Images/ContactIcon.png" /></a>
                    <br/>דף קשר</td>
                </tr>
                <tr>
                    <td><a href='#'>  <img class="Icons" src="Images/UnlikeIcon.png" /></a>
                    <br/>הערות משמעת</td>
                    <td><a href='#'>  <img class="Icons" src="Images/timeTableIcon.png" /></a>
                    <br/>מערכת שעות </td>
                    <td><a href='#'>  <img class="Icons" src="Images/GradeIcon.png" /></a>
                    <br/>ציונים</td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td><a href='#'>  <img class="Icons" src="Images/HWIcon.png" /></a>
                    <br/>שיעורי בית</td>
                </tr>
            </table>

        </div>
    </div>


</asp:Content>

