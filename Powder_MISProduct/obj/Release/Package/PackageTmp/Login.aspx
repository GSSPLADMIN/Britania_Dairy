<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs"  EnableEventValidation="false"  Inherits="Powder_MISProduct.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SCADA MIS</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">

    <!-- Bootstrap core CSS -->
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet">

    <!-- Endless -->
    <link href="css/endless.min.css" rel="stylesheet">
</head>
<body style="background: url(images/2.jpg) no-repeat center center fixed; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover;">
    <form id="form1" runat="server">
        <div>
            <div class="login-wrapper" style="border-color: black; border-width: 2px;">

                <div class="text-center">
                    <h2 class="fadeInUp animation-delay8 content" style="font-weight: bold;">
                        <span class="text-success" style="color: cornflowerblue">DAIRY</span>
                        <br />
                        <span style="color: white; text-shadow: 0 1px #fff">Management Information System</span>
                    </h2>
                </div>
                <div class="login-widget animation-delay1">
                    <div class="panel panel-default" style="border-color: black; border-width: 2px">
                        <div class="panel-heading clearfix" style="height: 100px">
                            <div class="col-md-" style="float: left; padding-top: 8px;">
                                <img src="images/Britania.png" style="height: 75px; width: 75px;" />
                            </div>
                            <div align="center" class="col-md-7">
                                <span style="font-weight: bold">
                                    <h3>LOGIN</h3>
                                </span>
                            </div>
                            <div class="col-md-" style="float: right;">
                                <img src="images/GEA_logo.png" style="height: 55px; width: 75px; padding-top: 19px;" />
                            </div>
                        </div>
                        <div class="panel-body">
                            <form class="form-login">
                                <div class="form-group">
                                    <label>Username</label>
                                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Enter User Name" />
                                </div>
                                <div class="form-group">
                                    <label>Password</label>
                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password" />
                                </div>
                                <%-- <div class="form-group">
                                    <label class="label-checkbox inline">
                                        <input type="checkbox" class="regular-checkbox chk-delete" />
                                        <span class="custom-checkbox info bounceIn animation-delay4"></span>
                                    </label>
                                    Remember me		
                               
                                </div>--%>
                                <div class="linkRow">
                                    <asp:Label ID="lblMsg" runat="server" Class="" Visible="false" Text="" ForeColor="Red"></asp:Label>
                                </div>
                                <hr />
                                <div style="margin-top: 10px;">
                                 <%--   Powered By :  <a href="http://www.banyantreesoft.com" target="_blank">
                                        <img src="../images/banyantreelogo.gif" /></a>--%>
                                    <asp:Button ID="btnLogin" Height="40px" Width="75px" OnClick="btnLogin_OnClick" CssClass="btn btn-success btn-sm bounceIn animation-delay5 pull-right fa fa-sign-in" runat="server" Text="Sign In" />
                                </div>
                            </form>
                        </div>
                    </div>
                    <!-- /panel -->
                </div>
                <!-- /login-widget -->
            </div>
            <!-- /login-wrapper -->

            <!-- Le javascript
            ================================================== -->
            <!-- Placed at the end of the document so the pages load faster -->

            <!-- Jquery -->
            <script src="js/jquery-1.10.2.min.js"></script>

            <!-- Bootstrap -->
            <script src="bootstrap/js/bootstrap.min.js"></script>

            <!-- Modernizr -->
            <script src='js/modernizr.min.js'></script>

            <!-- Pace -->
            <script src='js/pace.min.js'></script>

            <!-- Popup Overlay -->
            <script src='js/jquery.popupoverlay.min.js'></script>

            <!-- Slimscroll -->
            <script src='js/jquery.slimscroll.min.js'></script>

            <!-- Cookie -->
            <script src='js/jquery.cookie.min.js'></script>

            <!-- Endless -->
            <script src="js/endless/endless.js"></script>

        </div>
    </form>
</body>
</html>
