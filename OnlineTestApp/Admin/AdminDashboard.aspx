<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="OnlineTestApp.Admin.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <br />
    <h1 class="text-center">Admin Dashboard</h1>
    <br />



    <div class="container">
        <div class="row">

            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Admin</h5>
                        <p class="card-text">Adminstrator of the System is 
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </p>

                        
                        <asp:Button ID="btnAdmin" runat="server" class="btn btn-primary" Text="View Admin Profile" OnClick="btnAdmin_Click" />
                    </div>
                </div>
            </div>
            
            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Teacher</h5>
                        <p class="card-text">Total Number of Teachers Registered = 
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </p>
                        
                        <asp:Button ID="btnTeacher" runat="server" class="btn btn-primary" Text="View Teacher List" OnClick="btnTeacher_Click" />

                    </div>
                </div>
            </div>
            
            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Student</h5>
                        <p class="card-text">Total Number of Registered Students = 
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </p>
                        
                        <asp:Button ID="btnStudent" runat="server" class="btn btn-primary" Text="View Student List" OnClick="btnStudent_Click" />

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">

            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Subject</h5>
                        <p class="card-text">Total Number of Subjects added = 
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </p>
                       
                        <asp:Button ID="btnSubject" runat="server" class="btn btn-primary" Text="View Subject List" OnClick="btnSubject_Click" />

                    </div>
                </div>
            </div>
            
            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Class</h5>
                        <p class="card-text">Total Number of Classes created =
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        </p>
                        
                        <asp:Button ID="btnClass" runat="server" class="btn btn-primary" Text="View Class List" OnClick="btnClass_Click" />

                    </div>
                </div>
            </div>
            
            <div class="col-md-4 pb-4" >
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Exam</h5>
                        <p class="card-text">Total Number of Exams Conducted = 
                            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                        </p>
                        
                        <asp:Button ID="btnExamlist" runat="server" class="btn btn-primary" Text="View Exam List" OnClick="btnExamlist_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    

</asp:Content>
