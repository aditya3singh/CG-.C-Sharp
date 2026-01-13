using System;
using System.IO;
using System.Linq.Expressions;

class Student
{
    private string name;
    private int age;
    private int marks;
    private int studentID; 
    private string password;

    public int StudentID{get; set;}
    public string Result
    {
        get
        {
            return marks >= 40 ? "pass" : "fail";
        }
    }

    public string Password
    {
        set
        {
            if(value.Length >= 6)
            {
                password = value;
            }
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                name = value;
            }
        }
    }
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if(value > 0)
            {
                age = value;
            }
        }
    }

    public int Marks
    {
        get
        {
            return marks;
        }
        set
        {
            if(value >= 0 && value <= 100)
            {
                marks = value;
            }
        }
    }
}