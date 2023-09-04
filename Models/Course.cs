using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Student_course_registration_panel.Models
{
    public class Course
    {
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }

    }
}