<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Maintenance.aspx.cs" Inherits="Powder_MISProduct.WebUI.Maintenance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <%--            <li class="active">Maintenance </li>--%>
        </ul>
    </div>
    <div id="divCurrenTabSelected" class="hidden" visible="false">master</div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="box box-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Maintenance"></asp:Label></h4>
                    </div>
                    <div class="col-md-3" style="padding-left: 20px;">
                        <div class="input-group ">
                            <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                            <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                        </div>
                    </div>
                    <div class="col-md-1 right">
                        <asp:Button runat="server" ID="btnAddNew" Text="Add New" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnAddNew_Click" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New"></asp:Button>
                    </div>
                </div>
            </div>
            <asp:GridView runat="server" ID="gvMaintenance" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvMaintenance_PreRender" OnRowCommand="gvMaintenance_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="StartTime" DataField="StartTime" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="EndTime" DataField="EndTime" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="Area" DataField="Area" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="EquipmentName" DataField="EquipmentName" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="EquipmentTagNo" DataField="EquipmentTagNo" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="PartNo" DataField="PartNo" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="ProblemDetails" DataField="ProblemDetails" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="ActionTaken" DataField="ActionTaken" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="RectifiedBy" DataField="RectifiedBy" ItemStyle-Width="70%" />
                    <asp:BoundField HeaderText="Remark" DataField="Remark" ItemStyle-Width="70%" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' ItemStyle-Width="10%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' ItemStyle-Width="10%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="box box-primary" runat="server" id="divPanel">
            <%--  <div class="box-header">
                <h3 class="box-title">Maintenance</h3>
            </div>--%>
            <div class="box-body">
                <div id="div1" runat="server" class="box box-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-8">
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text="Maintenance"></asp:Label></h4>
                            </div>
                            <div class="col-md-3" style="padding-left: 20px;">
                                <div class="input-group ">
                                    <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                                    <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                                </div>
                            </div>
                            <div class="col-md-1 right">
                                <asp:Button runat="server" ID="Button1" Text="Add New" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnAddNew_Click" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <%--  <div class="box-body no-padding">
                <asp:GridView runat="server" ID="gvMaintenance" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvMaintenance_PreRender" OnRowCommand="gvMaintenance_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="StartTime" DataField="StartTime" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="EndTime" DataField="EndTime" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="Area" DataField="Area" ItemStyle-Width="70%" />
                         <asp:BoundField HeaderText="EquipmentName" DataField="EquipmentName" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="EquipmentTagNo" DataField="EquipmentTagNo" ItemStyle-Width="70%" />
                         <asp:BoundField HeaderText="PartNo" DataField="PartNo" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="ProblemDetails" DataField="ProblemDetails" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="ActionTaken" DataField="ActionTaken" ItemStyle-Width="70%" />
                         <asp:BoundField HeaderText="RectifiedBy" DataField="RectifiedBy" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="Remark" DataField="Remark" ItemStyle-Width="70%" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' ItemStyle-Width="10%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' ItemStyle-Width="10%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>--%>
                </div>
                <div class="box box-primary" runat="server" id="div2">
                    <%--            <div class="box-header">
                <h3 class="box-title">Maintenance</h3>
            </div>--%>
                    <div class="box-body">
                        <div class="row" style="margin-bottom: 20px;">
                            <div class="form-group">
                                <label class="col-md-2">Date :</label>
                                <div class="col-md-4">
                                    <div class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                        <asp:TextBox runat="server" ID="txtDate" CssClass="form-control date" placeholder="Date" />
                                    </div>
                                </div>

                            </div>

                            <div class="form-group has-error">
                                <label class="col-md-2">StartTime :</label>
                                <div class="col-md-4">
                                    <div class="bootstrap-timepicker">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtStartTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="Start Time" runat="server"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="row">


                            <div class="form-group">
                                <label class="col-md-2">EndTime :</label>
                                <div class="col-md-4">
                                    <div class="bootstrap-timepicker">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                                <%--                                <asp:TextBox runat="server" ID="txtEndtime" CssClass="form-control date" placeholder="Endtime" />--%>
                                                <asp:TextBox ID="txtEndtime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="End Time" runat="server"></asp:TextBox>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <label class="col-md-2">Area :</label>
                                <div class="col-md-4">
                                    <%--                            <div class="input-group">--%>
                                    <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                                    <asp:TextBox runat="server" ID="txtArea" CssClass="form-control" placeholder="Area" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group has-error">

                                <label class="col-md-2">Equipment Name :</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtEquipmentname" CssClass="form-control" placeholder="Equipment Name" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEquipmentname" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter Equipment Name" ForeColor="Red">*</asp:RequiredFieldValidator>

                                </div>

                                <div class="form-group">
                                    <label class="col-md-2">Equipment TagNo :</label>
                                    <div class="col-md-4">
                                        <%--                            <div class="input-group">--%>
                                        <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                                        <asp:TextBox runat="server" ID="txtEquipmentTagNo" CssClass="form-control" placeholder="Equipment TagNo" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group has-error">

                                <label class="col-md-2">Part Number :</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtPartNumber" CssClass="form-control" placeholder="PartNumber" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartNumber" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter PartNumber" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2">Problem Details :</label>
                                <div class="col-md-4">
                                    <%--                            <div class="input-group">--%>
                                    <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                                    <asp:TextBox runat="server" ID="txtProblemdetails" CssClass="form-control" placeholder="Problem Details" />
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="form-group has-error">

                                <label class="col-md-2">ActionTaken :</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtActionTaken" CssClass="form-control" placeholder="ActionTaken" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtActionTaken" ValidationGroup="g1"
                                        SetFocusOnError="True" ErrorMessage="Enter ActionTaken" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2">Rectified By :</label>
                                <div class="col-md-4">
                                    <%--                            <div class="input-group">--%>
                                    <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                                    <asp:TextBox runat="server" ID="txtRectifiedBy" CssClass="form-control" placeholder="Rectified By" />
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="form-group">

                                <label class="col-md-2">Remarks :</label>
                                <div class="col-md-4">
                                    <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" placeholder="Remarks" />
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRemarks" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Remarks" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                         <br />

                        <div class="row">
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" />
                                    <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_Click" />


                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--<script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvMaintenance.ClientID%> tbody tr');
        });
        $('.date').datepicker({
            format: "dd/mm/yyyy",
            clearBtn: true,
            autoclose: true,
            todayHighlight: true
        });

    </script>--%>
    <script type="text/javascript">
        var date = new Date();
        var end = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        $(function () {
            $('#id_search').quicksearch('table#<%=gvMaintenance.ClientID%> tbody tr');
       });
        $('.date').datepicker({
            format: "dd/mm/yyyy",
            clearBtn: true,
            autoclose: true,
            todayHighlight: true
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
