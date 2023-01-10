<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExamList.aspx.cs" Inherits="OnlineTestApp.Teacher.ExamList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-3">Exam List</h1>



    <div class="table-responsive customTablespace">

        <asp:Button ID="btnNew" runat="server" Text="New Exam" OnClick="btnNew_Click" CssClass="btn btn-primary" />
        <br />
        <br />
        <asp:GridView ID="grvExam" CssClass="table-bordered" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" Width="100%" OnPageIndexChanging="grvExam_PageIndexChanging" HorizontalAlign="Center">
            <HeaderStyle
                BackColor="#0d6efd"
                Font-Italic="false"
                ForeColor="Snow" />
            <RowStyle ForeColor="#4A3C8C" />
            <Columns>
                <asp:TemplateField HeaderText="Exam Id">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblexamid" Text='<%#Eval("ExamId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exam Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblexamname" Text='<%#Eval("ExamName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblsubject" Text='<%#Eval("SubjectName") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Class Name">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblclass" Text='<%#Eval("ClassName") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Instructions">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblinstruction" Text='<%#Eval("Instruction") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exam Start Date">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblexamstart" Text='<%#Eval("ExamStart","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exam End Date">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblexamend" Text='<%#Eval("ExamEnd","{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="Manage">
                    <ItemTemplate>

                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit /" CommandArgument='<%#Eval("ExamId") %>' OnClick="btnEdit_Click" />
                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete " CommandArgument='<%#Eval("ExamId") %>' OnClick="btnDelete_Click" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>


</asp:Content>

