using AddStudent.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AddStudent
{
    public partial class AddStudent : System.Web.UI.Page
    {
        private List<Student> students = new List<Student>();

        private List<string> types = new List<string>()
        {
            "Full Time",
            "Part Time",
            "Coop"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string type in types)
                {
                    addType.Items.Add(new ListItem(type));
                }

            }
            tblStudents.Rows.Clear();

            TableHeaderRow tableHeaderRow = new TableHeaderRow();

            TableHeaderCell leftHeaderCell = new TableHeaderCell();
            leftHeaderCell.Text = "ID";
            leftHeaderCell.CssClass = "bg-secondary-subtle";

            TableHeaderCell rightHeaderCell = new TableHeaderCell();
            rightHeaderCell.Text = "Student Name";
            rightHeaderCell.CssClass = "bg-secondary-subtle";

            tableHeaderRow.Cells.Add(leftHeaderCell);
            tableHeaderRow.Cells.Add(rightHeaderCell);


            tblStudents.Rows.Add(tableHeaderRow);
            TableRow row = new TableRow();

            TableCell tableNoRow = new TableCell();
            tableNoRow.Text = "No Student Yet!";
            tableNoRow.CssClass = "fw-bolder text-danger";
            row.Cells.Add(tableNoRow);

            TableCell tableNotRow = new TableCell();
            tableNotRow.Text = "";
            row.Cells.Add(tableNotRow);

            tblStudents.Rows.Add(row);

            if (Session["students"] != null)
            {
                students = (List<Student>)Session["students"];
                Display_Students();
            }

        }

        protected void Add_Student(object sender, EventArgs e)
        {

            if (IsValid)
            {
                Student student;


                if (addType.SelectedValue == "Full Time")
                {
                    student = new Fulltime_Student(addName.Text, Fulltime_Student.MaximumWeeklyHours);
                }
                else if (addType.SelectedValue == "Part Time")
                {
                    student = new Parttime_Student(addName.Text, Parttime_Student.MaximumNumberOfCourses);
                }

                else //(addType.SelectedValue == "Coop Time")
                {
                    student = new Coop(addName.Text, Coop.MaximumNumberOfCourses, Coop.MaximumWeeklyHours);
                }


                students.Add(student);

                Session["students"] = students;
                Display_Students();
                Reset_Form();
            }

        }

        protected void Reset_Form()
        {
            addName.Text = string.Empty;
            addType.SelectedIndex = 0;
            //txtList.Text = string.Empty;
        }

        protected void Display_Students()
        {

            tblStudents.Rows.Clear();

            TableHeaderRow tableHeaderRow = new TableHeaderRow();

            TableHeaderCell leftHeaderCell = new TableHeaderCell();
            leftHeaderCell.Text = "ID";
            leftHeaderCell.CssClass = "bg-secondary-subtle";

            TableHeaderCell rightHeaderCell = new TableHeaderCell();
            rightHeaderCell.Text = "Student Name";
            rightHeaderCell.CssClass = "bg-secondary-subtle";

            tableHeaderRow.Cells.Add(leftHeaderCell);
            tableHeaderRow.Cells.Add(rightHeaderCell);


            tblStudents.Rows.Add(tableHeaderRow);

            foreach (Student student in students)
            {

                    TableRow row = new TableRow();

                    TableCell studentIDCell = new TableCell();
                    studentIDCell.Text = student.ID.ToString();

                    TableCell studentNameCell = new TableCell();
                    studentNameCell.Text = student.Name;

                    row.Cells.Add(studentIDCell);
                    row.Cells.Add(studentNameCell);

                    tblStudents.Rows.Add(row);

            }
        }



    }
}