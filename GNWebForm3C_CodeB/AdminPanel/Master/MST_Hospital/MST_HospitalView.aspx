<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default/MasterPageView.master" CodeFile="MST_HospitalView.aspx.cs" Inherits="AdminPanel_Master_MST_Hospital_MST_HospitalView" Title="Hospital View" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!-- BEGIN SAMPLE FORM PORTLET-->
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
                            <asp:Label ID="lblPatient_XXXXX" Text="Patient" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblHospital" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblTreatmentID_XXXXX" Text="Treatment" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPrintName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblAmount_XXXXX" Text="Amount" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPrintLine1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblSerialNo_XXXXX" Text="Serial No" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPrintLine2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblReferenceDoctor_XXXXX" Text="Reference Doctor" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPrintLine3" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblCount_XXXXX" Text="Count" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFooterName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblReceiptNo_XXXXX" Text="Receipt No" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReportHeaderName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblDate_XXXXX" Text="Date" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblDateOfAdmission_XXXXX" Text="Date Of Admission" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUserID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblDateOfDischarge_XXXXX" Text="Date Of Discharge" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCreated" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblDeposite_XXXXX" Text="Deposite" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblModified" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </div>

    <!-- END SAMPLE FORM PORTLET-->
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {
                ;
                $("#CloseButton").trigger("click");
            }
        });
    </script>
</asp:Content>
