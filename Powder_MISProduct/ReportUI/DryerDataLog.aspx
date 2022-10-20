<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="DryerDataLog.aspx.cs" Inherits="Powder_MISProduct.ReportUI.DryerDataLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Dryer Data Log Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Dryer Data Log Report
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
                        <asp:GridView ID="gvDryer" runat="server" GridLines="Both" 
                        AutoGenerateColumns="true" HeaderStyle-Wrap="false"
                        Width="100%" ShowHeader="false"
                        OnRowCreated="gvDryer_RowCreated" OnPreRender="gvDryer_PreRender"
                        HeaderStyle-Font-Size="Medium" CssClass="table table-striped" 
                        HeaderStyle-HorizontalAlign="Center" >
                        <RowStyle HorizontalAlign="Center"  Width="100%"/>
                         </asp:GridView>
                         <%--<asp:GridView runat="server" ID="gvDryer"
                        AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false"
                        HeaderStyle-Font-Size="Medium" CssClass="gvTheGrid striped" OnPreRender="gvDryer_PreRender">
                           <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr No." ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="PlantStatus" HeaderText="PlantStatus" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AtomiserVibrationMonitoring" HeaderText="AtomiserVibrationMonitoring(um)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AtomizerRotationalSpeed" HeaderText="AtomizerRotationalSpeed(rpm%)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AtomizeroilPressure" HeaderText="AtomizeroilPressure" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AtomizeroilCircuilation" HeaderText="AtomizeroilCircuilation" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Atomizerrunninghour" HeaderText="Atomizerrunninghour" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="HomogenizerInletPressure" HeaderText="HomogenizerInletPressure(bar)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="HomogenizerFreq" HeaderText="HomogenizerFreq(Hz)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="HomogenizeroutletPressure" HeaderText="HomogenizeroutletPressure(bar)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="DryerfeedFlow" HeaderText="DryerfeedFlow(Kg/hr)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="DryerFeedTemp" HeaderText="DryerFeedTemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="AirIntakePressuare" HeaderText="AirIntakePressure(mmWC)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="DryingChamberVaccum" HeaderText="DryingChamberVaccum(mmHg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="VibroVacacum" HeaderText="VibroVacacum(mmHg)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Mainairsupplyflow" HeaderText="Mainairsupplyflow(Kg/hr)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="SFBFlow" HeaderText="SFBFlow(Kg/hr)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="VFFlow" HeaderText="VFFlow(Kg/hr)" ItemStyle-Wrap="false" />
                         <asp:BoundField DataField="Airdispersertemp" HeaderText="Airdispersertemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="MozzleCoolingTemp" HeaderText="MozzleCoolingTemp(°C)" ItemStyle-Wrap="false" />

                               <asp:BoundField DataField="Mainairsupplytemp" HeaderText="Mainairsupplytemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="SFBAirsupplytemp" HeaderText="SFBAirsupplytemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Wallsweepairtemp" HeaderText="Wallsweepairtemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="VF1Airsupplytemp" HeaderText="VF1Airsupplytemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="VF2Chillingtemp" HeaderText="VF2Chillingtemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="VF2Heatingtemp" HeaderText="VF2Heatingtemp(°C)" ItemStyle-Wrap="false" />
                         <asp:BoundField DataField="Sifterinlettemp" HeaderText="Sifterinlettemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Chamberoutlettemp" HeaderText="Chamberoutlettemp(°C)" ItemStyle-Wrap="false" />

                               <asp:BoundField DataField="VFOutlettemp" HeaderText="VFOutlettemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="Dryerexhausttemp" HeaderText="Dryerexhausttemp(°C)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="SFBDPT" HeaderText="SFBDPT(mmWC)" ItemStyle-Wrap="false" />
                         <asp:BoundField DataField="Cyclone1dpt" HeaderText="Cyclone1dpt(mmWC)" ItemStyle-Wrap="false" ><ItemStyle CssClass="right-align" /></asp:BoundField>
                            <asp:BoundField DataField="RootsBlowerpressure" HeaderText="RootsBlowerpressure(mmWC)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="RootsBlowerTemp" HeaderText="RootsBlowerTemp(°C)" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Recoverytankqnt" HeaderText="Recoverytankqnt(Lit)" ItemStyle-Wrap="false" />

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
