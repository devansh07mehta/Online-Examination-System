<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="OnlineTestApp.Pages.Change_Password.Change_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Password</title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <link href="../../../Content/design1.css" rel="stylesheet" />
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link href="../../../Content/home.css" rel="stylesheet" type="text/css" />
    <link href="../../../Css/home.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <style>
        .w150 {
            width: 150px;
        }

        .w30 {
            width: 30px;
        }


        ul.footerData li {
            margin: 0 1.5rem 0 0 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-topnavbar-light bg-white">

            <div class="container" style="margin-left: 10em">

                <div class="row no-gutters d-flex align-items-center align-items-stretch">

                    <div class="col-md-4 d-flex align-items-center justify-content-start">
                        <div class="text">
                            <img src="../../../Images/Home/email.jpg" alt="Image not found" width="35" class="ms-4">
                            <span class="text-primary mx-1" style="font-size: 20px; font-weight: 600">online_exam@gmail.com</span>
                        </div>
                    </div>
                    <div class="col-md-4 d-flex align-items-start justify-content-start">
                        <div class="text mt-3">
                            <img src="../../../Images/Home/call.jpg" alt="Image not found" width="40" class="ms-4">
                            <a href="#" style="text-decoration: none"><span class="text-primary" style="font-size: 20px; font-weight: 600">+91 8369515644</span></a>
                        </div>
                    </div>
                    <div class="col-md-4 d-flex align-items-start justify-content-start">
                        <div class="text mt-3">
                            <img src="../../../Images/Home/address.jpg" style="border-radius: 2em;" alt="Image not found" width="40" class="ms-4 mb-2">
                            <a href="#" style="text-decoration: none"><span class="text-primary mx-1" style="font-size: 20px; font-weight: 600">Mumbai, Maharashtra</span></a>
                        </div>
                    </div>



                </div>
            </div>
        </div>
        <nav class="navbar  navbar-expand-lg navbar-primary bg-primary sticky-top" id="navbarSection">
            <div class="container-fluid" id="navTop">
                <a class="navbar-brand d-flex align-items-center" href="#" runat="server" onserverclick="Image_Click">
                    <div class="logoImage1 rounded-circle">
                        <%--<img alt="logo" src="Images/logo.png" />--%>
                        <asp:Image runat="server" ID="imglogo" Width="150px" Height="50px" class="w30" ImageUrl="~/Images/Home/logo-black.png" />

                        <%--<h3 style="color:white">Online Test Application</h3>--%>
                    </div>
                    <!-- <div class="logoText text-white">Online<br> Exam</div> -->

                </a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navNavbar"
                    aria-controls="navNavbar" aria-expanded="false" aria-label="Toggle navigation">
                    <asp:Image runat="server" ID="imgmenu" class="w30" ImageUrl="~/Images/menu.png" />
                    <%--<img alt="menu" src="Images/logo.png" class="w30" />--%>
                    <%--<asp:image id="myImage" runat="server" ImageUrl="~/Images/menu.png" />--%>
                </button>
                <div class="collapse navbar-collapse justify-content-end" id="navNavbar">
                    <ul class="navbar-nav">
                        <%--<li class="nav nav-item" id="li1" runat="server">
                        <a class="nav-link" href="Default.aspx">Dashboard</a>
                    </li>--%>
                        <li class="nav nav-item" id="liadmindashboard" runat="server">
                            <a href="#" runat="server" class="nav-link" onserverclick="AdminDashboard_Click">Dashboard</a>

                        </li>

                        <li class="nav nav-item" id="liteacher" runat="server">
                            <a href="#" runat="server" class="nav-link" onserverclick="TeacherList_Click">Teacher</a>


                        </li>
                        <li class="nav nav-item" id="listudent" runat="server">
                            <a href="#" runat="server" class="nav-link" onserverclick="StudentList_Click">Student</a>


                        </li>
                        <li class="nav nav-item" id="lisubject" runat="server">
                            <a href="#" runat="server" class="nav-link" onserverclick="SubjectList_Click">Subject</a>


                        </li>
                        <li class="nav nav-item" id="liclass" runat="server">
                            <a href="#" runat="server" class="nav-link" onserverclick="ClassList_Click">Class</a>


                        </li>
                        <li class="nav nav-item" id="liAllExam" runat="server">
                            <a href="#" runat="server" class="nav-link" onserverclick="ExamList_Click">Exam List</a>


                        </li>
                        <li class="nav nav-item" id="liteacherdashboard" runat="server">
                            <a class="nav-link" href="#" runat="server" onserverclick="TeacherDashboard_Click">Dashboard</a>

                        </li>
                        <li class="nav nav-item" id="liexamination" runat="server">
                            <a class="nav-link" href="#" runat="server" onserverclick="Examination_Click">Examination</a>

                        </li>
                        <li class="nav nav-item" id="liquestion" runat="server">
                            <a class="nav-link" href="#" runat="server" onserverclick="QuestionList_Click">Questions</a>

                        </li>
                        <li class="nav nav-item" id="listudentdashboard" runat="server">
                            <a class="nav-link" href="#" runat="server" onserverclick="StudentDashboard_Click">Dashboard</a>

                        </li>
                        <li class="nav nav-item" id="liavailableexam" runat="server">
                            <a class="nav-link" href="#" runat="server" onserverclick="AvailableExam_Click">Available Exam</a>

                        </li>
                        <li class="nav nav-item" id="liexamhistory" runat="server">
                            <a class="nav-link" href="#" runat="server" onserverclick="ExamHistory_Click">Exam History</a>

                        </li>


                    </ul>
                </div>
                <div class="collapse navbar-collapse justify-content-end" id="navNavbar">
                    <ul class="navbar-nav ">
                        <li class="nav nav-item">
                            <div class="btn-group pt-2">



                                <li class="nav-item dropdown has-arrow">
                                    <a href="#" class="" data-bs-toggle="dropdown">
                                        <button runat="server" class="btn btn-light me-5 minW100" style="font-size: 20px" id="message">
                                        </button>

                                    </a>
                                    <div class="dropdown-menu">




                                        <asp:Button ID="My_Profile" runat="server" CssClass="dropdown-item text-primary" Text="My Profile" OnClick="Button1_Click" />


                                        <button type="button" class="dropdown-item text-primary" data-bs-toggle="modal" data-bs-target="#myModal1">Delete Account</button>
                                        <button type="button" class="dropdown-item text-primary" data-bs-toggle="modal" data-bs-target="#myModal2">Log Out</button>


                                    </div>

                                </li>





                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="d-flex align-items-center justify-content-center" style="margin-top: 80px">
            <h1 class="text-center text-primary mt-5">Change Password</h1>
        </div>
        <div class="container">
            <br />
            <div class="row">
                <div class="col-md-7 mx-auto mb-3">
                   <div class="form-group position-relative">
                        <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label><br />
                        <asp:TextBox ID="TextBox1" class="form-control input-sm" runat="server" type="password" pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*^()~`?&])[A-Za-z\d@$!%*^()~`?&]{8,15}$" title="Old Password has minimum eight characters, maximum 15 characters, at least one uppercase letter, one lowercase letter, one special character and one number." required="required"></asp:TextBox>
                        <span class="eyeIcons right10 bottom10 position-absolute" onclick="password_show_hide();">
                            <i class="fas fa-eye" id="show_eye"></i>
                            <i class="fas fa-eye-slash d-none" id="hide_eye"></i>
                        </span>
                    </div>
                </div>
                <div class="col-md-7 mx-auto mb-3">
                   <div class="form-group position-relative">
                        <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label><br />
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" type="password" pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*^()~`?&])[A-Za-z\d@$!%*^()~`?&]{8,15}$" title="New Password must contain minimum eight characters, maximum 15 characters, at least one uppercase letter, one lowercase letter, one special character and one number." required="required"></asp:TextBox>
                        <span class="eyeIcons right10 bottom10 position-absolute" onclick="password_show_hide1();">
                            <i class="fas fa-eye" id="show_eye1"></i>
                            <i class="fas fa-eye-slash d-none" id="hide_eye1"></i>
                        </span>
                    </div>
                </div>
                <div class="col-md-7 mx-auto mb-3">
                   <div class="form-group position-relative">                
                        <asp:Label ID="Label3" runat="server" Text="Confirm Password"></asp:Label><br />
                        <asp:TextBox ID="TextBox3" type="password" runat="server" CssClass="form-control"></asp:TextBox>
                        <span class="eyeIcons right10 bottom10 position-absolute" onclick="password_show_hide2();">
                            <i class="fas fa-eye" id="show_eye2"></i>
                            <i class="fas fa-eye-slash d-none" id="hide_eye2"></i>
                        </span>
                    </div>
                </div>
                <div class="col-md-7 mx-auto mb-3">
                    <div class="form-group position-relative text-center">
                        <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary my-2 px-3" OnClick="Change_psw" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- The Modal -->
    <div class="modal" id="myModal1">
        <div class="modal-dialog">
            <div class="modal-content">



                <!-- Modal body -->
                <div class="modal-body d-flex align-items-center justify-content-center">
                    Are You Sure You Want to Delete Account?
                </div>

                <!-- Modal footer -->
                <div class="modal-footer d-flex align-items-center justify-content-center">


                    <a href="../Delete_Account/Delete_Account.aspx" class="btn btn-primary">Yes</a>

                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">No</button>

                </div>

            </div>
        </div>
    </div>

    <!-- The Modal -->
    <div class="modal" id="myModal2">
        <div class="modal-dialog">
            <div class="modal-content">



                <!-- Modal body -->
                <div class="modal-body d-flex align-items-center justify-content-center">
                    Are You Sure You Want to Logout from the Account?
                </div>

                <!-- Modal footer -->
                <div class="modal-footer d-flex align-items-center justify-content-center">


                    <a href="../Logout/Logout.aspx" class="btn btn-primary">Yes</a>



                    <button type="button" class="btn btn-danger" data-bs-dismiss="modal">No</button>

                </div>

            </div>
        </div>
    </div>
