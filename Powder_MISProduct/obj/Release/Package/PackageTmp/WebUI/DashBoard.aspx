<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="Powder_MISProduct.WebUI.DashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div id="breadcrumb">
    </div>
    <div class="padding-md">
        <div class="row col-md-12">
            <div class="panel panel-default">
                <div id="divGrid" runat="server" class="panel panel-default">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-8">
                                <h4>
                                    <asp:Label ID="lblHeading" runat="server" Text="DashBoard"></asp:Label></h4>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div id="div1" runat="server" class="box box-primary">
                           
                            <%--<ul class="nav nav-tabs">
                                <li class="active"><a data-toggle="tab" href="#divWeb">In Process Routine Maintainance</a></li>
                                <li><a data-toggle="tab" href="#divWindows">Non Completed Routine Maintainance</a></li>
                            </ul>--%>
                            <div class="tab-content">
                                <div id="divWeb" class="table-responsive no-padding tab-pane fade in active">
                                    <asp:GridView runat="server" ID="gvMaintainanceFive" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None">
                                        <Columns>
                                            <asp:BoundField HeaderText="Equipment Tag No" DataField="EquipmentTagNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="Equipment Name" DataField="EquipmentName" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="Maintainance Date" DataField="MaintainanceDate" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="Start Time" DataField="StartTime" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="End Time" DataField="EndTime" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="Status" DataField="Status" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                        </Columns>
                                    </asp:GridView>
                                    <div class="col-md-12" style="padding-top: 20px;">
                                        
                                    </div>
                                </div>
                                <div id="divWindows" class="table-responsive no-padding tab-pane fade">
                                    <asp:GridView runat="server" ID="gvMaintainance" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None">
                                        <Columns>
                                            <asp:BoundField HeaderText="Equipment Tag No" DataField="EquipmentTagNo" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="Equipment Name" DataField="EquipmentName" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="Maintainance Date" DataField="MaintainanceDate" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="Start Time" DataField="StartTime" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="End Time" DataField="EndTime" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                            <asp:BoundField HeaderText="Status" DataField="Status" ItemStyle-Width="10%" HeaderStyle-Width="10%" />
                                        </Columns>
                                    </asp:GridView>
                                    
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
</asp:Content>
