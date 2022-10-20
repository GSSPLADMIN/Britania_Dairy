<%@ Page Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="MassBalanceForSMP.aspx.cs" Inherits="Powder_MISProduct.ReportUI.MassBalanceForSMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">MASS BALANCE FOR SMP</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                        Mass Balance For SMP
                   
                    </div>
                    <div class="col-md-2" id="divExport" runat="server">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="imgbtnPDF_OnClick" CssClass="btn btn-danger quick-btn"><i class="fa fa-file-pdf-o"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="imgbtnExcel_OnClick" CssClass="btn btn-success quick-btn"><i class="fa fa-file-excel-o"></i></asp:LinkButton>

                    </div>
                </div>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-2">
                            From Date :
                       
                        </div>
                        <div class="col-md-2">
                            From Time :    
                                           
                        </div>
                        <div class="col-md-2">
                            To Date :      
                                           
                        </div>
                        <div class="col-md-2">
                            To Time :      
                                           
                        </div>
                        <%-- <div class="col-md-2">
                            Tank No :
                       
                        </div>--%>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-2 has-error">
                            <div class='input-group date' id='datetimepicker1' style="width: 170px">
                                <asp:TextBox ID="txtFromDate" CssClass="form-control" Placeholder="From Date" runat="server"></asp:TextBox>
                                <span id="cal" class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group" style="width: 170px">
                                        <asp:TextBox ID="txtFromTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="From Time" runat="server"></asp:TextBox>
                                        <span id="time" class="input-group-addon timepicker"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 has-error">
                            <div class='input-group date' id='datetimepicker2' style="width: 170px">
                                <asp:TextBox ID="txtToDate" CssClass="form-control" Placeholder="To Date" runat="server"></asp:TextBox>
                                <span id="cal1" class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group" style="width: 170px">
                                        <asp:TextBox ID="txtToTime" ClientIDMode="Static" CssClass="form-control timepicker1" Placeholder="To Time" runat="server"></asp:TextBox>
                                        <span id="tm" class="input-group-addon timepicker1"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row" style="margin-top: 10px; padding-bottom: 15px;">
                    <div class="col-md-12">
                        <div class="col-md-3"></div>
                        <div class="col-md-1">
                            <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary right" ValidationGroup="g1" OnClick="btnGo_OnClick" Style="margin-left: 700px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter From Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter To Date" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="overflow: scroll;" title="Mass Balance Whey Details">
                    <%--<asp:GridView runat="server" ID="gvMassBalanceReport" Font-Size="Large" CssClass="table table-hover table-striped"
                        AutoGenerateColumns="false" GridLines="Both" Width="80%">--%>
                    <asp:GridView ID="gvMassBalanceReport" runat="server" CssClass="table table-striped" ShowHeader="false"
                        AutoGenerateColumns="true" GridLines="Both" HeaderStyle-Wrap="false" OnRowCreated="gvMassBalanceReport_RowCreated" >
                    </asp:GridView>
                </div>
                
                <%--2. Total data--%>
                <div class="row" style="padding-top: 10px; overflow: scroll;">
                    <div class="form-group has-error col-md-4" title="Varient wise total production" style="overflow; height: 300px">
                     <asp:GridView runat="server" ID="gvTotal" CssClass="table table-striped" ShowHeader="false"
                            AutoGenerateColumns="True" GridLines="Both" HeaderStyle-Wrap="false" OnRowCreated="gvTotal_RowCreated">
                           </asp:GridView>
                    </div>
                </div>

                <div class="row"> 
                    <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">


        $('.input-group').find('#cal').on('click', function () {
            $('[id$=txtFromDate]').trigger('focus');
        });

        $('.input-group').find('#cal1').on('click', function () {
            $('[id$=txtToDate]').trigger('focus');
        });

        $('.input-group').find('#time').on('click', function () {
            $('[id$=txtFromTime]').trigger('focus');
        });

        $('.input-group').find('#tm').on('click', function () {
            $('[id$=txtToTime]').trigger('focus');
        });
        $('#datetimepicker1 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
        $('#datetimepicker2 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto"
        });
        //Timepicker
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
    </script>
</asp:Content>