</body>
</html>
<script type="text/javascript">
    function password_show_hide() {
        var x = document.getElementById("TextBox1");
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

    function password_show_hide1() {
        var x1 = document.getElementById("TextBox2");
        var show_eye1 = document.getElementById("show_eye1");
        var hide_eye1 = document.getElementById("hide_eye1");
        hide_eye1.classList.remove("d-none");
        if (x1.type == "password") {
            x1.type = "text";
            show_eye1.style.display = "none";
            hide_eye1.style.display = "block";
        }
        else {
            x1.type = "password";
            show_eye1.style.display = "block";
            hide_eye1.style.display = "none";
        }
    }

    function password_show_hide2() {
        var x2 = document.getElementById("TextBox3");
        var show_eye2 = document.getElementById("show_eye2");
        var hide_eye = document.getElementById("hide_eye2");
        hide_eye2.classList.remove("d-none");
        if (x2.type == "password") {
            x2.type = "text";
            show_eye2.style.display = "none";
            hide_eye2.style.display = "block";
        }
        else {
            x2.type = "password";
            show_eye2.style.display = "block";
            hide_eye2.style.display = "none";
        }
    }

    var queryVal = location.search.split("name=")[1];
    if (queryVal !== undefined) {
        var nameData = document.getElementById("message");
        nameData.innerHTML += '<span> <img src="../../../Images/Home/outline_person_black_24dp.png" width="35" class="" /></span>' + ' ' + queryVal;

    }
    else {
        window.location = '../../Index/Home_Page/index.html';

    }
</script>
