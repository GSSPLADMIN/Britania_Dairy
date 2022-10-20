<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Shift.aspx.cs" Inherits="Powder_MISProduct.WebUI.Shift" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Shift </li>
        </ul>
    </div>
    <div id="divCurrenTabSelected" class="hidden" visible="false">Setting</div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Shift"></asp:Label></h4>
                    </div>
                    <div class="col-md-3" style="padding-left: 20px;">
                        <div class="input-group ">
                            <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                            <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                        </div>
                    </div>
                    <div class="col-md-1 right">
                        <asp:Button runat="server" ID="btnAddNew" Text="Add New" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnAddNew_OnClick" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="gvShift" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvShift_OnPreRender" OnRowCommand="gvShift_OnRowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Name" DataField="Name" ItemStyle-Width="30%" HeaderStyle-Width="30%" />
                        <asp:BoundField HeaderText="From Time" DataField="FromTime" ItemStyle-Width="20%" HeaderStyle-Width="20%" />
                        <asp:BoundField HeaderText="To Time" DataField="ToTime" ItemStyle-Width="20%" HeaderStyle-Width="20%" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("ShiftId") %>' HeaderStyle-Width="25%" ItemStyle-Width="25%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("ShiftId") %>' HeaderStyle-Width="25%" ItemStyle-Width="25%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="panel panel-default" runat="server" id="divPanel">
            <div class="panel-heading">
                <h3 class="box-title">Shift</h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Name</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Enter Shift Name" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtName" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Shift Name." ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">From Time :</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtFromTime" ClientIDMode="Static" CssClass="form-control timepicker" Placeholder="From Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-1">To Time : </label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtToTime" ClientIDMode="Static" CssClass="form-control timepicker1" Placeholder="To Time" runat="server"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--<div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Description</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" placeholder="Enter Description" TextMode="MultiLine" Rows="4" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDescription" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Address" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>--%>
                <%--<div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">PLC Value</label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txtPLCValue" CssClass="form-control" onkeypress="return NumericKeyPressFraction(event)" placeholder="Enter PLC Value" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPLCValue" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter PLC Value" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>--%>
            </div>
            <div class="panel-footer">
                <div class="row">
                    <div class="col-md-offset-10 col-md-2">
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_OnClick" />
                        <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_OnClick" />
                        <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvShift.ClientID%> tbody tr');
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
    </script>

</asp:Content>
