<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="UtilityConsumption.aspx.cs" Inherits="Powder_MISProduct.ReportUI.UtilityConsumption" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Utility Consumption Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                       Utility Consumption Report
                    </div>
                    <div class="col-md-2 right" id="divExport" runat="server">
                        <asp:LinkButton ID="imgPDFButton" runat="server" OnClick="imgPDFButton_Click" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="imgExcelButton" runat="server" OnClick="imgExcelButton_Click" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>
<%--                        <asp:LinkButton ID="imgWordButton" runat="server" OnClick="imgbtnWord_OnClick" CssClass="btn btn-info quick-btn"><i class="fa fa-file-word-o"></i></asp:LinkButton>--%>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3">
                            From Date :
                        </div>
                        <div class="col-md-2">
                            From Time :
                        </div>
                        <div class="col-md-3">
                            To Date :
                        </div>
                        <div class="col-md-2">
                            To Time :
                        </div>
                        
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker1'>
                                <asp:TextBox ID="txtFromDate" CssClass="form-control" Placeholder="From Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtFromTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="From Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 has-error">
                            <div class='input-group date' id='datetimepicker2'>
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtToTime" ClientIDMode="Static" CssClass="form-control timepicker1" Placeholder="To Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                           <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" OnClick="btnGo_Click" />

                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12" style="overflow: scroll">
                         
                        <asp:GridView ID="gvUtilityConsumption" runat="server" GridLines="Both" 
                        AutoGenerateColumns="true" HeaderStyle-Wrap="false"
                        Width="100%" ShowHeader="false"
                        OnRowCreated="gvUtilityConsumption_RowCreated"
                        HeaderStyle-Font-Size="Medium" CssClass="table table-striped" 
                        HeaderStyle-HorizontalAlign="Center" >
                        <RowStyle HorizontalAlign="Center"  Width="100%"/>
                         </asp:GridView>  
                    <%-- <asp:GridView runat="server" ID="gvUtilityConsumption"
                        AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false"
                        HeaderStyle-Font-Size="Medium" CssClass="table table-striped">
                           <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr No" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="MCC1WheyProcesses" HeaderText="MCC1 Whey Processes (kVAh)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="MCC2Evaporator" HeaderText="MCC2 Evaporator (kVAh)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="MCC3Dryer" HeaderText="MCC3 Dryer (kVAh)" ItemStyle-Wrap="false" />
                           <asp:BoundField DataField="TotalPowerConsumption" HeaderText="Total Power Consumption (KW)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>                                             
                           <asp:BoundField DataField="SubPCC" HeaderText="Sub PCC (kVAh)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                           <asp:BoundField DataField="SteamConsumptioninWheyPlant" HeaderText="Steam Consumption in Whey Plant (Kg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                           <asp:BoundField DataField="SteamConsumptioninEvaporator" HeaderText="Steam Consumption in Evaporator (Kg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                           <asp:BoundField DataField="HPSteamConsumptioninDryer" HeaderText="HP Steam Consumption in Dryer (Kg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                           <asp:BoundField DataField="SteamConsumptionindryerothers" HeaderText="Steam Consumption in Dryer LP (Kg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                           <asp:BoundField DataField="TotalSteamConsumption" HeaderText="Total Steam Consumption (Kg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>       
                           <asp:BoundField DataField="ChilledWaterinWheyProcessing" HeaderText="Chilled Water in Whey Processing Area (Ltr/day)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>     
                           <asp:BoundField DataField="ChilledWaterinpowderplant" HeaderText="Chilled Water in Powder Plant (Ltr/day)" ItemStyle-Wrap="false" />
                           <asp:BoundField DataField="Chilledwaterinlettemp" HeaderText="Chilled Water Inlet Temp (°C)" ItemStyle-Wrap="false" />
                           <asp:BoundField DataField="ChilledwaterOutlettemp" HeaderText="Chilled Water Outlet Temp (°C)" ItemStyle-Wrap="false" />
                           <asp:BoundField DataField="AverageTemp" HeaderText="Average Temp (°C)" ItemStyle-Wrap="false" />
                           <asp:BoundField DataField="CHWConsumptionWheyPlant" HeaderText="CHW Consumption in TR Whey Plant" ItemStyle-Wrap="false" />
                           <asp:BoundField DataField="CHWConsumptionPP" HeaderText="CHW Consumption in TR PP" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="SoftWater" HeaderText="Soft Water (Ltr/day)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="ROWater" HeaderText="RO Water (Ltr/day)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="CompressedAir" HeaderText="Compressed Air (Ltr/day)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="RawWater" HeaderText="Raw Water (Ltr/day)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="PowderProduced" HeaderText="Powder Produced (Kg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                        </Columns>
                         </asp:GridView>--%>

                    </div>
               
    </div>
    <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        var date = new Date();
        var end = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        $('#datetimepicker1 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto",
            endDate: end
        });
        $('#datetimepicker2 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto",
            endDate: end
        });
        $(".timepicker").timepicker({
            showInputs: false,
            use24hours: true,
            format: 'HH:mm',
            showMeridian: false,
            showSeconds: true,
            minuteStep: 1,
            secondStep: 10
        });
        $(".timepicker1").timepicker({
            showInputs: false,
            use24hours: true,
            format: 'HH:mm',
            showMeridian: false,
            showSeconds: true,
            minuteStep: 1,
            secondStep: 10

        });
        $('datetimepicker1').datepicker('setDate', today);
        $('datetimepicker2').datepicker('setDate', today);
    </script>
</asp:Content>
