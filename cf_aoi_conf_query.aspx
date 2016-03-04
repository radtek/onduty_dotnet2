<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="cf_aoi_conf_query.aspx.cs" Inherits="cf_aoi_conf_query" Title="EDA_CF_AOI_CONFIG" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<head id="Head1" >
    <title>值班記錄-查詢</title>
<link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" /> </head>
   <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100" EnableViewState="False">
        <ProgressTemplate>
            <div id="updating" style="width: 150px; height: 25px; color: #A52A2A; position: absolute;
                left: 50%; top: 50%; margin-top: -50px; margin-left: -100px; text-align: center;
                border: black 3px double; background-color: #99CCFF;">
                資料更新中.....
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
 
 <div style="display: inline; z-index: 105; left: 10px; width: 100%; color: black;
            top: 0px; height: 16px; background-color: white">
    <%--        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
            </asp:ScriptManager>--%>
              <br />
            <table id="Table3" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="height: 9px">
                        <img src="images/tables/default_lt.gif" /></td>
                    <td style="background-image: url(images/tables/default_t.gif); height: 9px; width: 955px;">
                        <img height="9" src="images/tables/transparent.gif" /></td>
                    <td style="height: 9px">
                        <img src="images/tables/default_rt.gif" /></td>
                </tr>
                <tr>
                    <td style="background-image: url(images/tables/default_l.gif)">
                        <img src="images/tables/transparent.gif" width="9"></td>
                    <td align="middle" style="width: 955px">
                    
                        <table align="center" cellspacing="0" bordercolordark="#ffffff" cellpadding="2" width="90%"
                            bordercolorlight="#7a9cb7" border="1">
                            <tr>
                                <td background="" colspan="4" class="pageTitle" style="height: 24px">
                                    <table width="100%" >
                                        <tr>
                                            <td align="left" style="width: 533px; height: 24px;">
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>EDA_CF_AOI_CONFIG-查詢</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 24px;">
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    EQID</td>
                                <td align="left" style="width: 188px; height: 24px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    ProdID</td>
                                <td style="width: 37px; height: 24px">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    SubEQID</td>
                                <td align="left" style="width: 188px; height: 24px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    RECIPE</td>
                                <td style="width: 37px; height: 24px">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList4" runat="server" >
                                            </asp:DropDownList>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px">
                                    <asp:Button ID="ButtonQuery" runat="server" Style="font-size: 12px; font-family: Arial;
                                        width: 100px;" Text="Query" OnClick="ButtonQuery_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnExport" runat="server" Style="font-size: 12px; font-family: Arial;
                                        width: 100px;" Text="Export" OnClick="btnExport_Click1" />&nbsp; 
                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl="~/CF_AOI_STEP_MAPPING.xls">Stage Mapping</asp:HyperLink></td></td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <fieldset>
                                        <legend id="Legend5" runat="server" style="font-weight: bold; font-size: 12px; font-family: Arial;
                                            color: black">&nbsp;&nbsp;&nbsp;查詢結果 </legend>
                                        <br />
                                        
                                        <table width="100%">
                                            <tr>
                                                <td style="height: 169px">
                                                    <%--<asp:GridView ID="gvTask" runat="server" Font-Names="Arial" Font-Size="12px" Width="100%"
                                                        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Task!" OnRowDataBound="gvTask_RowDataBound"
                                                        ForeColor="#333333" GridLines="None">--%>
                                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound">
                                                <RowStyle BackColor="#F7F7DE" />
                                                <FooterStyle BackColor="#CCCC99" />
                                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField HeaderText="RN" />
                                                </Columns>
                                            </asp:GridView>
                                          
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                                   
                              
                                                </td>
                                            </tr>
                                        </table>
                                         
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="font-size: 12pt; background-image: url(images/tables/default_r.gif)">
                        <img src="images/tables/transparent.gif" width="9"></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 9px">
                        <img src="images/tables/default_lb.gif"></td>
                    <td style="background-image: url(images/tables/default_b.gif); height: 9px; width: 955px;">
                        <img height="9" src="images/tables/transparent.gif"></td>
                    <td style="height: 9px">
                        <img src="images/tables/default_rb.gif"></td>
                </tr>
            </table>
 
</div>
</asp:Content>

