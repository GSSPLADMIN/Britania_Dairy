<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Powder_MISProduct.WebUI.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Employee </li>
        </ul>
    </div>
    <div id="divCurrenTabSelected" class="hidden" visible="false">master</div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="box box-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Employee"></asp:Label></h4>
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
                <asp:GridView runat="server" ID="gvEmployee" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvEmployee_PreRender" OnRowCommand="gvEmployee_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Employee Name" DataField="Name" ItemStyle-Width="70%" />
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
            <div class="box-header">
                <h3 class="box-title">Employee</h3>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Name</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Name" />
                            <asp:RequiredFieldValidator runat="server" ID="rf1" ControlToValidate="txtName"
                                ErrorMessage="Enter Name" SetFocusOnError="True" ValidationGroup="g1"
                                ForeColor="red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <label class="col-md-2">Code :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" placeholder="Employee Code" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Employee Code" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="form-group has-error">
                        <%--<label class="col-md-2">Organisation :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlOrganisation" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlOrganisation" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Organisation" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>--%>
                        <label class="col-md-2">Role :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rf2" runat="server" ControlToValidate="ddlRole" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Role" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <%-- <div class="row">
                    <div >
                        <label class="col-md-2">Department :</label>
                        <div class="col-md-4 form-group has-error">
                            <asp:DropDownList runat="server" ID="ddlDepartment" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDepartment" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Department" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">ReportingTo :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlReportingTo" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </div>--%>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Email :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email Id" />
                            <asp:RegularExpressionValidator ID="re1" runat="server" ControlToValidate="txtEmail" ValidationGroup="g1" ErrorMessage="Enter Valid Email Id"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red">*</asp:RegularExpressionValidator>
                        </div>
                        <label class="col-md-2">Mobile No :</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>
                                <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" placeholder="Mobile No." />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 20px;">
                    <div class="form-group">
                        <label class="col-md-2">Contact No. :</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>
                                <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" placeholder="Contact No." />
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row" style="padding-bottom: 20px;">
                    <div class="form-group">
                        <label class="col-md-2">Address :</label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" placeholder="Address" />
                        </div>
                    </div>
                </div>
                <div class="row" style="padding-bottom: 20px;">
                    <div class="form-group">
                        <%--  <label class="col-md-2 label-checkbox">Is User :</label>
                        <div class="col-md-4 custom-checkbox">
                            <input runat="server" ID="chkIsuser" type="checkbox" CssClass="custom-checkbox" />
                              <span class="custom-checkbox">  </span>
                        </div>--%>
                        <div id="divUserName" runat="server">
                            <label class="col-md-2">User Name :</label>
                            <div class="col-md-4 has-error">
                                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="User Name" autocomplete="off" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="divPassword" runat="server">
                    <div class="form-group has-error">
                        <label class="col-md-2">Password :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" placeholder="Password" AutoCompleteType="None" />
                            <asp:RequiredFieldValidator ID="rfPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Password" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Re-Enter Password :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtRePassword" CssClass="form-control" TextMode="Password" placeholder="Re-Enter Password" />
                            <asp:RequiredFieldValidator ID="rfRePassword" runat="server" ControlToValidate="txtRePassword" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Re-Enter Password" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvRePassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtRePassword"
                                ValidationGroup="g1" SetFocusOnError="True" ErrorMessage="Password Does not match" ForeColor="Red"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 20px;">
                    <div class="form-group">
                        <label class="col-md-2">Joining Date :</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtJoinDate" CssClass="form-control date" placeholder="Joining Date" />
                            </div>
                        </div>
                        <label class="col-md-2">Birth Date :</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtBirthDate" CssClass="form-control date" placeholder="Birth Date." />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 20px;">
                    <div class="form-group">
                        <label class="col-md-2">Marriage Date :</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtMarriageDate" CssClass="form-control date" placeholder="Marriage Date." />
                            </div>
                        </div>
                    </div>
                </div>
                <%-- <div class="row" id="divIsResign" runat="server" style="margin-bottom: 20px;">
                    <div class="form-group">
                        <label class="col-md-2 label-checkbox">Is Resigned :</label>
                        <div class="col-md-4 checkbox">
                            <asp:CheckBox runat="server" ID="chkIsResigned" type="checkbox" CssClass="custom-checkbox" />
                        </div>
                    </div>
                </div>--%>
                <div class="row" id="divIsResignDate" style="margin-bottom: 20px;" runat="server">
                    <div class="form-group">
                        <label class="col-md-2">Resignation Date. :</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtResignDate" CssClass="form-control date" placeholder="Resignation Date" />
                            </div>
                        </div>
                        <label class="col-md-2">Last Working Date. :</label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtLastWorkingDate" CssClass="form-control date" placeholder="Last Working Date" />
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" />
                            <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_Click" />

                            <asp:RequiredFieldValidator ID="rfUserName" runat="server" ControlToValidate="txtUserName" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter User Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:HiddenField ID="hfIsUser" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hfIsResigned" runat="server" ClientIDMode="Static" />
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
            $('#id_search').quicksearch('table#<%=gvEmployee.ClientID%> tbody tr');
        });
        $('.date').datepicker({
            format: "dd/mm/yyyy",
            clearBtn: true,
            autoclose: true,
            todayHighlight: true
        });

    </script>
</asp:Content>
