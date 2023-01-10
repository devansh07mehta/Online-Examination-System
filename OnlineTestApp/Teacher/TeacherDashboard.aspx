<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherDashboard.aspx.cs" Inherits="OnlineTestApp.Teacher.TeacherDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <h1 class="text-center">Teacher Dashboard</h1>
    <br />
    <div class="container">
        <div class="row">

            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    <div class="card-body">
                        <h5 class="card-title">Teacher</h5>
                        <p class="card-text">Name of the Teacher Registered is
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </p>
                        
                        <asp:Button ID="teacher_profile" runat="server" class="btn btn-primary" Text="View Teacher Profile" OnClick="Teacher_Profile_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Examination</h5>
                        <p class="card-text">Total Number of Examinations Conducted = 
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </p>
                        
                        <asp:Button ID="btnExamination" runat="server" class="btn btn-primary" Text="View Examinations" OnClick="btnExamination_Click" />
                    </div>
                </div>
            </div>
            
            <div class="col-md-4 pb-4">
                <div class="card text-center ser1 shadow-sm bg-light py-4 border">
                    
                    <div class="card-body">
                        <h5 class="card-title">Question</h5>
                        <p class="card-text">Total Number of Questions Added = 
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </p>
                        
                        <asp:Button ID="btnQuestion" runat="server" class="btn btn-primary" Text="View Questions" OnClick="btnQuestion_Click" />

                    </div>
                </div>
            </div>
              
        </div>
    </div>
    
</asp:Content>
