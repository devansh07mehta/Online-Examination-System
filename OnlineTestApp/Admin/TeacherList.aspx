<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherList.aspx.cs" Inherits="OnlineTestApp.Admin.TeacherList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-3">Teacher List</h1>

    <%--<form id="form1" runat="server">--%>
        <div class="table-responsive customTablespace">

            <asp:Button ID="btnNew" runat="server" Text="New Teacher" OnClick="btnNew_Click" CssClass="btn btn-primary" />
            <br />
            <br />
            <asp:GridView ID="grvTeacher" runat="server" AllowPaging="true" AllowSorting="true" CssClass="table-bordered mt-3" AutoGenerateColumns="false" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grvTeacher_PageIndexChanging" >
                  <HeaderStyle 
                BackColor="#0d6efd" 
                Font-Italic="false" 
                ForeColor="Snow" 
                />
             <RowStyle ForeColor="#4A3C8C" />

                <Columns>
                    <asp:TemplateField HeaderText="TeacherId">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEmpId" Text='<%#Eval("TeacherID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teacher Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("TeacherName") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UserName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLastName" Text='<%#Eval("UserName") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone No.">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPhoneNumber" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEmailAddress" Text='<%#Eval("Email") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Intake Year">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblSalary" Text='<%#Eval("IntakeYear") %>'></asp:Label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Manage">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnEdit" Text="Edit /" CommandArgument='<%#Eval("TeacherID") %>' CssClass="glyphicon glyphicon-pencil" OnClick="btnEdit_Click" />
                            <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandArgument='<%#Eval("TeacherID") %>' class="glyphicon glyphicon-envelope" OnClick="lnkDelete_Click"></asp:LinkButton>

                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </div>
    <%--</form>--%>
    
</asp:Content>

