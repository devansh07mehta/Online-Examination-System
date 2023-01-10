<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="OnlineTestApp.Admin.StudentList" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-3">Student List</h1>

    
    <div class="table-responsive customTablespace">
    
          <asp:Button ID="btnNew" runat="server" Text="New Student" OnClick="btnNew_Click" CssClass="btn btn-primary" />

    <br /><br/><asp:GridView ID="grvStudent" CssClass="table-bordered mb-2" runat="server" AllowSorting="true" HorizontalAlign="Center" AllowPaging="true" OnPageIndexChanging="grvStudent_PageIndexChanging" Width="100%" AutoGenerateColumns="False">
          <HeaderStyle 
                BackColor="#0d6efd" 
                Font-Italic="false" 
                ForeColor="Snow" 
                />
             <RowStyle ForeColor="#4A3C8C" />

        <Columns>
            <asp:TemplateField HeaderText="Student Id">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblstudentId" Text='<%#Eval("StudentId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="StudentName">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblStudentName" Text='<%#Eval("StudentName") %>'></asp:Label>
                </ItemTemplate>
               
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UserName">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblUserName" Text='<%#Eval("UserName") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblemail" Text='<%#Eval("Email") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Intake Year">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblpassword" Text='<%#Eval("IntakeYear") %>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone Number">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSalary" Text='<%#Eval("PhoneNumber") %>'></asp:Label>
                </ItemTemplate>
              
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                     <asp:LinkButton runat="server" ID="btnEdit" Text="Edit /" CommandArgument='<%#Eval("StudentId") %>' CssClass="glyphicon glyphicon-pencil" OnClick="btnEdit_Click" />     
                        <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandArgument='<%#Eval("StudentId") %>' class="glyphicon glyphicon-envelope" OnClick="lnkDelete_Click" ></asp:LinkButton>
                  
                </ItemTemplate>
               
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    </div>
    <%--</form>--%>
    
    </asp:Content>

