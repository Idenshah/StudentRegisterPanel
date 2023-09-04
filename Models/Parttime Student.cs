using Student_course_registration_panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddStudent.Models
{
    public class Parttime_Student : Student
    {
        public List<string> ListPart { get; set; } = new List<string>();
        public static int MaximumNumberOfCourses { get; set; } = 3;
        public new string SelectedOne { get; set; }

        public Parttime_Student(string name, int maxCourse) : base(name)   
        {
            MaximumNumberOfCourses = maxCourse;
            SelectedOne = ToString();
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Count > MaximumNumberOfCourses)
            {
                throw new Exception($"Allowed number of courses for a parttime student is {MaximumNumberOfCourses}.");
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{ID} - {Name} (Part time)";
        }
    }
}