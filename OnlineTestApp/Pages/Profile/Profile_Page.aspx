<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Profile_Page.aspx.cs" Inherits="OnlineTestApp.Pages.Profile.Profile_Page" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Profile</title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link href="../../Content/content.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/home.css" rel="stylesheet" type="text/css" />
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

            <div class="container" style="margin-left:10em">

                <div class="row no-gutters d-flex align-items-center align-items-stretch">

                    <div class="col-md-4 d-flex align-items-center  justify-content-start">
                        <div class="text">
                            <img src="../../../Images/Home/email.jpg" alt="Image not found" width="30" class="">
                            <span class="text-primary mx-1" style="font-size: 1rem; font-weight: 600">online_exam@gmail.com</span>
                        </div>
                    </div>
                    <div class="col-md-4 d-flex align-items-start justify-content-start">
                        <div class="text mt-3">
                            <img src="../../../Images/Home/call.jpg" alt="Image not found" width="30" class="">
                            <a href="#" style="text-decoration: none"><span class="text-primary" style="font-size: 1rem; font-weight: 600">+91 8369515644</span></a>
                        </div>
                    </div>
                    <div class="col-md-4 d-flex align-items-start justify-content-start">
                        <div class="text mt-3">
                            <img src="../../../Images/Home/address.jpg" alt="Image not found" width="30" class="mb-2">
                            <a href="#" style="text-decoration: none"><span class="text-primary mx-1" style="font-size: 1rem; font-weight: 600">Mumbai, Maharashtra</span></a>
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
                                        <button runat="server" class="btn btn-light me-2 minW160" style="font-size: 1rem" id="message">
                                        </button>

                                    </a>
                                    <div class="dropdown-menu">




                                        

                                        <asp:Button ID="Change_psw" runat="server" CssClass="dropdown-item text-primary" Text="Change Password" OnClick="Button2_Click" />
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




        <div class="d-flex align-items-center justify-content-center" style="margin-top: 5.5em">
            <h1 class="text-center text-primary">View Profile</h1>
        </div>
        <div class="container2">
            <br />
            <div class="row">

                <div class="col-md-6 mt-3 px-4">
                    <asp:Label ID="Label1" runat="server" Text="Full Name" CssClass="form-label" Style="font-size: 18px;"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control mt-2 py-2" pattern="([A-Z][a-z]{2,} )([A-Z][a-z]{2,})" title="Full Name must contain first name and last name only where first letter must be capital of both first name as well as last name and note first name must have atleast 3 characters and last name must have atleast 4 characters."></asp:TextBox><br />
                </div>
                <div class="col-md-6 mt-3 px-4">
                    <asp:Label ID="Label2" runat="server" Text="Contact Number" CssClass="form-label" Style="font-size: 18px;" pattern="[6789][0-9]{9}" title="Contact number must start with 6,7,8 or 9th digit and must be of total 10 digits ranging from 0-9."></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control mt-2 py-2"></asp:TextBox><br />
                </div>

                <div class="col-md-6 mt-3 px-4">
                    <asp:Label ID="Label5" runat="server" Text="UserName" CssClass="form-label" Style="font-size: 18px;"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control mt-2 py-2" ReadOnly="true" pattern="^[a-zA-Z][a-zA-Z0-9]{2,12}$" title="Username must start with alphabets followed by numbers or other set of alphabets ranging from 3 to 10 in length."></asp:TextBox><br />
                </div>
                <div class="col-md-6 mt-3 px-4">
                    <asp:Label ID="Label4" runat="server" Text="Email Id" CssClass="form-label" Style="font-size: 18px;" pattern="^[a-z][-_.a-z0-9]{5,29}@gmail\.com$" title="Email Id must match the following patterns: abc123@gmail.com or abc_123@gmail.com or abc.123@gmail.com or abc-123@gmail.com or abcabc@gmail.com"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control mt-2 py-2"></asp:TextBox><br />
                </div>


            </div>
            <br />
            <div class="d-flex align-items-center justify-content-center my-4">
                <asp:Button ID="Button1" runat="server" Text="Update Profile" OnClick="Button1_Click" CssClass="text-align-content-center btn btn-primary px-4 py-2" Style="font-size: 20px" />
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

                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">No</button>

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



                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">No</button>

                </div>

            </div>
        </div>
    </div>
</body>
<script>
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
</html>