# StudentRegisterPanel

Overview:

This web application was created to demonstrate two main concepts:

1) ASP.NET Validation Controls: The application uses ASP.NET Validation Controls to ensure that specific fields on web pages are properly filled out by users.

2 )Polymorphism in Object-Oriented Programming (OOP): Polymorphism is implemented to apply different business rules for different types of students.

Usage:

Once the application is running, you can use it as follows:

Add Student Page (AddStudent.aspx):

Ensure that both the Student Name and Student Type fields are filled out. These are required fields, and the application will display an error message if they are not provided.
After completing the form, click the "Submit" button.
Register Course Page (RegisterCourse.aspx):

Select a student from the dropdown list.
The page will display the student's registration summary and pre-check the courses the student has already registered.
You can check and uncheck courses to select or deselect them.
After selecting courses, click the "Save" button to register the student for the chosen courses.
The application will validate the selected courses against specific business rules, and if they pass, it will update the registration summary.
