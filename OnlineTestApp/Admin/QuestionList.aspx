<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" EnableEventValidation = "false" Inherits="OnlineTestApp.Admin.QuestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-3">Exam History</h1>
    <div>
        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary mb-3" OnClick="btnExport_Click" Text="Export to PDF" />
    </div>
    <div class="table-responsive customTablespace">
        <asp:GridView ID="grvQuestionList" runat="server" CssClass="table-bordered" OnPageIndexChanging="grvQuestionList_PageIndexChanging" AllowSorting="true" AllowPaging="true" AutoGenerateColumns="false" Width="100%" OnRowDataBound="grvQuestionList_RowDataBound" HeaderStyle-ForeColor="blue">
            <HeaderStyle
                BackColor="#0d6efd"
                Font-Italic="false"
                ForeColor="Snow" />
            <RowStyle ForeColor="#4A3C8C" />

            <Columns>
                <asp:BoundField DataField="QuestionId" HeaderText="Item" />
                <asp:BoundField DataField="Question" HeaderText="Question" />
                <asp:BoundField DataField="Option1" HeaderText="Option1" />
                <asp:BoundField DataField="Option2" HeaderText="Option2"  />
                <asp:BoundField DataField="Option3" HeaderText="Option3"  />
                <asp:BoundField DataField="Option4" HeaderText="Option4" />
                <asp:BoundField DataField="CorrectAnswer" HeaderText="CorrectAnswer" />
                <asp:BoundField DataField="GivenAnswer" HeaderText="GivenAnswer" />
                <asp:BoundField DataField="AttemptedOn" HeaderText="AttemptedOn"  />
                <asp:BoundField DataField="IsRight" HeaderText="IsRight" Visible="true" />

           
            </Columns>
        </asp:GridView>
    </div>
    
</asp:Content>