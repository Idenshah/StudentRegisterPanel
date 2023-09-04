<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="AddStudent.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddStudent</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/css/bootstrap.min.css" />
</head>
<body class="bg-warning">
    <div class="container">
        <h1 class="display-4 p-5 text-center fw-semibold">Students</h1>
        <div class="row">
            <div class="col col-md-8 offset-md-2">
                <form class="p-5 bg-light border border-1 mb-5" id="studentform" runat="server">
                    <div class="form-group mb-3">
                        <label for="addName" class="form-lable">Student Name:</label>
                        <asp:TextBox ID="addName" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="rfvName"
                            runat="server"
                            ControlToValidate="addName"
                            CssClass="text-danger"
                            Display="Dynamic"
                            EnbleClientScript="True">
                            Please Insert The Name!
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group mb-3">
                        <label for="addType" class="form-lable">Student Type:</label>
                        <asp:DropDownList ID="addType" runat="server" CssClass="form-select">
                            <asp:ListItem Value="">Select Type Of Program </asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator
                            ID="rfvType"
                            runat="server"
                            ControlToValidate="addType"
                            CssClass="text-danger"
                            Display="Dynamic"
                            EnbleClientScript="True">
                            Please Select Student Type!
                        </asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="btnAddStudent" runat="server" Text="Add" CssClass="btn btn-primary m-3" OnClick="Add_Student" />
                    <div class="mb-3">
                        <div class="alert alert-danger" id="error" runat="server" visible="false"></div>
                    </div>
                    <div class="row">
                        <div class="tableContainer">
                            <asp:Table ID="tblStudents" runat="server" CssClass="table table-bordered table-info table-striped" Visible="true">
                            </asp:Table>
                        </div>
                    </div>
                </form>
                <div class="mt-4 text-center">
                    <a href="RegisterCourse.aspx" class="secondary">Register Courses</a>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
