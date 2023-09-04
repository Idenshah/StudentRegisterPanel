using Student_course_registration_panel.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddStudent.Models
{
    public class Fulltime_Student : Student
    {
        public List<string> ListFull { get; set; } = new List<string>();
        public static int MaximumWeeklyHours { get; set; } = 16;
        public new string SelectedOne { get; set; }


        public Fulltime_Student(string name,int maxHour) : base(name)
        {
            MaximumWeeklyHours = maxHour;
            SelectedOne = ToString();

        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalWeeklyHours = selectedCourses.Sum(course => course.WeeklyHours);

            if (totalWeeklyHours > MaximumWeeklyHours)
            {
                throw new Exception($"Allowed weekly hours for a fulltime student is {MaximumWeeklyHours}.");
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $"{ID} - {Name} (Full time)";
        }
    }
}