<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExamList.aspx.cs" Inherits="OnlineTestApp.Admin.ExamList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="py-3">Examinations List</h1>
 
    

      <div class="table-responsive customTablespace">
         <asp:GridView ID="grvAvailableExam" runat="server" CssClass="table-bordered" AllowPaging="true" AutoGenerateColumns="false" Width="100%" HeaderStyle-ForeColor="blue" AllowSorting="True" HorizontalAlign="Center" OnPageIndexChanging="grvAvailableExam_PageIndexChanging">
             <HeaderStyle 
                BackColor="#0d6efd" 
                Font-Italic="false" 
                ForeColor="Snow" 
                />
             <RowStyle ForeColor="#4A3C8C" />
             
             <Columns>
               


                <asp:BoundField DataField="StudentId" HeaderText="Student Id" />
                <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                <asp:BoundField DataField="ExamName" HeaderText="Exam Name"  />
                <asp:BoundField DataField="Subject" HeaderText="Subject"  />
                <asp:BoundField DataField="Instruction" HeaderText="Instruction"  />
                <asp:BoundField DataField="DurationInMinute" HeaderText="Duration"  />
                <asp:BoundField DataField="ExamStart" HeaderText="Exam Start" />
                <asp:BoundField DataField="ExamEnd" HeaderText="Exam End"  />


                <asp:TemplateField HeaderText="Manage">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnView" Text="View Question" CommandArgument='<%#Eval("ExamId") %>' OnClick="btnView_Click" />


                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    
</asp:Content>
