using Student_course_registration_panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddStudent.Models
{
    public class Coop : Student
    {
        
        public static int MaximumWeeklyHours { get; set; } = 4;
        public static int MaximumNumberOfCourses { get; set; } = 2;
        public new string SelectedOne { get; set; }

        public Coop(string name, int maxCourse, int maxHour) : base(name)
        {
            MaximumNumberOfCourses = maxCourse;
            MaximumWeeklyHours = maxHour;
            SelectedOne = ToString();
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int totalWeeklyHours = selectedCourses.Sum(course => course.WeeklyHours);

            if (selectedCourses.Count > MaximumNumberOfCourses && totalWeeklyHours > MaximumWeeklyHours)
            {
                throw new Exception($"Allowed number of courses for a coop student is {MaximumNumberOfCourses} and weekly hours is {MaximumWeeklyHours}.");
            }

            if (totalWeeklyHours > MaximumWeeklyHours)
            {
                throw new Exception($"Allowed weekly hours for a coop student is {MaximumWeeklyHours}.");
            }

            if (selectedCourses.Count > MaximumNumberOfCourses)
            {
                throw new Exception($"Allowed max number of courses for a coop student is {MaximumNumberOfCourses}.");
            }



            base.RegisterCourses(selectedCourses);


        }
        public override string ToString()
        {
          
            return $"{ID} - {Name} (Coop)";
 
        }
    }
}