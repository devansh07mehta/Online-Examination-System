<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExamHistory.aspx.cs" Inherits="OnlineTestApp.Student.ExamHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h1 class="py-3"> Exam History</h1>

    <div class="table-responsive customTablespace">
         <asp:GridView ID="grvAvailableExam" runat="server" CssClass="table-bordered" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" Width="100%" HeaderStyle-ForeColor="blue" HorizontalAlign="Center">
             <HeaderStyle 
                BackColor="#0d6efd" 
                Font-Italic="false" 
                ForeColor="Snow" 
                />
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
                <asp:TemplateField HeaderText="Subject">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblsubjext" Text='<%#Eval("Subject") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Instruction">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblinstruction" Text='<%#Eval("Instruction") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Duration In Minutes">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblduration" Text='<%#Eval("DurationInMinute") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Exam Started">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblexamstart" Text='<%#Eval("ExamStart") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField >
                <asp:TemplateField HeaderText="Exam End" Visible="false">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblexamend" Text='<%#Eval("ExamEnd") %>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Manage">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnView" Text="View Question" CommandArgument='<%#Eval("ExamId") %>' OnClick="btnView_Click" />


                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    
</asp:Content>
