<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SubjectList.aspx.cs" Inherits="OnlineTestApp.Admin.SubjectList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-3">Subject List</h1>
    <%--<form id="form1" runat="server">--%>
        <div class="table-responsive customTablespace">

            <asp:Button ID="btnNew" runat="server" Text="New Subject" OnClick="btnNew_Click" CssClass="btn btn-primary" />
            <br />
            <br />
            <asp:GridView ID="grvSubject" CssClass="table-bordered" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grvSubject_PageIndexChanging">
                <HeaderStyle 
                BackColor="#0d6efd" 
                Font-Italic="false" 
                ForeColor="Snow" 
                />

             <RowStyle ForeColor="#4A3C8C" />

                
                  <Columns>
                    <asp:TemplateField HeaderText="Subject Id">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEmpId" Text='<%#Eval("SubjectId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subject Code">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblLastName" Text='<%#Eval("Code") %>'></asp:Label>
                        </ItemTemplate>
                        
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Manage">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnEdit" Text="Edit /" CommandArgument='<%#Eval("SubjectId") %>' OnClick="btnEdit_Click" />
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandArgument='<%#Eval("SubjectId") %>' OnClick="btnDelete_Click" />


                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />

        </div>
    <%--</form>--%>
    
    </asp:Content>