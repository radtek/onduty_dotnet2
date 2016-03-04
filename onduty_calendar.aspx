<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="onduty_calendar.aspx.cs" Inherits="_onduty_calendar" Title="onduty_calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="color: blue; font-family: 'Century Gothic'; text-align: center;"> 
    <strong>
        <span style="font-size: 16pt">
Onduty Calendar&nbsp;</span><br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <span style="color: black">
            Due to</span> :<asp:Label ID="Label1" runat="server" Text="Label" Width="53px"></asp:Label>&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="onduty_member_info.aspx"
            Target="_blank">電話表</asp:HyperLink></strong><asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" 
BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
ForeColor="#663399" Height="500px" OnDayRender="Calendar1_DayRender" ShowGridLines="True" 
Width="860px" OnSelectionChanged="Calendar1_SelectionChanged"> 
<SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" BorderColor="Black" ForeColor="Black" /> 
<SelectorStyle BackColor="#FFCC66" /> 
<TodayDayStyle BackColor="#FFCC66" ForeColor="DarkRed" /> 
<OtherMonthDayStyle ForeColor="#CC9966" /> 
<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" /> 
<DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" /> 
<TitleStyle BackColor="MediumPurple" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" /> 
</asp:Calendar> 
</div> 
<asp:BulletedList ID="bllColor" runat="server"> 
</asp:BulletedList> 



</asp:Content>

