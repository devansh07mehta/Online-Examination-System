<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="OnlineTestApp.Admin.AddClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1 class="py-3">Add Class</h1>
    <%--<form id="form1" runat="server">--%>
        <div class="row">
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblname" runat="server"  Text="Class Name:"></asp:Label>
                <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
            </div>
            

            <div class="form-group mt-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-primary" />
            </div>

        </div>
    <%--</form>--%>
    
</asp:Content>
