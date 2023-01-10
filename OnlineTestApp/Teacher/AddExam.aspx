<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddExam.aspx.cs" Inherits="OnlineTestApp.Teacher.AddExam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1 class="py-3">Add Examination</h1>

 
    
        <div class="row">

            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblsubject" runat="server" Text="Subject :"></asp:Label>
                <asp:DropDownList ID="ddlSubject" runat="server" class="form-control"></asp:DropDownList>
            </div>

            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblname" runat="server" Text="Exam Name :"></asp:Label>
                <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblinstruction" runat="server" Text="Instruction :"></asp:Label>
                <asp:TextBox ID="txtinstruction" runat="server" class="form-control"></asp:TextBox>
            </div>


            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="Label2" runat="server" Text="Duration (In Minutes) :"></asp:Label>
                <asp:TextBox ID="txtDuration" runat="server" class="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-6 mb-3" visible="false">
                <asp:Label ID="Label1" runat="server" Text="Passing Marks (In %) :"></asp:Label>
                <asp:TextBox ID="txtpassMark" runat="server" Text="35" ReadOnly="true" class="form-control"></asp:TextBox>
            </div>


            <div class="form-group col-md-6 mb-3" >
                <asp:Label ID="lblclass" runat="server" Text="Class :"></asp:Label>
                <asp:DropDownList ID="ddlclass" runat="server" class="form-control"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblpass" runat="server" Text="Exam Start :"></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server" class="form-control" TextMode="DateTime" ReadOnly="true"></asp:TextBox>

                <asp:ImageButton ID="ImageButton2" runat="server" Height="34px" ImageUrl="~/Images/Calendar-256.png" OnClick="ImageButton2_Click" Style="margin-left: 0px" Width="33px" />
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" OnSelectionChanged="Calendar2_SelectionChanged" Width="330px" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth">
                    <DayHeaderStyle Font-Bold="True" Height="8pt" Font-Size="8pt" ForeColor="#333333" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                </asp:Calendar>
            </div>

            <div class="form-group col-md-6 mb-3">
                <asp:Label ID="lblcode" runat="server" Text="Exam End :"></asp:Label>
                <asp:TextBox ID="txtEndDate" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>

                <asp:ImageButton ID="ImageButton1" runat="server" Height="34px" ImageUrl="~/Images/Calendar-256.png" OnClick="ImageButton1_Click" Style="margin-left: 0px" Width="33px" />
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" OnSelectionChanged="Calendar1_SelectionChanged" Width="330px" BorderStyle="Solid" CellSpacing="1" NextPrevFormat="ShortMonth">
                    <DayHeaderStyle Font-Bold="True" Height="8pt" Font-Size="8pt" ForeColor="#333333" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#333399" Font-Bold="True" Font-Size="12pt" ForeColor="White" BorderStyle="Solid" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                </asp:Calendar>
            </div>

            <div class="form-group mt-3">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" />
            </div>

        </div>
    <%--</form>--%>
    
</asp:Content>

