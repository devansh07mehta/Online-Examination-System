<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="OnlineTestApp.Student.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />

    <div class="page-wrap d-flex flex-row align-items-center" style="background: #dedede">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-12 text-center">
                    <span class="display-1 d-block">Time Expired !</span>
                    <div class="mb-4 lead">Please Contact Teachers </div>
                    <%--<a href="https://www.totoprayogo.com/#" class="btn btn-link">Back to Home</a>--%>
                <asp:Button ID="btnBack" runat="server" class="btn btn-link" Text="Back to Home" OnClick="btnBack_Click" />

                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
