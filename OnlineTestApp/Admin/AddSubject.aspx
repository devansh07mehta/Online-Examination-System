<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSubject.aspx.cs" Inherits="OnlineTestApp.Admin.AddSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1 class="py-3">Add Subject</h1>
    
        <div class="row">
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblname" runat="server"  Text="Subject Name:"></asp:Label>
                <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblcode" runat="server" Text="Subject Code :"></asp:Label>
                <asp:TextBox ID="txtcode" runat="server" class="form-control"></asp:TextBox>
            </div>

            <div class="form-group mt-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />
            </div>

        </div>
   
    
</asp:Content>