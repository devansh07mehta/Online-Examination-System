<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_Page/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reset_Password.aspx.cs" Inherits="OnlineTestApp.Pages.Reset_Password.Reset_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  

    <link href="../../Css/home.css" rel="stylesheet" type="text/css" />
    
   
    
    <section class="resetPasswordWrapper vh-100 loginWrapper mt-0 pt-5 d-sm-flex align-items-center justify-content-center">
        
            <div class="container bg-white bg-light bg-gradient shadow-sm border p-3 rounded resetPassword">
                <div class="row py-3">
                    <div class="col-md-12 text-center mx-auto"><h1 runat="server">Reset Password</h1></div>
                </div>
                <div class="row">
                    <div class="col-md-10 mx-auto mb-3">
                        <div class="form-group position-relative">
                            <label for="pwd" runat="server"><b>New Password</b></label>
                            <input type="password" runat="server" name="pwd" id="txtpwd" class="form-control input-sm" placeholder="Enter New Password" pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*^()~`?&])[A-Za-z\d@$!%*^()~`?&]{8,15}$" title="Password must contains minimum eight characters, maximum 15 characters, at least one uppercase letter, one lowercase letter, one special character and one number!" required="required" />
                            <span class="eyeIcons right10 bottom10 position-absolute" runat="server" onclick="password_show_hide();">
                                <i class="fas fa-eye" id="show_eye"></i>
                                <i class="fas fa-eye-slash d-none" id="hide_eye"></i>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10 mx-auto">
                        <div class="form-group position-relative">
                            <label for="conpwd" runat="server"><b>Confirm Password</b></label>
                            <input type="password" runat="server" name="conpsw" id="txtconpwd" class="form-control input-sm" placeholder="Confirm Password" required="required" />
                            <span class="eyeIcons right10 bottom10 position-absolute" runat="server" onclick="password_show_hide1();">
                                <i class="fas fa-eye" id="show_eye1"></i>
                                <i class="fas fa-eye-slash d-none" id="hide_eye1"></i>
                            </span>
                        </div>
                    </div>
                </div>
                <div class="row py-3">
                    <div class="col-md-12 text-center">
                        <div class="form-group">
                            <asp:Button ID="Btnreset" CssClass="btn btn-primary my-2" runat="server" Text="Reset" style="width:200px" OnClick="Btnreset_Click" /><br />
                            
                        </div>
                    </div>
                </div>
            </div>
       
    </section>
<script type="text/javascript">
    function password_show_hide() {
        var x1 = document.getElementById("MainContent_txtpwd");
        var show_eye = document.getElementById("show_eye");
        var hide_eye = document.getElementById("hide_eye");
        hide_eye.classList.remove("d-none");
        if (x1.type == "password") {
            x1.type = "text";
            show_eye.style.display = "none";
            hide_eye.style.display = "block";
        }
        else {
            x1.type = "password";
            show_eye.style.display = "block";
            hide_eye.style.display = "none";
        }
    }
    function password_show_hide1() {

        var x = document.getElementById("MainContent_txtconpwd");
        var show_eye = document.getElementById("show_eye1");
        var hide_eye = document.getElementById("hide_eye1");
        hide_eye.classList.remove("d-none");
        if (x.type == "password") {
            x.type = "text";
            show_eye.style.display = "none";
            hide_eye.style.display = "block";
        }
        else {
            x.type = "password";
            show_eye.style.display = "block";
            hide_eye.style.display = "none";
        }
    }

    function preventBack() { window.history.forward(); }
    setTimeout("preventBack()", 0);
    window.onunload = function () { null };
</script>
</asp:Content>
