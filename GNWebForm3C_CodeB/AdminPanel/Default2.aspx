<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="AdminPanel_Default2" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Master Dashboard" runat="server"></asp:Label>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>2
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <%-- Search --%>
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ShowMessage1" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                </div>
            </div>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                        <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse pull-right"></a>
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server" AutoPostBack="true" OnSelectedIndexChanged="displayChange"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>
    <%-- Dashboard --%>
    <asp:UpdatePanel ID="Dashboard" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upDashboard" runat="server" UpdateMode="Conditional" Visible="false" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                        </div>
                    </div>
                    <div class="row" id="displayContent" runat="server">
                        <div class="col-md-12">

                            <asp:UpdatePanel ID="upCount" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption font-green">
                                                <i class="fa fa-line-chart font-green"></i>
                                                <span class="caption-subject bold uppercase">Total Overview</span>
                                            </div>
                                            <div class="tools"></div>
                                        </div>
                                        <div class="portlet-body form">
                                            <div class="form-horizontal" role="form">
                                                <div class="form-body">
                                                    <div class="row">
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">

                                                            <a class="dashboard-stat dashboard-stat-v2 blue" href='<%= "Account/ACC_Income/ACC_IncomeList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlHospitalID.SelectedValue.ToString())%>'>

                                                                <%--<a class="dashboard-stat dashboard-stat-v2 blue" href='<%# "~/AdminPanel/Account/ACC_Income/ACC_IncomeList.aspx?HospitalID=" + GNForm3C.CommonFunctions.EncryptBase64(ddlHospitalID.SelectedValue.ToString()) %>'>--%>
                                                                <div class="visual">
                                                                    <i class="fa fa-comments"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="lblNoIncomeCount"></asp:Label>
                                                                        <asp:Label runat="server" ID="lblIncomeCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Incomes </div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                                            <a class="dashboard-stat dashboard-stat-v2 red" href='<%= "Account/ACC_Expense/ACC_ExpenseList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlHospitalID.SelectedValue.ToString())%>'>
                                                                <div class="visual">
                                                                    <i class="fa fa-list"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="Label1"></asp:Label>
                                                                        <asp:Label runat="server" ID="lblExpenseCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Expenses</div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                                            <a class="dashboard-stat dashboard-stat-v2 green" href='<%= "Master/MST_SubTreatment/MST_SubTreatmentList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlHospitalID.SelectedValue.ToString())%>'>
                                                                <div class="visual">
                                                                    <i class="fa fa-shopping-cart"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="Label2"></asp:Label>
                                                                        <asp:Label runat="server" ID="lblPatientCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Patient</div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="IncomeExpenseGrid" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="portlet">
                                        <div class="portlet-body form">
                                            <div class="form-horizontal" role="form">
                                                <div class="form-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                            <div class="portlet box blue">
                                                                <div class="portlet-title">
                                                                    <div class="caption">
                                                                        <i class="fa fa-bullhorn "></i>INCOMES
                                                                    </div>
                                                                    <div class="tools">
                                                                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                                        <%--<a href="Account/ACC_Income/ACC_IncomeList.aspx"><i class="fa fa-edit font-white"></i></a>--%>
                                                                    </div>
                                                                </div>
                                                                <div class="portlet-body" style="display: block;">
                                                                    <div class="table-responsive">
                                                                        <div id="TableContent1">
                                                                            <asp:Label runat="server" ID="lblNoIncomeRecord" Visible="false" Text="No Record Found" CssClass="text-danger"></asp:Label>
                                                                            <asp:GridView ID="IncomeGrid" runat="server" AutoGenerateColumns="false" CssClass="gridview" OnRowDataBound="IncomeGrid_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="Date" HeaderText="Date" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                                    <asp:BoundField DataField="January" HeaderText="January" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="February" HeaderText="February" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="March" HeaderText="March" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="April" HeaderText="April" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="May" HeaderText="May" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="June" HeaderText="June" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="July" HeaderText="July" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="August" HeaderText="August" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="September" HeaderText="September" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="October" HeaderText="October" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="November" HeaderText="November" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="December" HeaderText="December" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                            <div class="portlet box blue">
                                                                <div class="portlet-title">
                                                                    <div class="caption">
                                                                        <i class="fa fa-bullhorn "></i>EXPENSE
                                                                    </div>
                                                                    <div class="tools">
                                                                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                                        <%--<a href="Account/ACC_Income/ACC_IncomeList.aspx"><i class="fa fa-edit font-white"></i></a>--%>
                                                                    </div>
                                                                </div>
                                                                <div class="portlet-body" style="display: block;">
                                                                    <div class="table-responsive">
                                                                        <div id="TableContent1">
                                                                            <asp:Label runat="server" ID="lblNoExpenseRecord" Visible="false" Text="No Record Found" CssClass="text-danger"></asp:Label>
                                                                            <asp:GridView ID="ExpenseGrid" runat="server" AutoGenerateColumns="false" CssClass="gridview" OnRowDataBound="IncomeGrid_RowDataBound">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="Date" HeaderText="Date" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                                                    <asp:BoundField DataField="January" HeaderText="January" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="February" HeaderText="February" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="March" HeaderText="March" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="April" HeaderText="April" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="May" HeaderText="May" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="June" HeaderText="June" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="July" HeaderText="July" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="August" HeaderText="August" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="September" HeaderText="September" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="October" HeaderText="October" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="November" HeaderText="November" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                    <asp:BoundField DataField="December" HeaderText="December" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                            <div class="portlet box red">
                                                                <div class="portlet-title">
                                                                    <div class="caption">
                                                                        <i class="fa fa-bullhorn "></i>TreatmentType Summary
                                                                    </div>
                                                                    <div class="tools">
                                                                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                                    </div>
                                                                </div>
                                                                <div class="portlet-body" style="display: block;">
                                                                    <div class="table-responsive">
                                                                        <div id="TableContent2">
                                                                            <asp:Label runat="server" ID="lblNoTreatmentSummary" Visible="false" Text="No Record Found" CssClass="text-danger"></asp:Label>
                                                                            <asp:GridView ID="TreatmentSummaryGrid" runat="server" AutoGenerateColumns="false" CssClass="gridview">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="SerialNo" HeaderText="Serial No" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                                                    <asp:BoundField DataField="TreatmentType" HeaderText="TreatmentType" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                                                    <asp:BoundField DataField="PatientsCount" HeaderText="Patients" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" />
                                                                                    <asp:BoundField DataField="IncomesAmount" HeaderText="Amount" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right" DataFormatString="{0:C}" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <h2>Income Chart</h2>
                                                            <canvas id="incomeChart"></canvas>
                                                            <h2>Expense Chart</h2>
                                                            <canvas id="expenseChart"></canvas>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <%--<asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />--%>
                    <%--<asp:PostBackTrigger ControlID="lbtnExportExcel" />
            <asp:PostBackTrigger ControlID="lbtnExportPDF" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </ContentTemplate>

    </asp:UpdatePanel>
    <%-- END Dashboard--%>



    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text=" Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        function createCharts() {
            var incomeData = <%= GetIncomeDataJson() %>;
             var expenseData = <%= GetExpenseDataJson() %>;

            var ctxIncome = document.getElementById('incomeChart');
            if (ctxIncome) {
                var incomeChart = new Chart(ctxIncome.getContext('2d'), {
                    type: 'bar',
                    data: {
                        labels: incomeData.labels,
                        datasets: [{
                            label: 'Total Income',
                            data: incomeData.values,
                            backgroundColor: 'rgba(75, 192, 192, 0.2)',
                            borderColor: 'rgba(75, 192, 192, 1)',
                            borderWidth: 1
                        }]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            }
                        }
                    }
                });
            } else {
                console.error("Canvas element for incomeChart not found.");
            }

            var ctxExpense = document.getElementById('expenseChart');
            if (ctxExpense) {
                var expenseChart = new Chart(ctxExpense.getContext('2d'), {
                    type: 'bar',
                    data: {
                        labels: expenseData.labels,
                        datasets: [{
                            label: 'Total Expense',
                            data: expenseData.values,
                            backgroundColor: 'rgba(255, 99, 132, 0.2)',
                            borderColor: 'rgba(255, 99, 132, 1)',
                            borderWidth: 1
                        }]
                    },
                    options: {
                        scales: {
                            y: {
                                beginAtZero: true
                            }
                        }
                    }
                });
            } else {
                console.error("Canvas element for expenseChart not found.");
            }
        }

        // Call createCharts after the UpdatePanel is updated
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(createCharts);


        window.onload = function () {
            createCharts();
        };
    </script>
</asp:Content>
