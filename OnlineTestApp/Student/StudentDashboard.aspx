<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDashboard.aspx.cs" Inherits="OnlineTestApp.Student.StudentDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <br />
    <br />
     <h1 class="text-center">Student Dashboard</h1>

    <div class="container">
        <div class="row">

            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Student</h5>
                        <p class="card-text">Name of the Student Registered is 
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </p>
                       <asp:Button ID="stu_profile" runat="server" class="btn btn-primary" Text="View Student Profile" OnClick="Stdn_Profile_Click" />
                       
                    </div>
                </div>
            </div>
            
            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Available Exam</h5>
                        <p class="card-text">Total Number of Available Exams = 
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </p>
                       
                       
                       <asp:Button ID="btnExam" runat="server" class="btn btn-primary" Text="View Available Exam" OnClick="btnExam_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Exam History</h5>
                        <p class="card-text">Total Number of Exams Appeared = 
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </p>
                        
                       <asp:Button ID="btnHistory" runat="server" class="btn btn-primary" Text="View Exam History" OnClick="btnHistory_Click" />

                    </div>
                </div>
            </div>
            
        </div>
    </div>
  

</asp:Content>
