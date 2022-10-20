<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Powder_MISProduct.WebUI.Inventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Inventory </li>
        </ul>
    </div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Inventory"></asp:Label></h4>
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
            <div class="box-body no-padding">
                <asp:GridView runat="server" ID="gvInventory" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvInventory_PreRender" OnRowCommand="gvInventory_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="Itemdesc" DataField="Itemdesc" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="MakeType" DataField="MakeType" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="BatchNumber" DataField="BatchNumber" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" ItemStyle-Width="70%" />
                        <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-Width="70%" />
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
        </div>

        <div class="box box-primary" runat="server" id="divPanel">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="box-title">Add Inventory</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <label class="col-md-2">Date :</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtDate" CssClass="form-control date" placeholder="Date" />
                            </div>
                        </div>
                        <label class="col-md-2">Item Description :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtitemdescription" CssClass="form-control" placeholder="Item Description" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtitemdescription" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter ItemDescription" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <label class="col-md-2">Part/BatchNo :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtPartNo" CssClass="form-control" placeholder="PartNo" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPartNo" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter PartNo" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Quantity :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" placeholder="Quantity" onkeypress="return customValidation(event);"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtQuantity" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Quantity!" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">MakeType :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtMaketype" CssClass="form-control" placeholder="Make Type" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMaketype" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Maketype" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Remarks :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" placeholder="Remarks." />
                        </div>
                    </div>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvInventory.ClientID%> tbody tr');
        });
        $('.date').datepicker({
            format: "dd/mm/yyyy",
            clearBtn: true,
            autoclose: true,
            todayHighlight: true
        });
        function customValidation(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode;
            if (unicode == 8 || unicode == 9 || (unicode >= 48 && unicode <= 57) || unicode == 97 || unicode == 110
                || unicode == 65 || unicode == 78 || unicode == 46) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
