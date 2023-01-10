<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="OnlineTestApp.Student.TestPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        var queryVal = location.search.split("name=")[1];
        if (queryVal !== undefined) {
            var nameData = document.getElementById("message");
            nameData.innerHTML += '<span> <img src="../../../Images/Home/outline_person_black_24dp.png" width="35" class="" /></span>' + ' ' + queryVal;

        }
        else {
            window.location = '../Pages/Index/Home_Page/index.html';

        }

        function startTimer(duration, display) {
            var timer = duration, minutes, seconds;
            var end = setInterval(function () {
                minutes = parseInt(timer / 60, 10)
                seconds = parseInt(timer % 60, 10);

                minutes = minutes < 10 ? "0" + minutes : minutes;
                seconds = seconds < 10 ? "0" + seconds : seconds;

                display.textContent = minutes + ":" + seconds;

                if (--timer < 0) {
                    //window.location = "http://www.example.com";
                    location.href = '<%= Page.ResolveUrl("~/Student/ErrorPage.aspx") %>';

                    clearInterval(end);
                }
            }, 1000);
        }

        window.onload = function () {
            debugger;
            array_store = document.getElementById("array_store");
            //array_store = document.getElementById("array_store");
            var data = document.getElementById('<%=HiddenField1.ClientID%>').value;
            var fiveMinutes = data,
                display = document.querySelector('#time');
            startTimer(fiveMinutes, display);
        };
    </script>



    <div>Time Left :<span id="time" ></span></div>
    
        <asp:HiddenField ID="HiddenField1" runat="server" />

    <asp:GridView ShowHeader="false" AutoGenerateColumns="false" GridLines="None" Width="500px" ID="rgtest" runat="server">

        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblQuestionId" Text='<%# Eval("QuestionId") %>' runat="server"></asp:Label>
                    <asp:Label ID="lblQuestion" Text='<%# Eval("Question") %>' runat="server"></asp:Label><br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("Option1") %>' ID="id1" runat="server" /><br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("Option2") %>' ID="id2" runat="server" /><br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("Option3") %>' ID="id3" runat="server" /><br />
                    <asp:RadioButton GroupName="a" Text='<%# Eval("Option4") %>' ID="id4" runat="server" /><hr />

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
   <%-- <asp:Label ID="lblQuestionarray" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblQuestion" Text='<%# Eval("Question") %>' runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblA" runat="server"></asp:Label>
    <asp:Label ID="lblB" runat="server"></asp:Label>
    <asp:Label ID="lblC" runat="server"></asp:Label>
    <asp:Label ID="lblD" runat="server"></asp:Label>

    <br />--%>


    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

</asp:Content>
