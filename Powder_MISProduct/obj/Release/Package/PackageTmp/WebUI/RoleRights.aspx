<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="RoleRights.aspx.cs" Inherits="Powder_MISProduct.WebUI.RoleRights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Role Rights </li>
        </ul>
    </div>
    <div id="divCurrenTabSelected" class="hidden" visible="false">Setting</div>
    <div class="col-md-12">
        <div class="box box-info">
            <div class="box-body center-block">
                <div class="row">
                    <div class="col-md-12" style="padding-top: 20px;">
                        <label class="col-md-2">Role :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlRole" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_OnSelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlRole" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Role." ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                         <%--<div runat="server" class="col-md-12">--%>
                        <div class="col-md-2">
                            <asp:Button runat="server" ID="btnSaveWeb" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_OnClick" />
                            <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                        <%--</div>--%>
                    </div>

                    </div>
                </div>
            </div>
        </div>
        <div id="divGrid" runat="server" class="box box-primary">
            <div class="col-md-6" style="padding-left: 200px;">
                <div class="input-group">
                    <span id='search-icon' class="input-group-addon"><span class='glyphicon glyphicon-search'></span></span>
                    <input id="id_search" type="text" class="form-control" placeholder="Type here" onkeydown=" return (event.keyCode !== 13); " />
                </div>
            </div>
            <%--  <ul class="nav nav-tabs" style="padding-top: 40px;">
                <li class="active"><a data-toggle="tab" href="#divWeb">Screens</a></li>
            </ul>--%>
            <div class="tab-content" style="padding-top: 50px;">
                <div id="divWeb" class="table-responsive no-padding tab-pane fade in active">
                    <asp:GridView runat="server" ID="gvRoleRightsWeb" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" GridLines="Both" ClientIDMode="Static" OnPreRender="gvSupplierList_OnPreRender">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Screen Id">
                                <HeaderStyle CssClass="hidden " HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle CssClass="hidden " HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelectWeb" runat="server" />
                                    <span class="custom-checkbox"></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Screen Name" DataField="DisplayName" ItemStyle-Width="90%" />
                        </Columns>
                    </asp:GridView>
                   <%-- <div class="col-md-12" style="padding-top: 20px;">
                        <div class="col-md-2">
                            <asp:Button runat="server" ID="btnSaveWeb" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_OnClick" />
                            <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                        </div>
                    </div>--%>
                </div>
            </div>
            
        </div>
                   
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <script type="text/javascript">
        $(function () {
            $('#id_search').quicksearch('table#<%=gvRoleRightsWeb.ClientID%> tbody tr');
        });
    </script>
</asp:Content>
