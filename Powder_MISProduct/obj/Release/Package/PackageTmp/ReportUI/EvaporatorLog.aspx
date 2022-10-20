<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="EvaporatorLog.aspx.cs" Inherits="Powder_MISProduct.ReportUI.EvaporatorLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">| Evaporator Log Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Evaporator Log Report
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
                    <div class="col-md-12">
                         <div class="col-md-12" style="overflow: scroll">
                        <asp:GridView ID="gvEvaporator" runat="server" GridLines="Both" 
                        AutoGenerateColumns="true" HeaderStyle-Wrap="false"
                        Width="100%" ShowHeader="false"
                        OnRowCreated="gvEvaporator_RowCreated" OnPreRender="gvEvaporator_PreRender"
                        HeaderStyle-Font-Size="Medium" CssClass="table table-striped" 
                        HeaderStyle-HorizontalAlign="Center" >
                        <RowStyle HorizontalAlign="Center"  Width="100%"/>
                         </asp:GridView>
                        <%-- <asp:GridView runat="server" ID="gvEvaporator"
                        AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false"
                        HeaderStyle-Font-Size="Medium" CssClass="gvTheGrid striped" OnPreRender="gvEvaporator_PreRender1">
                           <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr No." ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="PlantStatus" HeaderText="PlantStatus" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="EvapBalanceTank" HeaderText="EvapBalanceTank(%)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="FeedFlow" HeaderText="FeedFlow(Kg/hr)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="FeedConductivity" HeaderText="FeedConductivity(ms/cm)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="FeedPreheatertmp" HeaderText="FeedPreheatertmp(°C)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="PCDTemp" HeaderText="PCDTemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="FV1Heatingtemp" HeaderText="FV1Heatingtemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="FV2Heatingtemp" HeaderText="FV2Heatingtemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="DSITemp" HeaderText="DSITemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="FV1regenerationtemp" HeaderText="FV1regenerationtemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="FV2regenerationtemp" HeaderText="FV2regenerationtemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Cal1Temp" HeaderText="Cal1Temp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Cal2Temp" HeaderText="Cal2Temp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Cal3Temp" HeaderText="Cal3Temp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Cal4Temp" HeaderText="Cal4Temp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="CondenserCWInTemp" HeaderText="CondenserCWInTemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="CondenserCWOutTemp" HeaderText="CondenserCWOutTemp(°C)" ItemStyle-Wrap="false" />
                         <asp:BoundField DataField="CondenserTemp" HeaderText="CondenserTemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="PlantVaccum" HeaderText="PlantVaccum(mbar)" ItemStyle-Wrap="false" />

                               <asp:BoundField DataField="PCDTVRPressure" HeaderText="PCDTVRPressure(barg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="CalTVRPressure" HeaderText="CalTVRPressure(barg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="DSIBackPressure" HeaderText="DSIBackPressure(barg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="DSISteamSupplyPressure" HeaderText="DSISteamSupplyPressure(barg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="DSIOutletTemp" HeaderText="DSIOutletTemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="CondensateCond" HeaderText="CondensateCond(ms/cm)" ItemStyle-Wrap="false" />
                         <asp:BoundField DataField="Ejector1SteamPressure" HeaderText="Ejector1SteamPressure(barg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Ejector2SteamPressure" HeaderText="Ejector2SteamPressure(barg)" ItemStyle-Wrap="false" />

                               <asp:BoundField DataField="ConcFlow" HeaderText="ConcFlow(Kg/hr)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="FinalConcDensity" HeaderText="FinalConcDensity(Kg/m3)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="FinalConcFlow" HeaderText="FinalConcFlow(Kg/hr)" ItemStyle-Wrap="false" />
                         <asp:BoundField DataField="FinalConcTemp" HeaderText="FinalConcTemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>

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
