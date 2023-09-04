using Student_course_registration_panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AddStudent.Models
{
    public class Student
    {
        public int ID { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; private set; }
        public Control SelectedOne { get; internal set; }

        private static HashSet<int> generatedstudentIds = new HashSet<int>();

        public Student(string name)
        {
            Name = name;
            ID = ProvideStudentId();
            RegisteredCourses = new List<Course>();
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);
        }


        private int ProvideStudentId()
        {
            Random random = new Random();
            int studentId;

            do
            {
                studentId = random.Next(100000, 1000000);
            } while (generatedstudentIds.Contains(studentId));

            generatedstudentIds.Add(studentId);
            return studentId;
        }

        public int TotalWeeklyHours()
        {
            int totalHours = RegisteredCourses.Sum(course => course.WeeklyHours);
            return totalHours;
        }

        public virtual new string ToString ()
        {
            return null;
        }
    }
}