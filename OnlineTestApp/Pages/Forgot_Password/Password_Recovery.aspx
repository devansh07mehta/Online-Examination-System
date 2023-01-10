<%@ Page Title="Password Recovery Page" Language="C#" MasterPageFile="~/Pages/Master_Page/MasterPage.Master" AutoEventWireup="true" CodeBehind="Password_Recovery.aspx.cs" Inherits="OnlineTestApp.Pages.Forgot_Password.Password_Recovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../../Css/home.css" rel="stylesheet" />
    <section class="vh-100 loginWrapper mt-0 d-flex align-items-center justify-content-center">
        <div class="container-fluid">
            <div class="row mx-auto card shadow-sm maxW400" style="max-width: 500px; width: 100%;">
                <div class="col-md-12 text-center mt-3">
                    <div class="form-group">
                        <h1>Password Recovery</h1>
                        <br />
                    </div>
                </div>
                <div class="col-md-10 mx-auto">
                    <div class="form-group">
                        <asp:Label runat="server" ID="lblemail" AssociatedControlID="txtemailadd"><b>Email Address</b></asp:Label>
                        <asp:TextBox runat="server" required="required" Enabled="True" name="BrandName" ID="txtemailadd" class="form-control" placeholder="Enter Email Address" TextMode="Email" pattern="^[a-z][-_.a-z0-9]{5,29}@gmail\.com$" title="Email address must be of this format: abc123@gmail.com or abc_123@gmail.com or abc.123@gmail.com or abc-123@gmail.com or abcabc@gmail.com"></asp:TextBox>
                        <br />
                        <div class="mx-align-self-auto text-center">

                            <asp:Button ID="Button1" Text="Send OTP" runat="server" Class="btn btn-primary" OnClick="Btncode_Click" />
                        </div>
                    </div>
                </div>

                <div class="col-md-10 mx-auto mt-3 mb-5">
                    <div class="form-group position-relative">
                        <asp:Label runat="server" ID="lblotp" AssociatedControlID="txtotp"><b>OTP</b></asp:Label>
                        <asp:TextBox ID="txtotp" runat="server" Enabled="True" name="BrandName" class="form-control" placeholder="Enter Valid OTP" type="password" pattern="^[0-9]{6}$" title="OTP must be of 6 digits!!"></asp:TextBox><br />

                        <span class="eyeIcons right10 position-absolute d-flex" style="top: 35px;" onclick="password_show_hide();">
                            <i class="fas fa-eye" id="show_eye"></i>
                            <i class="fas fa-eye-slash d-none" id="hide_eye"></i>
                        </span>
                        <div class="mx-align-self-auto text-center">
                            <asp:Button ID="Btnotp" Text="Verify OTP" runat="server" Class="btn btn-primary" OnClick="Btnotp_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
    <script type="text/javascript">
        function password_show_hide() {
            var x = document.getElementById("MainContent_txtotp");
            var show_eye = document.getElementById("show_eye");
            var hide_eye = document.getElementById("hide_eye");
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
