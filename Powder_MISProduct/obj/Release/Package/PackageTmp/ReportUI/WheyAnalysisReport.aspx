<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="WheyAnalysisReport.aspx.cs" Inherits="Powder_MISProduct.ReportUI.WheyAnalysisReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Whey Analysis Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Whey Analysis Report
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
                    <div class="col-md-12" style="overflow-x:scroll; overflow-y:scroll" >
                         <asp:GridView ID="gvWheyAnalysis" runat="server" GridLines="Both" 
                        AutoGenerateColumns="true" HeaderStyle-Wrap="false"
                        Width="100%" ShowHeader="false"
                        OnRowCreated="gvWheyAnalysis_RowCreated" OnPreRender="gvWheyAnalysis_PreRender"
                        HeaderStyle-Font-Size="Medium" CssClass="table table-striped" 
                        HeaderStyle-HorizontalAlign="Center" >
                        <RowStyle HorizontalAlign="Center"  Width="100%"/>
                         </asp:GridView>
                         <%--<asp:GridView runat="server" ID="gvWheyAnalysis"
                        AutoGenerateColumns="False" GridLines="Both" HeaderStyle-Wrap="false"
                        HeaderStyle-Font-Size="Medium" CssClass="gvTheGrid striped" OnPreRender="gvWheyAnalysis_PreRender">
                                  <Columns>
                            <asp:BoundField DataField="SrNo" HeaderText="Sr No." ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="SampleName" HeaderText="SampleName" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="SampleNo" HeaderText="SampleNo" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="ProductName" HeaderText="ProductName" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="OT" HeaderText="OT" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Temp" HeaderText="Temp" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Fat" HeaderText="Fat" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="SNF" HeaderText="SNF" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Acidity" HeaderText="Acidity" ItemStyle-Wrap="false" />
                             <asp:BoundField DataField="COB" HeaderText="COB" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AlcholTest65" HeaderText="AlcholTest65" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AlcholTest" HeaderText="AlcholTest" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Blactumantibiotictest" HeaderText="Blactumantibiotictest" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="MineralOilTest" HeaderText="MineralOilTest" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AnyOtherTest01" HeaderText="AnyOtherTest01" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AnyOtherTest02" HeaderText="AnyOtherTest02" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AnyOtherTest03" HeaderText="AnyOtherTest03" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="AnyOtherTest04" HeaderText="AnyOtherTest04" ItemStyle-Wrap="false" />
                             <asp:BoundField DataField="Neutrilize" HeaderText="Neutrilize" ItemStyle-Wrap="false" />
                              <asp:BoundField DataField="Urea" HeaderText="Urea" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Salt" HeaderText="Salt" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Startch" HeaderText="Startch" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="FPD" HeaderText="FPD" ItemStyle-Wrap="false" />
                             <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Wrap="false" />
                            <asp:BoundField DataField="Remarks" HeaderText="Remark" ItemStyle-Wrap="false" />
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
