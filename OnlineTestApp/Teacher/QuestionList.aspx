<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="OnlineTestApp.Teacher.QuestionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-3">Question  List</h1>
    

    
    <div class="table-responsive customTablespace">

        <asp:Button ID="btnNew" runat="server" Text="New Question" OnClick="btnNew_Click" CssClass="btn btn-primary" />
        <br />
        <br />
        <asp:GridView ID="grvQuestion" runat="server" CssClass="table-bordered" AllowPaging="true" AutoGenerateColumns="false" Width="100%" HeaderStyle-ForeColor="blue" HorizontalAlign="Center">
            <HeaderStyle BackColor="#0d6efd" Font-Italic="false" ForeColor="Snow" />
            <RowStyle ForeColor="#4A3C8C" />
            <Columns>
                <asp:TemplateField HeaderText="Question Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblEmpId" Text='<%#Eval("QuestionId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Question">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("Question") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Option 1">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblLastName" Text='<%#Eval("Option1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Option 2">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblPhoneNumber" Text='<%#Eval("Option2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Option 3">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblEmailAddress" Text='<%#Eval("Option3") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Option 4">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblSalary" Text='<%#Eval("Option4") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Manage">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnEdit" Text="Edit /" CommandArgument='<%#Eval("QuestionId") %>' OnClick="btnEdit_Click" />
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete /" CommandArgument='<%#Eval("QuestionId") %>' OnClick="btnDelete_Click" />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    <%--</form>--%>
    
</asp:Content>

