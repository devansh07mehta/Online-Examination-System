<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClassList.aspx.cs" Inherits="OnlineTestApp.Admin.ClassList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-3">Class List</h1>
    <%--<form id="form1" runat="server">--%>
        <div class="table-responsive customTablespace">

            <asp:Button ID="btnNew" runat="server" Text="New Class" CssClass="btn btn-primary" OnClick="btnNew_Click" />
            <br />
            <br />
            <asp:GridView ID="grvClass" runat="server" AllowPaging="true" AutoGenerateColumns="false" Width="100%" AllowSorting="true" CssClass="table-bordered" HorizontalAlign="Center" HeaderStyle-ForeColor="blue" OnPageIndexChanging="grvClass_PageIndexChanging">
                  <HeaderStyle 
                BackColor="#0d6efd" 
                Font-Italic="false" 
                ForeColor="Snow" 
                />
                 <RowStyle ForeColor="#4A3C8C" />
                
                <Columns>
                    <asp:TemplateField HeaderText="ClassId">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblEmpId" Text='<%#Eval("ClassId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ClassName">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblFirstName" Text='<%#Eval("ClassName") %>'></asp:Label>
                        </ItemTemplate>
                       
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Manage">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnEdit" Text="Edit /" CommandArgument='<%#Eval("ClassId") %>' OnClick="btnEdit_Click" />
                            <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete" CommandArgument='<%#Eval("ClassId") %>' OnClick="lnkDelete_Click"></asp:LinkButton>



                        </ItemTemplate>
                        <%-- <EditItemTemplate>
                    <asp:LinkButton runat="server" ID="btnUpdate" Text="Update" CommandName="Update" />
                    <br />
                    <asp:LinkButton runat="server" ID="btnCancel" Text="Cancel" CommandName="Cancel" />
                </EditItemTemplate>--%>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    <%--</form>--%>
    

</asp:Content>
