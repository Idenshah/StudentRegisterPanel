using AddStudent;
using AddStudent.Models;
using Lab6.Models;
using Student_course_registration_panel.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Student_course_registration_panel
{
    public partial class Course_registration : System.Web.UI.Page
    {
        private List<Student> students;

        protected void Page_Load(object sender, EventArgs e)
        {
            students = (List<Student>)Session["students"];

            if (!IsPostBack)
            {

                if (students != null && students.Count > 0)
                {
                    foreach (Student student in students)
                    {
                        selectStudent.Items.Add(new ListItem(student.ToString(), student.ID.ToString()));
                    }
                }

                List<Course> courses = Helper.GetAvailableCourses();
                foreach (var course in courses)
                {
                    cblCourses.Items.Add(new ListItem
                    {
                        Text = $"{course.Code} - {course.Title} - {course.WeeklyHours} hours/week",
                        Value = course.Code
                    });
                }
            }
        }

        protected void Save_Student(object sender, EventArgs e)
        {
            Add_course();
            List<Course> selectedCourses = new List<Course>();
            Student selectedPerson = null;
            string selectedValue = selectStudent.SelectedValue;

            foreach (Student student in students)
            {
                if (student.ID.ToString() == selectedValue)
                {
                    selectedPerson = student;
                    break;
                }
            }


            foreach (ListItem item in cblCourses.Items)
            {
                if (item.Selected)
                {
                    Course selectedCourse = Helper.GetCourseByCode(item.Value);
                    selectedCourses.Add(selectedCourse);
                }
            }

            try
            {
                selectedPerson.RegisterCourses(selectedCourses);
                if (selectedCourses.Count > 0)
                {
                    check.InnerHtml = $"Selected Student has registered {selectedCourses.Count} courses, {selectedCourses.Sum(c => c.WeeklyHours)} hours weekly.";
                    check.Style["color"] = "blue";
                }
                else
                {
                    check.InnerHtml = "Error: You need slecet at least one course" ;
                    check.Style["color"] = "red";
                }

            }
            catch (Exception ex)
            {
                check.InnerHtml = "Error: " + ex.Message;
                check.Style["color"] = "red";
            }

        }

        protected void Add_course()
        {
            List<Course> selectedCourses = new List<Course>();
            foreach (ListItem item in cblCourses.Items)
            {
                if (item.Selected)
                {
                    Course selectedCourse = Helper.GetCourseByCode(item.Value);
                    selectedCourses.Add(selectedCourse);
                }
            }
        }
    }
}
