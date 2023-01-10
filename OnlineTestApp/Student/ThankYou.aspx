<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="OnlineTestApp.Student.ThankYou" %>

<%--<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <div class="page-wrap d-flex flex-row align-items-center" style="background:#dedede">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-12 text-center">
                    <span class="display-1 d-block">Thank You</span>
                    <div class="mb-4 lead">You Have Succesully Completed the Test.</div>
                    <%--<a href="https://www.totoprayogo.com/#" class="btn btn-link">Back to Home</a>--%>
                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" class="btn btn-link" Text="Back to Home" />
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
