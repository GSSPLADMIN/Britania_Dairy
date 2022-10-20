<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="WeighAnalysis.aspx.cs" Inherits="Powder_MISProduct.WebUI.WeighAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">WheyAnalysis </li>
        </ul>
    </div>
    <div id="divCurrenTabSelected" class="hidden" visible="false">Setting</div>
    <div class="col-md-12">
        <div id="divGrid" runat="server" class="panel panel-default">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-md-8">
                        <h4>
                            <asp:Label ID="lblHeading" runat="server" Text="Whey Analysis"></asp:Label></h4>
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
            <div class="panel-body" style="overflow:auto" >
                <%--<asp:GridView runat="server" ID="gvWheyAnalysis" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvWheyAnalysis_PreRender" OnRowCommand="gvWheyAnalysis_RowCommand">--%>
                <asp:GridView runat="server" ID="gvWheyAnalysis" CssClass="table table-hover table-striped scrollable" style="text-align:center" AutoGenerateColumns="False" GridLines="BOTH">
                    <Columns>
                        <asp:BoundField DataField="SrNo" HeaderText="Sr. No." HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="DateTime" HeaderText="Date & Time"  HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="SampleDateTime" HeaderText="Sample Date & Time" HeaderStyle-CssClass="text-center"/>
                        <asp:BoundField DataField="SampleName" HeaderText="Sample ID"  HeaderStyle-CssClass="text-center"/>
                        <asp:BoundField DataField="SampleNo" HeaderText="Sample No"  HeaderStyle-CssClass="text-center"/>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name"  HeaderStyle-CssClass="text-center"/>
                        <asp:BoundField DataField="OT" HeaderText="pH"  HeaderStyle-CssClass="text-center"/>
                        <asp:BoundField DataField="Temp" HeaderText="Temp. (°C)" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="Fat" HeaderText="Fat %" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="SNF" HeaderText="SNF %"  HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="Acidity" HeaderText="Acidity" HeaderStyle-CssClass="text-center" />
                        <%--<asp:BoundField DataField="COB" HeaderText="COB" ItemStyle-Width="70%"  HeaderStyle-CssClass="text-center" />--%>
                       <%-- <asp:BoundField DataField="AlcholTest65" HeaderText="AlcholTest65" ItemStyle-Width="70%"  HeaderStyle-CssClass="text-center" />--%>
                        <%--<asp:BoundField DataField="AlcholTest" HeaderText="AlcholTest" ItemStyle-Width="70%"  HeaderStyle-CssClass="text-center" />--%>
                       <%-- <asp:BoundField DataField="Blactumantibiotictest" HeaderText="Blactumantibiotictest" ItemStyle-Width="70%"  HeaderStyle-CssClass="text-center" />--%>
                       <%-- <asp:BoundField DataField="MineralOilTest" HeaderText="MineralOilTest" ItemStyle-Width="70%"  HeaderStyle-CssClass="text-center" />--%>
                        <asp:BoundField DataField="AnyOtherTest01" HeaderText="AnyOther Test 01" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="AnyOtherTest02" HeaderText="AnyOther Test 02" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="AnyOtherTest03" HeaderText="AnyOther Test 03" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="AnyOtherTest04" HeaderText="AnyOther Test 04" HeaderStyle-CssClass="text-center" />
                        <%--<asp:BoundField HeaderText="Neutrilize" DataField="Neutrilize" ItemStyle-Width="70%"  HeaderStyle-CssClass="text-center" />--%>
                         <asp:BoundField HeaderText="Urea" DataField="Urea" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField HeaderText="Salt" DataField="Salt" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField HeaderText="Startch" DataField="Startch" HeaderStyle-CssClass="text-center" />
                         <asp:BoundField HeaderText="FPD" DataField="FPD" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField HeaderText="Status" DataField="Status" HeaderStyle-CssClass="text-center" />
                         <asp:BoundField HeaderText="Remarks" DataField="Remarks" HeaderStyle-CssClass="text-center" />

                        <%--<asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEdit" CommandName="Edit1" CommandArgument='<%# Eval("Id") %>' ItemStyle-Width="10%" ImageUrl="../images/Edit.png"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDelete" CommandName="Delete1" CommandArgument='<%# Eval("Id") %>' ItemStyle-Width="10%" ImageUrl="../images/Delete.png" OnClientClick="javascript:return confirm('Do you really want to Delete this record?');"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView> 
                 <br />
                 <br />
                 <br />
            </div>
        </div>
        <%--<div class="box box-primary" runat="server" id="divPanel">--%>
        <div class="panel panel-default" runat="server" id="divPanel">
            <%--<div class="box-header">--%>
            <div class="panel-heading">
                <h3 class="box-title">Whey Analysis</h3>
            </div>
            <%--<div class="box-body">--%>
            <div class="panel-body">
                <%--<div class="row" style="margin-bottom: 20px;">--%>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Date & Time In :</label>
                        <div class="col-md-2">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtDate" CssClass="form-control date" placeholder="Date" Enabled="false"/>
                            </div>
                            </div>
                            <div class="col-md-2">   

                            <div class="bootstrap-timepicker">
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txttime" ClientIDMode="Static" CssClass="form-control timepicker" placeholder="Time" Enabled="false"/>
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                </div>
                            </div>

                        </div>

                    <%--</div>--%>
                    <%--Farheen: Added Sample Date and Time field --%>
                    <%--<div class="form-group">--%>
                        <label class="col-md-2">Sample Date & Time:</label>
                        <div class="col-md-2">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtSampleDate" CssClass="form-control date" placeholder="Date" />
                            </div>
                            </div>
                            <div class="col-md-2">
                            <div class="bootstrap-timepicker">
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtSampleTime" ClientIDMode="Static" CssClass="form-control timepicker" placeholder="Time" />
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                </div>
                            </div>
                        </div>

                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Sample ID :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtsamplename" CssClass="form-control" placeholder="Sample ID" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsamplename" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Sample ID" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>

                   <%-- </div>
                    <div class="form-group">--%>
                        <label class="col-md-2">Sample No/ Description :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSampleNo" CssClass="form-control" placeholder="Sample No" />

                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Product Name :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" placeholder="ProductName" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtProductName" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Product Name" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    <%--</div>
                    <div class="form-group has-error">--%>

                        <label class="col-md-2">pH :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtOT" CssClass="form-control" placeholder="pH" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOT" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter  pH" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Temp :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtTemp" CssClass="form-control" placeholder="Temp" />
                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtTemp" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter  Temp" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                    <%--</div>


                    <div class="form-group has-error">--%>

                        <label class="col-md-2">Fat% :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtFat" CssClass="form-control" placeholder="Fat" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFat" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Fat" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">SNF% :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtSNF" CssClass="form-control" placeholder="SNF" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSNF" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter  SNF" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    <%--</div>


                    <div class="form-group has-error">--%>

                        <label class="col-md-2">Acidity :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtAcidity" CssClass="form-control" placeholder="Acidity" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAcidity" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Acidity" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <%--<div class="row">
                    <div class="form-group">
                        <label class="col-md-2">COB :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlCOB" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rf2" runat="server" ControlToValidate="ddlCOB" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select COB" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>

                        <label class="col-md-2">Alchol Test(65%) :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlAlcholtest" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlAlcholtest" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Alcholtest" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                <div class="form-group">
                    <label class="col-md-2">Alchol Test :</label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="ddlAlcholtests" CssClass="form-control">
                            <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                            <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                            <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlAlcholtests" ValidationGroup="g1"
                            SetFocusOnError="True" ErrorMessage="Select Alcholtests" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                    </div>
              
                        <label class="col-md-2">BLactum Antibiotictest :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlAntibiotictest" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlAntibiotictest" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Alcholtest" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />--%>
                <div class="row">
                    <div class="form-group">
                        <%--<label class="col-md-2">Mineraloil Test :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlMineraloiltest" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlMineraloiltest" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Mineraloiltest" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>--%>

                        <label class="col-md-2">AnyOtherTest-01 :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlAnyothertest1" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAnyothertest1" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select AnyOtherTest-01" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">AnyOtherTest-02 :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlAnyothertest2" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlAnyothertest2" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select AnyOtherTest-02" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">AnyOtherTest-03 :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlAnyothertest3" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlAnyothertest3" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select ddlAnyothertest3" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">AnyOtherTest-04 :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlAnyothertest4" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlAnyothertest4" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select ddlAnyothertest4" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <%--<div class="row">
                    <div class="form-group">
                    <label class="col-md-2">Neutrilize :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlNeutrilize" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlNeutrilize" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select ddlNeutrilize" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />--%>
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Urea:</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlUrea" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlUrea" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select ddlUrea" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                   
                        <label class="col-md-2">Salt :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlsalt" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlsalt" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select salt" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Starch:</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlstarch" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlstarch" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select starch" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                   <%-- </div>


                    <div class="form-group has-error">--%>

                        <label class="col-md-2">FPD :</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlfpd" CssClass="form-control">
                                <asp:ListItem Text="-ve" Value="1"></asp:ListItem>
                                <asp:ListItem Text="+ve" Value="2"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="3"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlfpd" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select FPD" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2">Status:</label>
                        <div class="col-md-4">
                            <asp:DropDownList runat="server" ID="ddlstatus" CssClass="form-control">
                                <asp:ListItem Text="Accepted" Value="1"></asp:ListItem>
                                <asp:ListItem Text="NotAccepted" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlstatus" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Select Status" ForeColor="Red" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </div>
                   
                        <label class="col-md-2">Remarks :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" placeholder="Remarks" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtRemarks" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Remarks" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--<div class="form-group has-error">
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" />
                        <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_Click" />
                    </div>--%>
                </div>
            </div>

            <div class="panel-footer">
                <div class="row">
                    <div class="col-md-offset-10 col-md-2">
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" />
                        <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="g1" ShowMessageBox="True" ShowSummary="False" />
                    </div>
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        var date = new Date();
        var end = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        $(function () {
            $('#id_search').quicksearch('table#<%=gvWheyAnalysis.ClientID%> tbody tr');
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
