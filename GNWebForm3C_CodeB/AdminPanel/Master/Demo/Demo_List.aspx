<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="Demo_List.aspx.cs" Inherits="AdminPanel_Master_Demo_Demo_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="demo"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Master"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h2>Demo</h2>
            <div class="portlet-body">
                <h1>demo</h1>
                <div>
                    <asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/Master/Demo/DemoAddEdit.aspx" runat="server"></asp:HyperLink>
                </div>
                <div class="col-md-12">
                    <div id="TableContent">
                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                            <%-- Table Header --%>
                            <thead>
                                <tr class="TRDark">
                                    <th>
                                        <asp:Label ID="lbhDEMOId" runat="server" Text="ID"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lbhPrintDEMO" runat="server" Text="Name"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label Text="Button"></asp:Label>
                                    </th>
                                </tr>
                            </thead>
                            <%-- END Table Header --%>

                            <tbody>
                                <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand">
                                    <ItemTemplate>
                                        <%-- Table Rows --%>
                                        <tr class="odd gradeX">
                                            <td>
                                                <%--<asp:HyperLink ID="hlViewHospitalID" NavigateUrl='<%# "~/AdminPanel/Master/MST_Hospital/MST_HospitalView.aspx?HospitalID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("HospitalID").ToString()) %>' data-target="#viewiFrameReg" CssClass="modalButton" data-toggle="modal" runat="server"><%#Eval("Hospital") %></asp:HyperLink>--%>
                                            </td>
                                            <td>
                                                <%#Eval("Id") %>
                                            </td>
                                            <td>
                                                <%#Eval("Name") %>
                                            </td>

                                            <td class="text-nowrap text-center">
                                                <asp:HyperLink ID="hlView" SkinID="View" NavigateUrl='<%# "~/AdminPanel/Master/Demo/DemoView.aspx?Id=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("Id").ToString()) %>' data-target="#viewiFrameReg" data-toggle="modal" runat="server"></asp:HyperLink>
                                                <asp:HyperLink ID="hlEdit" SkinID="Edit" NavigateUrl='<%# "~/AdminPanel/Master/Demo/DemoAddEdit.aspx?Id=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("Id").ToString()) %>' runat="server"></asp:HyperLink>
                                            <asp:LinkButton ID="lbtnDelete" runat="server"
                                                SkinID="Delete"
                                                OnClientClick="javascript:return confirm('Are you sure you want to delete record ? ');"
                                                CommandName="DeleteRecord"
                                                CommandArgument='<%#Eval("Id") %>'>
                                            </asp:LinkButton>
                                            </td>
                                        </tr>
                                        <%-- END Table Rows --%>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

