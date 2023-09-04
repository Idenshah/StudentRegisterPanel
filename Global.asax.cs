using AddStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Lab8
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptResourceDefinition RefDef = new ScriptResourceDefinition();
            RefDef.Path = "https://unpkg.com/jquery";
            RefDef.DebugPath = "https://unpkg.com/jquery";
            RefDef.CdnPath = "https://unpkg.com/jquery";
            RefDef.CdnDebugPath = "https://unpkg.com/jquery";

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, RefDef);


            Fulltime_Student.MaximumWeeklyHours = 16;
            Parttime_Student.MaximumNumberOfCourses = 3;
            Coop.MaximumWeeklyHours = 4;
            Coop.MaximumNumberOfCourses = 2;
        }
    }
}