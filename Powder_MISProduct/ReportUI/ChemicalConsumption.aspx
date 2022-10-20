<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="ChemicalConsumption.aspx.cs" Inherits="Powder_MISProduct.ReportUI.ChemicalConsumption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">CIP Chemical Consumption Report</li>
        </ul>
    </div>
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-10" style="font-size: 24px;">
                       CIP Chemical Consumption Report
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
                        <div class="col-md-2">
                            Shift: 
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="col-md-2 has-error">
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
                        <div class="col-md-2 has-error">
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
                            <asp:DropDownList ID="dd_Shift" runat="server" CssClass="form-control dropdown">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Shift-1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Shift-2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Shift-3" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                           <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-primary pull-right" ValidationGroup="g1" OnClick="btnGo_Click" />

                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12" style="overflow: scroll">
                       <asp:GridView ID="gvChemicalConsumption" runat="server" GridLines="Both" 
                        AutoGenerateColumns="true" HeaderStyle-Wrap="false"
                        Width="100%" ShowHeader="false"
                        OnRowCreated="gvChemicalConsumption_RowCreated"
                        HeaderStyle-Font-Size="Medium" CssClass="table table-striped" 
                        HeaderStyle-HorizontalAlign="Center" >
                        <RowStyle HorizontalAlign="Center"  Width="100%"/>
                         </asp:GridView>

                    </div>
                </div>
                <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>

                <%--<div class="row">
                    <div class="col-md-12" style="overflow: scroll">
                       <div class="row" id="GridView" runat="server">

                <div id="table-container">
                     <div class="col-md-12" style="overflow: scroll">
                       <asp:GridView ID="gvChemicalConsumption" runat="server" GridLines="Both" 
                        AutoGenerateColumns="true" HeaderStyle-Wrap="false"
                        Width="100%" ShowHeader="false"
                        OnRowCreated="gvChemicalConsumption_RowCreated" HeaderStyle-Font-Size="Medium" CssClass="gvTheGrid striped" 
                        HeaderStyle-HorizontalAlign="Center" >
                        <RowStyle HorizontalAlign="Center"  Width="100%"/>
                         </asp:GridView>

                    </div>--%>
                    <%--<asp:GridView ID="gvChemicalConsumption" runat="server" GridLines="Both" 
                        AutoGenerateColumns="false" HeaderStyle-Wrap="false"
                        Width="100%" HeaderStyle-Font-Size="Medium" CssClass="gvTheGrid striped">
                      <Columns>

                          <asp:BoundField DataField="SrNo" HeaderText="SrNo " ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  />
                          <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  />
                          <asp:BoundField DataField="Time" HeaderText="Time" ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  />
                          <asp:BoundField DataField="Acid" HeaderText="Acid" ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                           <asp:BoundField DataField="Lye" HeaderText="Lye " ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  />
                        
                      </Columns>
                    </asp:GridView>--%>
                <%--</div>
            </div>

                    </div>
                </div>
                <div class="col-md-12 center" id="divNo" runat="server">No records found.</div>--%>
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
           // endDate: end
        });
        $('#datetimepicker2 input').datepicker({
            clearBtn: true,
            format: 'dd/mm/yyyy',
            autoclose: true,
            orientation: "top auto",
            //endDate: end
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
