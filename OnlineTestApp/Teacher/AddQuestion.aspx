<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" Inherits="OnlineTestApp.Teacher.AddQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h3>Add Question</h3>

    <div>
        <div class="form-group">
            <asp:Label ID="lblexam" runat="server" Text="Examination :"></asp:Label>
            <asp:DropDownList ID="ddlExam" runat="server" class="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblQuestion" runat="server" Text="Name :"></asp:Label>
            <asp:TextBox ID="txtQuestion" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblOption1" runat="server" Text="A :"></asp:Label>
            <asp:TextBox ID="txtoption1" runat="server" class="form-control"></asp:TextBox>
        </div>


        <div class="form-group">
            <asp:Label ID="lblOption2" runat="server" Text="B :"></asp:Label>
            <asp:TextBox ID="txtoption2" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblOption3" runat="server" Text="C:"></asp:Label>
            <asp:TextBox ID="txtoption3" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="lblOption4" runat="server" Text="D :"></asp:Label>
            <asp:TextBox ID="txtoption4" runat="server" class="form-control"></asp:TextBox>
        </div>


        <div class="form-group">
            <asp:Label ID="lblcorrect" runat="server" Text="Answer"></asp:Label>
            <asp:DropDownList ID="ddlAnswer" runat="server" class="form-control">
                <asp:ListItem Value="0">--Select Answer--</asp:ListItem>
                <asp:ListItem Value="1">A</asp:ListItem>
                <asp:ListItem Value="2">B</asp:ListItem>
                <asp:ListItem Value="3">C</asp:ListItem>
                <asp:ListItem Value="4">D</asp:ListItem>
            </asp:DropDownList>
        </div>

        <br />

        <div class="form-group">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />
        </div>

    </div>
    
</asp:Content>
