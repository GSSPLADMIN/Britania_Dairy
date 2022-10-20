<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="UtilityConsumptionCost.aspx.cs" Inherits="Powder_MISProduct.WebUI.UtilityConsumptionCost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Utility Consumption Cost </li>
        </ul>
    </div>

    <div id="divCurrenTabSelected" class="hidden" visible="false">Setting</div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Utility Consumption Cost"></asp:Label></h4>
                    </div>
                    <div class="col-md-3" style="padding-left: 20px;">
                        <div class="input-group">
                            <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                            <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                        </div>
                    </div>
                    <div class="col-md-1 right">
                        <asp:Button runat="server" ID="btnAddNew" Text="Add New" CssClass="btn btn-warning pull-right btn-addnew" OnClick="btnAddNew_Click" data-original-title="Select Project" data-placement="bottom" data-toggle="tooltip" ToolTip="Add New"></asp:Button>
                    </div>
                    <div class="col-md-1 right">
                    </div>
                </div>
            </div>
            <%--<div class="box-body no-padding">--%>
            <div class="panel-body" style="overflow-x: auto">
                <%--<asp:GridView runat="server" ID="gvTankReport" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnRowCommand="gvTankReport_RowCommand">--%>
                <asp:GridView runat="server" ID="gvCosumptionCost" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnRowCommand="gvCosumptionCost_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="SrNo" HeaderText="Sr. No." />
                        <asp:BoundField DataField="CreatedDate" HeaderText="Date & Time" />
                        <asp:BoundField DataField="SteamCost" HeaderText="Steam (per kg)" />
                        <asp:BoundField DataField="ElectricityCost" HeaderText="Electricity (per unit KWH)" />
                        <asp:BoundField DataField="AirCost" HeaderText="Air (Per Cu.mt)" />
                        <asp:BoundField DataField="SoftWaterCost" HeaderText="Soft Water (per KL)" />
                        <asp:BoundField DataField="ChilledWaterCost" HeaderText="Chilled Water (per TR cost)" />
                        <asp:BoundField DataField="ChilledWaterCost" HeaderText="Chilled Water (per TR cost)" />
                        <asp:BoundField DataField="ROWaterCost" HeaderText="RO Water Cost (per KL)" />
                        <asp:BoundField DataField="RawWaterCost" HeaderText="Raw Water Cost (per KL)" />

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' ItemStyle-Width="10%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' ItemStyle-Width="10%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>


    <div class="box box-primary" runat="server" id="divPanel">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="box-title">Utility Consumption Cost </h3>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Steam Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSteam" CssClass="form-control" placeholder="Steam cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSteam" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter steam cost!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Electricity Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtElectricity" CssClass="form-control" placeholder="Electricity Cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtElectricity" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter electricity cost!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Air Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtAir" CssClass="form-control" placeholder="Air cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAir" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter air cost!" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ValidationGroup="g1" ErrorMessage="Please enter SNF!" ControlToValidate="txtSNF"></asp:RangeValidator>--%>
                        </div>
                        <label class="col-md-2">Soft Water Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSoftWater" CssClass="form-control" placeholder="Soft water cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSoftWater" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter soft water cost!" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ValidationGroup="g1" ErrorMessage="Please enter valid value!" ControlToValidate="txtFAT"></asp:RangeValidator>--%>
                        </div>

                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Chilled Water Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtChilledWater" CssClass="form-control" placeholder="Chilled water cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtChilledWater" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter chilled water cost!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">RO Water Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtROWater" CssClass="form-control" placeholder="RO water cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtROWater" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter RO water cost!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Raw Water Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtRawWater" CssClass="form-control" placeholder="Raw water cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRawWater" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter raw water cost!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <br />
                <h5 style="color:darkcyan"><b><u>SCM Utility Cost Fields</u></b></h5>
                <hr />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">SCM Steam Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSCMSteam" CssClass="form-control" placeholder="SCM Steam cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSCMSteam" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter SCM steam cost!" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                        <label class="col-md-2">SCM Electricity Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSCMElectricity" CssClass="form-control" placeholder="SCM Electricity Cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtSCMElectricity" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter SCM electricity cost!" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>

                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">SCM Air Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSCMAir" CssClass="form-control" placeholder="SCM Air cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtSCMAir" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter SCM air cost!" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                        <label class="col-md-2">SCM Soft Water Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSCMSoftWater" CssClass="form-control" placeholder="SCM Soft water cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtSCMSoftWater" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter SCM soft water cost!" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>

                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">SCM Chilled Water Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSCMChilledWater" CssClass="form-control" placeholder="SCM Chilled water cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtSCMChilledWater" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter SCM chilled water cost!" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                        <label class="col-md-2">SCM RO Water Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSCMROWater" CssClass="form-control" placeholder="SCM RO water cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtSCMROWater" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter SCM RO water cost!" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>

                <br />

                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">SCM Raw Water Cost: </label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSCMRawWater" CssClass="form-control" placeholder="SCM Raw water cost" onkeypress="return customValidation(event);" MaxLength="8" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtSCMRawWater" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter SCM raw water cost!" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>

                <br />

                <div class="panel-footer">
                    <div class="row">
                        <div class="col-md-offset-10 col-md-2">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" style="float:right;"/>
                            <%--<asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_Click" CausesValidation="False" />--%>
                            <%--&nbsp;&nbsp;&nbsp;--%>
                        <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">

        //Custom validation for only numeric, decimal and NA/na character.
        function customValidation(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode;
            if (unicode == 8 || unicode == 9 || (unicode >= 48 && unicode <= 57) 
                  || unicode == 46) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>
</asp:Content>
