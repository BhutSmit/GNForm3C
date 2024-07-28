<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="DemoView.aspx.cs" Inherits="AdminPanel_Master_Demo_DemoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
                <span class="caption-subject font-green-sharp bold uppercase">Transaction</span>
            </div>
            <div class="tools">
                <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <table class="table table-bordered table-advance table-hover">
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblId_XXXXX" Text="Patient" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblId" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblName_XXXXX" Text="Treatment" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

