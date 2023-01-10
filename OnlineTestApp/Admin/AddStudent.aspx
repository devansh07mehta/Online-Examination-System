<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="OnlineTestApp.Admin.AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1 class="py-3">Add Student</h1>
    <%--<form id="form1" runat="server">--%>
        <div class="row">
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblname" runat="server"  Text="Full Name:"></asp:Label>
                <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="Label1" runat="server" Text="UserName:"></asp:Label>
                <asp:TextBox ID="txtuser" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="Label2" runat="server" Text="Email Address:"></asp:Label>
                <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblpass" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtpassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblclass" runat="server" Text="Class:"></asp:Label>
                <asp:DropDownList ID="ddlclass" runat="server" class="form-control" ></asp:DropDownList>
            </div>
             <div class="form-group col-md-6 mb-3">
                <asp:Label ID="Label3" runat="server" Text="Intake Year:"></asp:Label>
                 <select runat="server" id="ddlIntakeYear" class="form-control" required>
                     <option value="">--Select Year--</option>
                     <option value="2022">2022</option>
                     <option value="2021">2021</option>
                     <option value="2020">2020</option>
                 </select>
               
            </div>
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblphone" runat="server" Text="Contact Number :"></asp:Label>
                <asp:TextBox ID="txtphone" class="form-control" runat="server"></asp:TextBox>
            </div>
             <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblIsactive" runat="server" Text="IsActive :"></asp:Label>
                <asp:CheckBox ID="chkactive" class="form-control" runat="server"></asp:CheckBox>
            </div>

            <br />

            <div class="form-group mt-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />
            </div>

        </div>
    <%--</form>--%>
    
</asp:Content>
