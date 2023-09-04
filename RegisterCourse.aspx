<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Student_course_registration_panel.Course_registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Course Registration Panel</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="App_Themes/Style.css" />
</head>
<body class="bg-warning">
    <div class="container">
        <h1 class="display-4 p-5 text-center fw-semibold">Algonquin College Course Registration</h1>
        <div class="row">
            <div class="col col-md-8 offset-md-2">
                <form class="p-5 bg-light border border-1 mb-5" id="requestForm" runat="server" visible="true">
                    <div class="form-group mb-3" id="name" visible="true" runat="server">
                        <lable for="txtName" class="form-label fw-bold">Student:</lable>
                        <asp:DropDownList ID="selectStudent" runat="server" CssClass="form-select">
                            <asp:ListItem Value="">Select...</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator
                            ID="rfvSelect"
                            runat="server"
                            ControlToValidate="selectStudent"
                            CssClass="text-danger"
                            Display="Dynamic"
                            EnbleClientScript="True">
                            Please Select One!
                        </asp:RequiredFieldValidator>

                    </div>
                    <div class="mb-3">
                        <div class="alert alert-danger" id="error" runat="server" visible="false"></div>
                    </div>
                    <div id="comment" visible="true" runat="server" class="text-warning fw-semibold">
                        Following courses are currently available for registration
                    </div>

                    <div id="check" runat="server" class="bg-light fw-semibold"></div>
                    <div class="form-group mb-3">
                        <asp:CheckBoxList ID="cblCourses" runat="server" RepeatLayout="Flow" CssClass="d-block form-checkbox-list" Visible="true" ></asp:CheckBoxList>
                    </div>
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" Visible="true" OnClick="Save_Student" />
                </form>
            </div>
        </div>
        <div class="row">
            <div class="col col-md-10 offset-md-1">
                <asp:Table ID="tblDetails" runat="server" CssClass="table table-bordered table-success table-striped" Visible="false">
                </asp:Table>
            </div>
            <div class="mt-4 text-center">
                <a href="AddStudent.aspx" class="secondary">Add Student</a>
            </div>
        </div>
    </div>  
</body>
</html>

