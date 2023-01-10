<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineTestApp.Login" %>

<!------ Include the above in your HEAD tag ---------->

<!DOCTYPE html>
<html>
<head>

    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <!--External CSS-->
    <link href="../../../Css/home.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <title>Login Page</title>


</head>
<body>
    <!-- /***********Login page starts here*************/ -->
    <section class="vh-100 loginWrapper mt-0 d-flex align-items-center justify-content-center">
        <form runat="server">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col col-xl-10">
                        <div class="card shadow-sm minmaxWidth420" style="border-radius: 1rem;">
                            <div class="row g-0">
                                <div class="col-md-12 d-flex align-items-center">
                                    <div class="card-body p-3 text-black">

                                        <div class="text-center mb-0 pb-0">
                                            <a href="Pages/Index/Home_Page/index.html">
                                                <img src="../../../Images/Home/onlineExam_Logo.png" class="img-fluid">
                                            </a>
                                        </div>
                                        <div class="studentLogin colorBlue my-3">
                                            <marquee>
                                                <h3>Login Page</h3>
                                            </marquee>
                                        </div>
                                        <div class="form-outline mb-4 d-flex align-items-center border rounded px-2">
                                            <i class="fas fa-user"></i>

                                            <select runat="server" id="ddlrole" class="input border-0 form-control" required>
                                                <option value="">--Select Role--</option>
                                                <option value="Admin">Admin</option>
                                                <option value="Teacher">Teacher</option>
                                                <option value="Student">Student</option>
                                            </select>


                                        </div>





                                        <div class="form-outline mb-4 d-flex align-items-center border rounded px-2">
                                            <i class="fas fa-user"></i>

                                            <asp:TextBox ID="txtuser" autocomplete="off" runat="server" class="input border-0 form-control" placeholder="Enter Username" pattern="^[a-zA-Z][a-zA-Z0-9]{2,12}$" title="Username name must be of alphanumeric characters only ranging from 3 to 10 characters." required="required" />
                                        </div>
                                        <div class="form-outline mb-4 d-flex align-items-center border rounded px-2">
                                            <i class="fas fa-lock"></i>
                                            <asp:TextBox ID="txtpassword" runat="server" class="input border-0 form-control" type="password" placeholder="Enter Password" pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*^()~`?&])[A-Za-z\d@$!%*^()~`?&]{8,15}$" title="Password must contain minimum eight characters, maximum 15 characters, at least one uppercase letter, one lowercase letter, one special character and one number." required="required" />

                                            <span class="eyeIcons" onclick="password_show_hide();">
                                                <i class="fas fa-eye" id="show_eye"></i>
                                                <i class="fas fa-eye-slash d-none" id="hide_eye"></i>
                                            </span>
                                        </div>
                                        <div class="pt-1 mb-4 text-center">
                                            <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" CssClass="btnlogin btn btn-primary w-100 px-4 py-2" />

                                        </div>
                                        <div class="d-md-flex align-items-center justify-content-between fs-16">
                                            <div class="signupaccount text-center">
                                                <asp:CheckBox ID="remember_me" runat="server" CssClass="textDecoration" />
                                                <asp:Label ID="Label1" runat="server" Text="Remember Me" CssClass="textDecoration"></asp:Label>

                                            </div>
                                            <div class="forgot text-center">
                                                <a id="fgtpass" href="Pages/Forgot_Password/Password_Recovery.aspx" class="textDecoration">Forgot Password?</a>
                                            </div>

                                        </div>
                                        <div class="text-center py-2">
                                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </section>
</body>
</html>
<script type="text/javascript">
    function password_show_hide() {
        var x = document.getElementById("txtpassword");
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

    var queryVal = location.search.split("name=")[1].replace("%20", " ");
    if (queryVal !== undefined) {
        var nameData = document.getElementById("message");
        nameData.innerHTML += '<span> <img src="../../../Images/Home/outline_person_black_24dp.png" width="35" class="" /></span>' + ' ' + queryVal;

    }
    else {
        window.location = '../Pages/Index/Home_Page/index.html';

    }

    function preventBack() { window.history.forward(); }
    setTimeout("preventBack()", 0);
    window.onunload = function () { null };
</script>
