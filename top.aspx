<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="top" Title="值班記錄-公告" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align=center>
<head id="Head1" >
    <title>值班記錄公佈欄-查詢</title>
    <link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" />


</head>        
<legend align="center" style="color:blue;text-align:center"><strong><span style="font-size: 14pt; color: #0000ff;">
    最新公告</span></strong></legend> <br /> 
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                Font-Size="X-Small" DataSourceID="SqlDataSource1" AllowPaging="True" BackColor="White"
                BorderColor="#3366CC" BorderWidth="1px" Height="305px" Width="800px" BorderStyle="None"
                PageSize="5" Font-Names="Century Gothic" HorizontalAlign="Center">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" BorderStyle="Dashed" />
                <Columns>
                    <asp:TemplateField HeaderText="RN">
                        <ItemTemplate>
                            <asp:Label ID="lblrownum" runat="server" ForeColor="DarkGreen" Text='<%# Bind("rownum") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="fab">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            fab:</br>
                            <asp:Label ID="lblfab" runat="server" ForeColor="DarkGreen" Text='<%# Bind("fab") %>'></asp:Label></br>
                            publisher:</br>
                            <asp:Label ID="lblpublisher" runat="server" ForeColor="DarkGreen" Text='<%# Bind("publisher") %>'></asp:Label></br>
                            公佈時間:</br>
                            <asp:Label ID="lblupdate_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("update_time") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            開始時間:</br>
                            <asp:Label ID="lblbegin_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("begin_time") %>'></asp:Label></br>
                            結束時間:</br>
                            <asp:Label ID="lblend_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("end_time") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            主旨:</br>
                            <asp:Label ID="lblsubject" runat="server" ForeColor="DarkGreen" Text='<%# Bind("subject") %>'></asp:Label></br>
                            內容:</br>
                            <asp:Label ID="lblcontent" runat="server" ForeColor="DarkGreen" Text='<%# Bind("content") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Download">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://10.56.131.22" +Context.Request.ApplicationPath+"/FileList/"+ DataBinder.Eval(Container.DataItem, "org_file_name") %> '
                                Text='<%# Bind("org_file_name") %>' ForeColor="DeepPink" runat="server"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <RowStyle BackColor="White" ForeColor="#003399" Font-Size="X-Small" />
                <AlternatingRowStyle BackColor="#EFEDEF" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>"
                ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="select rownum,tb2.* from (&#13;&#10;&#13;&#10;select fab,&#13;&#10;       publisher,&#13;&#10;       subject,&#13;&#10;       to_char(begin_time,'YYYY/MM/DD') as begin_time,&#13;&#10;       to_char(end_time,'YYYY/MM/DD')as end_time,&#13;&#10;       content,&#13;&#10;       to_char(update_time,'YYYY/MM/DD') as update_time,&#13;&#10;       file_name,&#13;&#10;       org_file_name&#13;&#10;  from board t&#13;&#10;  where t.end_time>sysdate&#13;&#10;  order by t.update_time desc&#13;&#10;&#13;&#10;)tb2">
            </asp:SqlDataSource>
                
        <table border="0" cellpadding="0" cellspacing="0" style="background-color: white; width: 100%; height: 25px;">
       
    </table>
       

</div> 

</asp:Content>

