<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot_Password.aspx.cs" Inherits="Online_Examination_System.Pages.Student.Forgot_Password.Forgot_Password" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title></title>
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
    <!-- JavaScript Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link href="../../../Css/home.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
    <section class="vh-100 loginWrapper mt-0 d-flex align-items-center justify-content-center">
        <div class="container-fluid">
            <div class="row mx-auto card shadow-sm maxW400" style="max-width: 500px; width: 100%;">
                <div class="col-md-12 text-center mt-3">
                    <div class="form-group">
                        <h1 runat="server">Password Recovery</h1>
                        <br />
                    </div>
                </div>
                
                    <div class="col-md-10 mx-auto">
                        <div class="form-group">
                            <label for="usn" id="lblusn" runat="server"><b>Username</b></label>
                            <input type="text" runat="server" name="usn" id="txtusn" class="form-control" placeholder="Enter Username" pattern="^[a-zA-Z][a-zA-Z0-9]{2,10}$" title="Username must start with alphabets followed by numbers or other set of alphabets ranging from 3 to 10 in length." required />

                        </div>
                    </div>
                    <div class="col-md-10 mx-auto mt-3 mb-5">
                        <div class="form-group position-relative">
                            <label runat="server" for="dte" id="lbldte"><b>Date</b></label>
                            <input type="date" runat="server" name="dte" id="txtdate" class="form-control" placeholder="dd/mm/yyyy" required />


                            <div class="mx-align-self-auto text-center">
                                <br />
                                <asp:Button ID="Btnotp" runat="server" Text="Verify Date" class="btn btn-primary" OnClick="Button1_Click" />
                                
                            </div>
                        </div>
                    </div>
                
            </div>

        </div>
    </section>
        </form>
</body>
</html>

