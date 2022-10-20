<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainMaster.Master" AutoEventWireup="true" CodeBehind="Lab.aspx.cs" Inherits="Powder_MISProduct.WebUI.Lab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="breadcrumb">
        <ul class="breadcrumb">
            <li><i class="fa fa-home"></i><a href="../WebUI/DashBoard.aspx">Home</a></li>
            <li class="active">Lab </li>
        </ul>
    </div>
    <div id="divCurrenTabSelected" class="hidden" visible="false">master</div>
    <div class="col-md-12">

        <div class="col-md-12">
            <div id="divGrid" runat="server" class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-md-8">
                            <h4>
                                <asp:Label ID="lblHeading" runat="server" Text="Lab"></asp:Label></h4>
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
                    <asp:GridView runat="server" ID="gvLab" CssClass="table table-hover table-striped" AutoGenerateColumns="False" GridLines="None" OnPreRender="gvLab_PreRender" OnRowCommand="gvLab_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Date" DataField="Date" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="TypeofPowder" DataField="TypeofPowder" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Time" DataField="Time" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="SampleId" DataField="SampleId" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="BatchNo" DataField="BatchNo" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="BagNo" DataField="BagNo" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Weight" DataField="Weight" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="TempOC" DataField="TempOC" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Fat" DataField="Fat" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="SNF" DataField="SNF" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Acidity" DataField="Acidity" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Moisture" DataField="Moisture" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="Sugar" DataField="Sugar" ItemStyle-Width="10%" />
                            <asp:BoundField HeaderText="SolIndex" DataField="SolIndex" ItemStyle-Width="10%" />
                            <%--     <asp:BoundField HeaderText="Coffetest" DataField="Coffetest" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Particleontop" DataField="Particleontop" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="ParticleonBottom" DataField="ParticleonBottom" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Sendiments" DataField="Sendiments" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="BulkDensity" DataField="BulkDensity" ItemStyle-Width="10%" />
                         <asp:BoundField HeaderText="Scorchedparticle" DataField="Scorchedparticle" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Wettability" DataField="Wettability" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Dispersibility" DataField="Dispersibility" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="FreeFat" DataField="FreeFat" ItemStyle-Width="10%" />
                         <asp:BoundField HeaderText="TotalPlatecount" DataField="TotalPlatecount" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Coliform" DataField="Coliform" ItemStyle-Width="10%" />
                         <asp:BoundField HeaderText="YestMould" DataField="YestMould" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Ecoli" DataField="Ecoli" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Salmonella" DataField="Salmonella" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Saureus" DataField="Saureus" ItemStyle-Width="10%" />
                        <asp:BoundField HeaderText="Anerobicsporecount" DataField="Anerobicsporecount" ItemStyle-Width="10%" />
                         <asp:BoundField HeaderText="Listeriamonocytogen" DataField="Listeriamonocytogen" ItemStyle-Width="10%" />
                              <asp:BoundField HeaderText="Username" DataField="Username" ItemStyle-Width="10%" />
                         <asp:BoundField HeaderText="Remarks" DataField="Remarks" ItemStyle-Width="10%" />--%>

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
        </div>

        <div class="box box-primary" runat="server" id="divPanel">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="box-title">Add Lab</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <label class="col-md-2">Date: </label>
                        <div class="col-md-4">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                                <asp:TextBox runat="server" ID="txtDate" CssClass="form-control date" placeholder="Date" />
                            </div>
                        </div>

                        <label class="col-md-2">SamleId :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtsampleId" CssClass="form-control" placeholder="SampleName" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <label class="col-md-2">BatchNo :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtBatchNo" CssClass="form-control" placeholder="BatchNo" />
                        </div>
                        <label class="col-md-2">BagNo :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtBagNo" CssClass="form-control" placeholder="BagNo" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <label class="col-md-2">Time :</label>
                        <div class="col-md-4">
                            <div class="bootstrap-timepicker">
                                <div class="input-group">

                                    <asp:TextBox runat="server" ID="txttime" ClientIDMode="Static" CssClass="form-control timepicker" placeholder="Time" />
                                    <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                </div>
                            </div>
                        </div>
                        <label class="col-md-2">TypeOfPowder :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtPowder" CssClass="form-control" placeholder="TypeOfPowder" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <label class="col-md-2">Weight :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtWeight" CssClass="form-control" placeholder="Weight" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWeight" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter  Weight" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Temp :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtTemp" CssClass="form-control" placeholder="Temp" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Fat% :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtFat" CssClass="form-control" placeholder="Fat" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFat" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Fat" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">SNF% :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSNF" CssClass="form-control" placeholder="SNF" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Acidity% :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtAcidity" CssClass="form-control" placeholder="Acidity" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAcidity" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Acidity" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Moisture% :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtMoisture" CssClass="form-control" placeholder="Moisture" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Sugar :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSugar" CssClass="form-control" placeholder="Sugar" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSugar" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Sugar" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">SolIndex(MI) :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtSolIndex" CssClass="form-control" placeholder="SolIndex" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">CoffeeTest :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtCoffeetest" CssClass="form-control" placeholder="CoffeeTest" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCoffeetest" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter CoffeeTest" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Particleontop :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtParticleontop" CssClass="form-control" placeholder="Particleontop" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Particleonbottom :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtParticleonbottom" CssClass="form-control" placeholder="Particleonbottom" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtParticleonbottom" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Particleonbottom" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Sediments :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtsediments" CssClass="form-control" placeholder="Sediments" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">BulkDensity :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtbulkdensity" CssClass="form-control" placeholder="BulkDensity" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtbulkdensity" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter BulkDensity" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">ScorchedParticle :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtScorchedParticle" CssClass="form-control" placeholder="ScorchedParticle" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Wettability :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtwettability" CssClass="form-control" placeholder="Wettability" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtwettability" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Wettability" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Dispersilbility :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtDispersilbility" CssClass="form-control" placeholder="Dispersilbility" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">FreeFat(without lecithination) :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtfreefat" CssClass="form-control" placeholder="FreeFat" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtfreefat" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter txtfreefat" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Total Plate Count/g :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txttotalplatecount" CssClass="form-control" placeholder="TotalPlateCount" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Coliform/0.1 g:</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtColiform" CssClass="form-control" placeholder="Coliform" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtColiform" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter txtColiform" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Yeast & Mould count :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtyeastmouldcount" CssClass="form-control" placeholder="Yeast & Mould count" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">E.coli/ 0.1 gMax:</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtEcoli" CssClass="form-control" placeholder="Ecoli" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtEcoli" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter txtEcoli" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Salmonella & Shigella/25g :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtSalmonella" CssClass="form-control" placeholder="Salmonella & Shigella" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Saureus/:</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtSaureus" CssClass="form-control" placeholder="Saureus" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtSaureus" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter txtSaureus" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">Anaerobic sporecount/g :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtAnaerobicsporecount" CssClass="form-control" placeholder="Anaerobic sporecount" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Listeriamonocytogens/g:</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtListeriamonocytogens" CssClass="form-control" placeholder="Listeriamonocytogens" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtListeriamonocytogens" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter txtListeriamonocytogens" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-2">UserName :</label>
                        <div class="col-md-4">
                            <%--                            <div class="input-group">--%>
                            <%--                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>--%>
                            <asp:TextBox runat="server" ID="txtusername" CssClass="form-control" placeholder="UserName" />
                        </div>
                    </div>

                    <div class="row">
                        <label class="col-md-2">Remarks :</label>
                        <div class="col-md-4">
                            <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" placeholder="Remarks" />
                           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtRemarks" ValidationGroup="g1"
                                SetFocusOnError="True" ErrorMessage="Enter Remarks" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-4">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="g1" OnClick="btnSave_Click" />
                            <asp:Button runat="server" ID="btnViewList" Text="Viewlist" CssClass="btn btn-primary" OnClick="btnViewList_Click" />
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
        var date = new Date();
        var end = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
        $(function () {
<%--            $('#id_search').quicksearch('table#<%=gvMaintenance.ClientID%> tbody tr');--%>
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
